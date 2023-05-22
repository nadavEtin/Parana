using GameCore.Events;
using GameCore.ScriptableObjects;
using GameCore.ServerAPI;

namespace GameCore.UI
{
    public interface IUIManager
    {
        void Init(AssetRefs assetRefs, IUWebRequest webRequest, EventBus eventBus);
    }
}