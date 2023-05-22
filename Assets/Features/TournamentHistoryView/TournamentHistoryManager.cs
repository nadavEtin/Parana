using System.Collections.Generic;
using System.Linq;
using Features.DetailsMenu;
using Features.TournamentHistoryView.View;
using GameCore.Jsons;
using GameCore.ScriptableObjects;
using GameCore.ServerAPI;
using UnityEngine;

namespace Features.TournamentHistoryView
{
    public class TournamentHistoryManager : ITournamentHistoryManager
    {
        private IUWebRequest _webRequest;
        private AssetRefs _assetRefs;
        private Transform _historyViewsContainer;

        private GameObject _tournamentDetailsMenu;
        private GameObject _tournamentHistoryPrefab, _tournamentDetailsPrefab;
        private IDetailsMenu _detailsMenuScript;
        private Dictionary<TournamentGeneralInfo, TournamentDetails> _tournamentInfo;

        public TournamentHistoryManager(IUWebRequest webRequest, AssetRefs assetRefs,
            Transform historyViewsContainer, GameObject detailsMenu)
        {
            _webRequest = webRequest;
            _assetRefs = assetRefs;

            _tournamentHistoryPrefab = _assetRefs.TournamentHistoryPrefab;
            _tournamentDetailsMenu = detailsMenu;
            _detailsMenuScript = _tournamentDetailsMenu.GetComponent<IDetailsMenu>();
            _historyViewsContainer = historyViewsContainer;
            _tournamentInfo = new Dictionary<TournamentGeneralInfo, TournamentDetails>();
            _webRequest.GetRequest(_webRequest.TournamentHistoryUri, HistoryRequestDone);
        }
        
        public void SetDetailsContainer(GameObject container, TournamentDetails details)
        {
            _detailsMenuScript.ShowCurrentContainer(container, details);
        }

        private void DetailsRequestDone(bool success, string jsonData)
        {
            var details = JsonUtility.FromJson<TDRoot>(jsonData).Content.TournamentDetails;
            var history = _tournamentInfo.Keys.FirstOrDefault(a => a.ID == details.TournamentID);
            if (success && history != null)
            {
                //Assign the new data to its matching tournament
                _tournamentInfo[history] = details;
                var historyView = Object.Instantiate(_tournamentHistoryPrefab, _historyViewsContainer)
                    .GetComponent<ITournamentHistoryView>();
                var detailsContainer = _detailsMenuScript.CreateDetailsContainers(details);
                historyView.InitData(history, details, detailsContainer, this);
            }
        }

        private void HistoryRequestDone(bool success, string jsonData)
        {
            if (success)
            {
                var data = JsonUtility.FromJson<TournamentHistoryData>(jsonData);
                var histories = data.Content.tournaments;
                for (int i = 0; i < histories.Count; i++)
                {
                    //Save the currently available tournament history data
                    _tournamentInfo.Add(histories[i], null);
                    _webRequest.GetRequest(string.Format(_webRequest.TournamentDetailsUri, histories[i].ID),
                        DetailsRequestDone);
                }
            }
        }
    }
}