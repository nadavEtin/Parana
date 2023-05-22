using System.Collections.Generic;
using System.Linq;
using Features.DetailsMenu.View;
using GameCore.Jsons;
using GameCore.ScriptableObjects;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Features.DetailsMenu
{
    [RequireComponent(typeof(ScrollRect))]
    public class DetailsMenu : MonoBehaviour, IDetailsMenu
    {
        [SerializeField] private TextMeshProUGUI _title, _gameType;
        [SerializeField] private Button _closeBtn, _claimBtn;
        [SerializeField] private Transform _maskView;
        [SerializeField] private ScrollRect _scrollRect;

        private AssetRefs _assetRefs;
        private List<GameObject> _detailViewContainers;
        private List<string> _claimedPrizes;
        private GameObject _activeContainer;
        private TournamentDetails _activeTournamentDetails;
        private string _rewardClaimMsg;

        public void Init(AssetRefs assetRefs)
        {
            _assetRefs = assetRefs;
            _detailViewContainers = new List<GameObject>();
            _claimedPrizes = new List<string>();
        }

        //Creates a new container with all relevant data of that tournament
        public GameObject CreateDetailsContainers(TournamentDetails data)
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

        public void ShowCurrentContainer(GameObject container, TournamentDetails details)
        {
            SetMenuData(details);
            _activeContainer = container;
            gameObject.SetActive(true);
            _activeContainer.SetActive(true);
            _scrollRect.content = _activeContainer.GetComponent<RectTransform>();
        }

        public void ClaimButtonClick()
        {
            //Marks reward as claimed to stop repeated claims
            _claimedPrizes.Add(_activeTournamentDetails.ClaimID);
            _claimBtn.gameObject.SetActive(false);
            Debug.Log(_rewardClaimMsg);
        }

        public void CloseButtonClick()
        {
            _activeContainer.SetActive(false);
            gameObject.SetActive(false);
        }
        
        private void SetMenuData(TournamentDetails details)
        {
            _gameType.text = $"{details.TournamentDefition.GameType} Pool";
            _activeTournamentDetails = details;
            
            //Check if the reward was already claimed
            var claimed = _claimedPrizes.Contains(details.ClaimID);
            if (details.ClaimID != null && claimed == false)
            {
                _claimBtn.gameObject.SetActive(true);
                var prizeAmount = details.Participants.FirstOrDefault(a => a.IsYou)?.PrizeAmountGems;
                _rewardClaimMsg = $"You won {prizeAmount} gems!";
                
                //Logic for giving the reward to the user...
            }
        }
    }
}