using GameCore.Events;
using GameCore.ScriptableObjects;
using GameCore.ServerAPI;
using GameCore.UI;
using UnityEngine;

namespace GameCore
{
    [RequireComponent(typeof(UWebRequest))]
    public class GameDirector : MonoBehaviour
    {
        [SerializeField] private AssetRefs _assetRefs;
        [SerializeField] private UIManager _uiManagerRef;
        private EventBus _eventBus;
        private IUWebRequest _webRequest;
        private IUIManager _uiManager;
        

        private void Start()
        {
            _eventBus = new EventBus();
            _webRequest = GetComponent<UWebRequest>();
            _webRequest.Init(_eventBus);
            _uiManager = _uiManagerRef;
            _uiManager.Init(_assetRefs, _webRequest, _eventBus);
        }
    }
}