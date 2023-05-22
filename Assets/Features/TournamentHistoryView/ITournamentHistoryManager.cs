using GameCore.Jsons;
using UnityEngine;

namespace Features.TournamentHistoryView
{
    public interface ITournamentHistoryManager
    {
        void SetDetailsContainer(GameObject container, TournamentDetails details);
    }
}