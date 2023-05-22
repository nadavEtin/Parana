using Features.DetailsMenu;
using Features.TournamentHistoryView;
using GameCore.Events;
using GameCore.ScriptableObjects;
using GameCore.ServerAPI;
using UnityEngine;

namespace GameCore.UI
{
    public class UIManager : MonoBehaviour, IUIManager
    {
        [SerializeField] private Transform _historyViewsContainer;
        private TournamentHistoryManager _tournamentHistoryManager;
        private IDetailsMenu _detailsMenu;
        private AssetRefs _assetRefs;
        private EventBus _eventBus;
        private IUWebRequest _webRequest;

        private Popup _msgPopup;

        public void Init(AssetRefs assetRefs, IUWebRequest webRequest, EventBus eventBus)
        {
            _assetRefs = assetRefs;
            _webRequest = webRequest;
            _eventBus = eventBus;
            _eventBus.Subscribe(GameplayEvent.Error, ShowErrorPopup);

            _msgPopup = null;
            var detailsMenuObj = Instantiate(_assetRefs.DetailsMenuPrefab, transform);
            _detailsMenu = detailsMenuObj.GetComponent<IDetailsMenu>();
            _detailsMenu.Init(_assetRefs);
            detailsMenuObj.SetActive(false);
            _tournamentHistoryManager = new TournamentHistoryManager(_webRequest, _assetRefs, _historyViewsContainer,
                detailsMenuObj/*, _eventBus*/);
        }

        private void ShowErrorPopup(BaseEventParams eventParams)
        {
            var error = (ErrorEventParams)eventParams;
            //Create the popup once when its needed
            if (_msgPopup == null)
                _msgPopup = Instantiate(_assetRefs.PopupPrefab, transform).GetComponent<Popup>();
            
            _msgPopup.Setup(error.ErrorMessage);
        }

        private void OnDestroy()
        {
            _eventBus.Unsubscribe(GameplayEvent.Error, ShowErrorPopup);
        }
    }
}