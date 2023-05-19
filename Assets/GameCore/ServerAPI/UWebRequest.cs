using System;
using System.Collections;
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
        
        //test
        public void GetRequest(string uri, Action<bool, string> onFinishCallback)
        {
            //StartCoroutine(GetRequestEnum("https://parana-unity-test.s3.amazonaws.com/tournament-details/dab1bbcf-bd41-4c9c-b0c5-2af05dac9f4d.json", onFinishCallback));
            StartCoroutine(GetRequestEnum(uri, onFinishCallback));
        }
        
        /*IEnumerator RunIt(string uri)
        {
            Debug.Log("ye");
            using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
            {
                yield return webRequest.SendWebRequest();
                switch (webRequest.result)
                {
                    case UnityWebRequest.Result.Success:
                        var result = webRequest.downloadHandler.text;
                        break;
                    case UnityWebRequest.Result.ConnectionError:
                    case UnityWebRequest.Result.ProtocolError:
                    case UnityWebRequest.Result.DataProcessingError:
                        //Handle errors here
                        //TODO: add an error popup here
                        Debug.LogError("get request error: " + webRequest.error);
                        break;
                }
            }
        }*/

        public IEnumerator GetRequestEnum(string uri, Action<bool, string> onFinishCallback)
        {
            using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
            {
                yield return webRequest.SendWebRequest();
                switch (webRequest.result)
                {
                    case UnityWebRequest.Result.Success:
                        onFinishCallback(true, webRequest.downloadHandler.text);
                        break;
                    case UnityWebRequest.Result.ConnectionError:
                    case UnityWebRequest.Result.ProtocolError:
                    case UnityWebRequest.Result.DataProcessingError:
                        //Handle errors here
                        //TODO: add an error popup here
                        Debug.LogError("get request error: " + webRequest.error);
                        break;
                }
            }
        }
    }
}