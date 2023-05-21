using System.Collections.Generic;
using Features.DetailsMenu.TournamentDetailsView;
using GameCore.Jsons;
using GameCore.ScriptableObjects;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Features.DetailsMenu
{
    public class DetailsMenu : MonoBehaviour, IDetailsMenu
    {
        [SerializeField] private TextMeshProUGUI _title, _gameType;
        [SerializeField] private Button _closeBtn, _claimBtn;
        [SerializeField] private Transform _maskView;

        private AssetRefs _assetRefs;
        private List<GameObject> _detailViewContainers;

        public void Init(AssetRefs assetRefs)
        {
            _assetRefs = assetRefs;
            _detailViewContainers = new List<GameObject>();
        }

        public void SetMenuData(string gameType, bool prizeAvailable, string prizeMsg)
        {
        }

        public GameObject SetupDetailsContainer(TournamentDetails data)
        {
            var newContainer = Instantiate(_assetRefs.TournamentDetailsContainer, _maskView);
            _detailViewContainers.Add(newContainer);
            newContainer.SetActive(false);
            var players = data.Participants;
            for (int i = 0; i < players.Count; i++)
            {
                var playerDetailsView = Instantiate(_assetRefs.TournamentDetailsViewPrefab, newContainer.transform)
                    .GetComponent<ITournamentDetailsView>();
                playerDetailsView.InitData(players[i]);
            }

            return newContainer;
        }
    }
}