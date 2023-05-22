using UnityEngine;

namespace GameCore.ScriptableObjects
{
    [CreateAssetMenu(fileName = "AssetRefs", menuName = "Scriptable Objects/Asset References")]
    public class AssetRefs : ScriptableObject
    {
        [SerializeField] private GameObject _tournamentHistoryPrefab, _tournamentDetailsViewPrefab,
            _detailsMenuPrefab, _tournamentDetailsContainer, _popupPrefab;

        public GameObject TournamentHistoryPrefab => _tournamentHistoryPrefab;
        public GameObject TournamentDetailsViewPrefab => _tournamentDetailsViewPrefab;
        public GameObject TournamentDetailsContainer => _tournamentDetailsContainer;
        public GameObject DetailsMenuPrefab => _detailsMenuPrefab;
        public GameObject PopupPrefab => _popupPrefab;
    }
}