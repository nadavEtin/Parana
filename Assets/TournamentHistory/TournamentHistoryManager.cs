using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using GameCore.Jsons;
using GameCore.ScriptableObjects;
using GameCore.ServerAPI;
using UnityEngine;

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
            if (success)
            {
                //assign the relevant data
                _tournamentInfo[history] = details;
                var historyView = GameObject.Instantiate(_tournamentHistoryPrefab, _viewsContainer).GetComponent<ITournamentHistoryView>();
                var date = DateTime.UnixEpoch.AddMilliseconds(history.CreationTimestamp).Date;
                var playerDetails = details.Participants.Find(a => a.IsYou == true);
                historyView.InitData(details.TournamentDefition.TournamentType, details.TournamentDefition.ParticipantsCount,
                    date, playerDetails.ScorePosition, playerDetails.PrizeAmountGems);
            }
            Debug.Log("");
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
                var tournyHistories = data.Content.tournaments;
                for (int i = 0; i < tournyHistories.Count; i++)
                {
                    //save the currently available data
                    _tournamentInfo.Add(tournyHistories[i], null);
                    //var historyView = GameObject.Instantiate(historyViewPrefab, _viewsContainer).GetComponent<ITournamentHistoryView>();
                    _webRequest.GetRequest(string.Format(_webRequest.TournamentDetailsUri, tournyHistories[i].ID), DetailsRequestDone);
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