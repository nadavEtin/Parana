using System;
using System.Collections.Generic;
using System.Linq;
using GameCore.Jsons;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace TournamentHistoryView
{
    public class TournamentHistoryView : MonoBehaviour, ITournamentHistoryView
    {
        [SerializeField] private TextMeshProUGUI nameLabel, playersCountLabel, dateLabel, rankLabel, prizeLabel;
        [SerializeField] private Button leaderboardBtn;
        private PrizeType _prizeType = PrizeType.None;
        private List<GameObject> _detailsViews;
        private GameObject _detailViewsContainer;

        private void Start()
        {
            _detailsViews = new List<GameObject>();
        }

        public void InitData(TournamentGeneralInfo history, TournamentDetails details,
            GameObject detailsContainer)
        {
            _detailViewsContainer = detailsContainer;
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

        private void TournamentDetailsSetup(GameObject view)
        {
            _detailsViews.Add(view);
            
        }

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

        /*public void InitData(string tournamentName, int count, DateTime date, int rank, int prize)
        {
            tourName.text = $"{tournamentName} Pool";
            playersCount.text = $"{count} Players";
            this.date.text = date.ToString(CultureInfo.CurrentCulture);
            this.rank.text = rank.ToString();
            if (prize > 0)
                this.prize.text = prize.ToString();
        }*/
    }
}
