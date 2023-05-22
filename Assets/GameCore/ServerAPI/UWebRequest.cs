using System;
using System.Collections;
using GameCore.Events;
using UnityEngine;
using UnityEngine.Networking;

namespace GameCore.ServerAPI
{
    public class UWebRequest : MonoBehaviour, IUWebRequest
    {
        private const string _tournamentHistoryUri = "https://parana-unity-test.s3.amazonaws.com/tournament-history.json";
        private const string _tournamentDetailsUri = "https://parana-unity-test.s3.amazonaws.com/tournament-details/{0}.json";

        public string TournamentHistoryUri => _tournamentHistoryUri;
        public string TournamentDetailsUri => _tournamentDetailsUri;

        private EventBus _eventBus;

        public void Init(EventBus eventBus)
        {
            _eventBus = eventBus;
        }

        public void GetRequest(string uri, Action<bool, string> onFinishCallback)
        {
            StartCoroutine(GetRequestEnum(uri, onFinishCallback));
        }

        public IEnumerator GetRequestEnum(string uri, Action<bool, string> onFinishCallback)
        {
            using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
            {
                yield return webRequest.SendWebRequest();
                switch (webRequest.result)
                {
                    case UnityWebRequest.Result.Success:
                        //Invoke callback with the received data
                        onFinishCallback(true, webRequest.downloadHandler.text);
                        break;
                    case UnityWebRequest.Result.ConnectionError:
                    case UnityWebRequest.Result.ProtocolError:
                    case UnityWebRequest.Result.DataProcessingError:
                        //Error handling
                        _eventBus.Publish(GameplayEvent.Error, new ErrorEventParams(webRequest.error));
                        Debug.LogError("get request error: " + webRequest.error);
                        break;
                }
            }
        }
    }
}