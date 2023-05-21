using UnityEngine;
using UnityEngine.Serialization;

namespace GameCore.ScriptableObjects
{
    [CreateAssetMenu(fileName = "AssetRefs", menuName = "Scriptable Objects/Asset References")]
    public class AssetRefs : ScriptableObject
    {
        [SerializeField] private GameObject tournamentHistoryPrefab;

        [SerializeField] private GameObject tournamentDetailsViewPrefab;

        [SerializeField] private GameObject tournamentDetailsContainer, detailsMenuPrefab;

        public GameObject TournamentHistoryPrefab => tournamentHistoryPrefab;
        public GameObject TournamentDetailsViewPrefab => tournamentDetailsViewPrefab;
        public GameObject TournamentDetailsContainer => tournamentDetailsContainer;
        public GameObject DetailsMenuPrefab => detailsMenuPrefab;
    }
}