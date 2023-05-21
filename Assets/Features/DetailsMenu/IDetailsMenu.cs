using GameCore.Jsons;
using UnityEngine;

namespace Features.DetailsMenu
{
    public interface IDetailsMenu
    {
        GameObject SetupDetailsContainer(TournamentDetails data);
    }
}