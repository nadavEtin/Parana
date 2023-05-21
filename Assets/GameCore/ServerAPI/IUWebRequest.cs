using System;

namespace GameCore.ServerAPI
{
    public interface IUWebRequest
    {
        string TournamentHistoryUri { get; }
        string TournamentDetailsUri { get; }
        void GetRequest(string uri, Action<bool, string> onFinishCallback);
    }
}