using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace TournamentHistory
{
    public class TournamentHistoryView : MonoBehaviour, ITournamentHistoryView
    {
        [SerializeField] private TextMeshProUGUI tourName, playersCount, date, rank, prize;
        [SerializeField] private Button leaderboardBtn;

        public void InitData(string tournamentName, int count, DateTime date, int rank, int prize)
        {
            
        }

        public void SetViewData()
        {
        
        }
    }
}
