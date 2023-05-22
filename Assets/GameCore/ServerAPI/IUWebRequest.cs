using System;
using GameCore.Events;

namespace GameCore.ServerAPI
{
    public interface IUWebRequest
    {
        string TournamentHistoryUri { get; }
        string TournamentDetailsUri { get; }
        void GetRequest(string uri, Action<bool, string> onFinishCallback);
        void Init(EventBus eventBus);
    }
}