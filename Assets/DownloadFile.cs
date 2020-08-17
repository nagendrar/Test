using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

public class DownloadFile : MonoBehaviour
{
    //IEnumerator Start()
    //{
    //    string url = "https://s3.console.aws.amazon.com/s3/buckets/activae3iq/Module/Module/?region=us-east-2";
    //    Debug.Log(Application.persistentDataPath);
        void Start()
        {
            StartCoroutine(Download());
        }

        IEnumerator Download()
        {
            var uwr = new UnityWebRequest("http://unity3d.com/");
            uwr.method = UnityWebRequest.kHttpVerbGET;
            var resultFile = Path.Combine(Application.persistentDataPath, "result.txt");
            var dh = new DownloadHandlerFile(resultFile);
            dh.removeFileOnAbort = true;
            uwr.downloadHandler = dh;
            yield return uwr.Send();
            if (uwr.isNetworkError || uwr.isHttpError)
                Debug.Log(uwr.error);
            else
            {
                Debug.Log("Download saved to: " + resultFile);
            }
        }
    }
