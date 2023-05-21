using Features.DetailsMenu;
using GameCore.ScriptableObjects;
using GameCore.ServerAPI;
using TournamentHistoryView;
using UnityEngine;

namespace GameCore
{
    public class UIManager : MonoBehaviour, IUIManager
    {
        
        [SerializeField] private Transform _historyViewsContainer;
        private TournamentHistoryManager _tournamentHistoryManager;
        private GameObject _detailsMenu;
        private AssetRefs _assetRefs;
        private IUWebRequest _webRequest;

        public void Init(AssetRefs assetRefs, IUWebRequest webRequest)
        {
            _assetRefs = assetRefs;
            _webRequest = webRequest;

            _detailsMenu = Instantiate(_assetRefs.DetailsMenuPrefab, transform);
            _detailsMenu.SetActive(false);
            _tournamentHistoryManager = new TournamentHistoryManager(_webRequest, _assetRefs, _historyViewsContainer,
                _detailsMenu);
        }
    }
}