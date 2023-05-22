using System;
using System.Linq;
using GameCore.Jsons;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Features.TournamentHistoryView.View
{
    public class TournamentHistoryView : MonoBehaviour, ITournamentHistoryView
    {
        [SerializeField] private TextMeshProUGUI nameLabel, playersCountLabel, dateLabel, rankLabel, prizeLabel;
        [SerializeField] private Button leaderboardBtn;
        private ITournamentHistoryManager _historyManager;
        private PrizeType _prizeType = PrizeType.None;
        private GameObject _detailViewsContainer;
        private TournamentDetails _tournamentDetails;

        public void InitData(TournamentGeneralInfo history, TournamentDetails details,
            GameObject detailsContainer, ITournamentHistoryManager manager)
        {
            _historyManager = manager;
            _detailViewsContainer = detailsContainer;
            _tournamentDetails = details;
            var date = DateTime.UnixEpoch.AddMilliseconds(history.CreationTimestamp).Date;
            var playerDetails = details.Participants.FirstOrDefault(a => a.IsYou);
            nameLabel.text = $"{details.TournamentDefition.GameType} Pool";
            playersCountLabel.text = $"{details.TournamentDefition.ParticipantsCount} Players";
            dateLabel.text = date.ToShortDateString();
            rankLabel.text = playerDetails?.ScorePosition.ToString();

            if (history.ClaimID == null)
            {
                _prizeType = PrizeType.None;
                prizeLabel.text = RewardString(_prizeType);
            }
            else
            {
                _prizeType = history.PrizeAmountCash != null ? PrizeType.Cash : PrizeType.Gems;
                var amount = _prizeType == PrizeType.Cash ? history.PrizeAmountCash : history.PrizeAmountGems;
                prizeLabel.text = RewardString(_prizeType, amount ?? default(int));
            }
        }

        public void LeaderboardBtnClick()
        {
            _historyManager.SetDetailsContainer(_detailViewsContainer, _tournamentDetails);
        }

        //Returns a string matching the reward
        private string RewardString(PrizeType type, int amount = 0)
        {
            switch (type)
            {
                case PrizeType.Cash:
                    return $"You won {amount}$";
                case PrizeType.Gems:
                    return $"You won {amount} gems";
                case PrizeType.None:
                    return "Better luck next time!";
                case PrizeType:
                    return "Better luck next time!"; 
            }
        }
    }
}
