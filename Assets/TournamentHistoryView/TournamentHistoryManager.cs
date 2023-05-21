using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using GameCore.Jsons;
using GameCore.ScriptableObjects;
using GameCore.ServerAPI;
using UnityEngine;
using Object = UnityEngine.Object;

namespace TournamentHistory
{
    public class TournamentHistoryManager
    {
        private IUWebRequest _webRequest;
        private AssetRefs _assetRefs;
        private Transform _viewsContainer;

        private GameObject _tournamentHistoryPrefab;
        private Dictionary<TournamentGeneralInfo, TournamentDetails> _tournamentInfo;

        public TournamentHistoryManager(IUWebRequest webRequest, AssetRefs assetRefs, Transform viewsContainer)
        {
            _webRequest = webRequest;
            _assetRefs = assetRefs;
            _tournamentHistoryPrefab = _assetRefs.TournamentHistoryPrefab;
            _viewsContainer = viewsContainer;
            _tournamentInfo = new Dictionary<TournamentGeneralInfo, TournamentDetails>();
            _webRequest.GetRequest(_webRequest.TournamentHistoryUri, HistoryRequestDone);
        }

        private void DetailsRequestDone(bool success, string jsonData)
        {
            var details = JsonUtility.FromJson<TDRoot>(jsonData).Content.TournamentDetails;
            var history = _tournamentInfo.Keys.FirstOrDefault(a => a.ID == details.TournamentID);
            if (success && history != null)
            {
                //assign the relevant data
                _tournamentInfo[history] = details;
                var historyView = Object.Instantiate(_tournamentHistoryPrefab, _viewsContainer)
                    .GetComponent<ITournamentHistoryView>();
                historyView.InitData(history, details);
                /*historyView.InitData(details.TournamentDefition.GameType,
                    details.TournamentDefition.ParticipantsCount,
                    date, playerDetails.ScorePosition, playerDetails.PrizeAmountGems);*/
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
                    //save the currently available data
                    _tournamentInfo.Add(histories[i], null);
                    _webRequest.GetRequest(string.Format(_webRequest.TournamentDetailsUri, histories[i].ID),
                        DetailsRequestDone);
                }

                //var historyViewPrefab = _assetRefs.TournamentHistoryPrefab;
                /*for (int i = 0; i < tournaments.Count; i++)
                {
                    //var curData = tournaments[i];
                    //var historyView = GameObject.Instantiate(historyViewPrefab, _viewsContainer).GetComponent<ITournamentHistoryView>();
                    //var date = DateTime.UnixEpoch.AddMilliseconds(curData.CreationTimestamp);
                    //curData.ID
                    //historyView.InitData(curData.TournamentDefinition.DisplayName, curData.ParticipantsCount, date.Date, curData.TournamentDefinition.);
                }*/
            }
        }
    }
}