using GameCore.Jsons;
using GameCore.ScriptableObjects;
using UnityEngine;

namespace Features.DetailsMenu
{
    public interface IDetailsMenu
    {
        GameObject CreateDetailsContainers(TournamentDetails data);
        void Init(AssetRefs assetRefs);
        void ShowCurrentContainer(GameObject container, TournamentDetails details);
    }
}