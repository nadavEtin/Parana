using GameCore.Jsons;
using UnityEngine;

namespace TournamentHistoryView
{
    public enum PrizeType
    {
        None, Cash, Gems
    }
    
    public interface ITournamentHistoryView
    {
        void InitData(TournamentGeneralInfo history, TournamentDetails details, GameObject detailsContainer);
    }
}