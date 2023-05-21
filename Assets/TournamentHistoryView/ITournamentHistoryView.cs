using System;
using GameCore.Jsons;

namespace TournamentHistory
{
    public enum PrizeType
    {
        None, Cash, Gems
    }
    
    public interface ITournamentHistoryView
    {
        //void InitData(string tournamentName, int count, DateTime date, int rank, int prize, PrizeType prizeType = PrizeType.None);
        void InitData(TournamentGeneralInfo history, TournamentDetails details);
    }
}