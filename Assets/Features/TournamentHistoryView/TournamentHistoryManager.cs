using System.Collections.Generic;
using System.Linq;
using Features.DetailsMenu;
using GameCore.Jsons;
using GameCore.ScriptableObjects;
using GameCore.ServerAPI;
using UnityEngine;
using Object = UnityEngine.Object;

namespace TournamentHistoryView
{
    public class TournamentHistoryManager
    {
        private IUWebRequest _webRequest;
        private AssetRefs _assetRefs;
        private Transform _historyViewsContainer;//, _detailsMaskView;

        private GameObject _tournamentDetailsMenu;
        private GameObject _tournamentHistoryPrefab, _tournamentDetailsPrefab, _detailsContainerPrefab;
        private IDetailsMenu _detailsMenuScript;
        private Dictionary<TournamentGeneralInfo, TournamentDetails> _tournamentInfo;

        public TournamentHistoryManager(IUWebRequest webRequest, AssetRefs assetRefs, 
            Transform historyViewsContainer, GameObject detailsMenu)
        {
            _webRequest = webRequest;
            _assetRefs = assetRefs;
            _tournamentHistoryPrefab = _assetRefs.TournamentHistoryPrefab;
            _detailsContainerPrefab = _assetRefs.TournamentDetailsContainer;
            _tournamentDetailsMenu = detailsMenu;
            _detailsMenuScript = _tournamentDetailsMenu.GetComponent<IDetailsMenu>();
            //_detailsMaskView = detailsMaskView;
            _historyViewsContainer = historyViewsContainer;
            _tournamentInfo = new Dictionary<TournamentGeneralInfo, TournamentDetails>();
            _webRequest.GetRequest(_webRequest.TournamentHistoryUri, HistoryRequestDone);
        }

        private void DetailsRequestDone(bool success, string jsonData)
        {
            var details = JsonUtility.FromJson<TDRoot>(jsonData).Content.TournamentDetails;
            var history = _tournamentInfo.Keys.FirstOrDefault(a => a.ID == details.TournamentID);
            if (success && history != null)
            {
                //assign the new data to its matching tournament
                _tournamentInfo[history] = details;
                var historyView = Object.Instantiate(_tournamentHistoryPrefab, _historyViewsContainer)
                    .GetComponent<ITournamentHistoryView>();
                var detailsContainer = _detailsMenuScript.SetupDetailsContainer(details);
                historyView.InitData(history, details, _tournamentDetailsPrefab);
                
            }
        }

        private void HistoryRequestDone(bool result, string jsonData)
        {
            if (result == false)
            {
                //TODO: show an error popup
            }
            else
            {
                var data = JsonUtility.FromJson<TournamentHistoryData>(jsonData);
                var histories = data.Content.tournaments;
                for (int i = 0; i < histories.Count; i++)
                {
                    //save the currently available tournament history data
                    _tournamentInfo.Add(histories[i], null);
                    _webRequest.GetRequest(string.Format(_webRequest.TournamentDetailsUri, histories[i].ID),
                        DetailsRequestDone);
                }
            }
        }
    }
}