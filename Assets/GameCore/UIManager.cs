using System;
using GameCore.ScriptableObjects;
using GameCore.ServerAPI;
using TournamentHistory;
using UnityEngine;

namespace GameCore
{
    public class UIManager : MonoBehaviour, IUIManager
    {
        [SerializeField] private Transform _historyViewsContainer;
        private TournamentHistoryManager _tournamentHistoryMngr;
        private AssetRefs _assetRefs;
        private IUWebRequest _webRequest;

        public void Init(AssetRefs assetRefs, IUWebRequest webRequest)
        {
            _assetRefs = assetRefs;
            _webRequest = webRequest;
            
            _tournamentHistoryMngr = new TournamentHistoryManager(_webRequest, _assetRefs, _historyViewsContainer);
        }
    }
}