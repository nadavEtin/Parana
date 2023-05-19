using System;

namespace TournamentHistory
{
    public interface ITournamentHistoryView
    {
        void InitData(string tournamentName, int count, DateTime date, int rank, int prize);
    }
}