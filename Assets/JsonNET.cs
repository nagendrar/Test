using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using Newtonsoft.Json;
using System;
using System.Text;
using System.Linq;

public class JsonNET : MonoBehaviour
{
    //http://54.72.30.148:9090/abis-tech5/api/gatewaydemo/request/identification
    public string jsonURL;
    public string token;

    public string requestGUID;
    public string facedatas;
    string galleryphoto;

    public Text errorreport;
    public Text stat;
    public Text respon;
    public Text responStat;
    public Text galleryID;
    public Text matchScore;
    public Text personName;
    public Text personGender;
    public Text personDOB;
   
    public void sendrequest()
    {
        StartCoroutine(faceJson());

        Invoke("GetImage", 2.2f);
    }

    IEnumerator faceJson()
    {
        tojson mydata = new tojson();
        mydata.requestId = requestGUID;
        mydata.faceData = facedatas;
        string json = JsonUtility.ToJson(mydata);

        //Contacting Server
        var request = new UnityWebRequest(jsonURL, "POST");
        byte[] bodyRaw = Encoding.UTF8.GetBytes(json);
        request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();

        //Headers Setup
        request.SetRequestHeader("Content-Type", "application/json");
        request.SetRequestHeader("Accept", "application/json;charset=utf-8");
        request.SetRequestHeader("Authorization", "Bearer " + token);

        yield return request.SendWebRequest();
        Debug.Log("Status Code: " + request.responseCode);
        Debug.Log("Status Code: " + request.downloadHandler.text);
        

        if (request.isNetworkError || request.isHttpError)
        {
            Debug.Log(request.error);
            errorreport.text = request.error;
        }
        else
        {            
            JsonClass galleryId = JsonConvert.DeserializeObject<JsonClass>(request.downloadHandler.text);
            string j = JsonUtility.ToJson(galleryId);
            JsonClass userdata = JsonUtility.FromJson<JsonClass>(j);

            stat.text = userdata.status.ToString();
            respon.text = userdata.responseText;
            responStat.text = userdata.responseStatus;

            galleryID.text = "ID :" + userdata.matches[0].galleryId.ToString();
            matchScore.text = "MatchScore :" + Math.Round(userdata.matches[0].matchscore, 2).ToString();

            personName.text = "Name :" + userdata.matches[0].details.name;
            personGender.text = "Gender :" + userdata.matches[0].details.gender;
            personDOB.text = "DOB :" + userdata.matches[0].details.dob;
            galleryphoto = userdata.matches[0].galleryPhoto;
            Debug.Log(galleryphoto);
            GetGalleryImage();
        }
    }

    public RawImage Galleryimg;

    public void GetGalleryImage()
    {
        Texture2D tex = new Texture2D(1, 1);

        byte[] decodedBytes = Convert.FromBase64String(galleryphoto);
        string decodedText = Encoding.UTF8.GetString(decodedBytes);
        tex.LoadImage(decodedBytes);

        // Instantiated object
        Galleryimg.texture = tex;
    }

    [Serializable]
    public class tojson
    {
        public string requestId;
        public string faceData;
    }

    public RawImage img;
    public void GetImage()
    {
        Texture2D tex = new Texture2D(1, 1);

        byte[] decodedBytes = Convert.FromBase64String(facedatas);
        string decodedText = Encoding.UTF8.GetString(decodedBytes);
        tex.LoadImage(decodedBytes);

        // Instantiated object
        img.texture = tex;
    }
}
