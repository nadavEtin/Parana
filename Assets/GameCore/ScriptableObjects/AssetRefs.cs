using UnityEngine;

namespace GameCore.ScriptableObjects
{
    [CreateAssetMenu(fileName = "AssetRefs", menuName = "Scriptable Objects/Asset References")]
    public class AssetRefs : ScriptableObject
    {
        [SerializeField] private GameObject _tournamentHistoryPrefab;
        public GameObject TournamentHistoryPrefab => _tournamentHistoryPrefab;
    }
}