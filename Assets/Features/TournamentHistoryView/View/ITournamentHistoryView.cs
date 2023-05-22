using GameCore.Jsons;
using UnityEngine;

namespace Features.TournamentHistoryView.View
{
    public enum PrizeType
    {
        None, Cash, Gems
    }
    
    public interface ITournamentHistoryView
    {
        void InitData(TournamentGeneralInfo history, TournamentDetails details, GameObject detailsContainer,
            ITournamentHistoryManager manager);
    }
}