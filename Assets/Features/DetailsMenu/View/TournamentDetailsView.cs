using GameCore.Jsons;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Features.DetailsMenu.View
{
    public class TournamentDetailsView : MonoBehaviour, ITournamentDetailsView
    {
        [SerializeField] private TextMeshProUGUI nameLabel, scoreLabel, rankLabel, prizeLabel;
        [SerializeField] private Image avatarImg;

        public void InitData(Participant playerDetails)
        {
            nameLabel.text = playerDetails.UserPublicData.DisplayName;
            scoreLabel.text = $"Score: {playerDetails.Score}";
            rankLabel.text = playerDetails.ScorePosition.ToString();
            
            if(playerDetails.PrizeAmountGems > 0)
                prizeLabel.text = $"Prize {playerDetails.PrizeAmountGems} gems";
        }
    }
}