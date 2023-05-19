using GameCore.ScriptableObjects;
using GameCore.ServerAPI;

namespace GameCore
{
    public interface IUIManager
    {
        void Init(AssetRefs assetRefs, IUWebRequest webRequest);
    }
}