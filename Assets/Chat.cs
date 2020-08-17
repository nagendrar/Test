using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using Newtonsoft.Json;

[Serializable]
public class ChatList
{
    public string key;
    public List<string> values = new List<string>();
}

[Serializable]
public class ChatBotData
{
   public List<ChatList> chatlist = new List<ChatList>();
   public  Dictionary<string, object> AuthorList = new Dictionary<string, object>();
}

public class Chat : MonoBehaviour
{
    private ChatBotData CreateSaveJsonData()
    {
        ChatBotData c = new ChatBotData();

        c.chatlist.Add(new ChatList());
        c.chatlist.Add(new ChatList());

        c.chatlist[0].key = "Nagendra";
        c.chatlist[1].key = "Satwik";
      
        c.chatlist[0].values.Add("");
        c.chatlist[0].values.Add("");
        c.chatlist[1].values.Add("");
        c.chatlist[1].values.Add("");

        c.chatlist[0].values[0] = "module1";
        c.chatlist[0].values[1] = "module2";
        c.chatlist[1].values[0] = "module1";
        c.chatlist[1].values[1] = "module2";

        c.AuthorList.Add(c.chatlist[0].key, c.chatlist[0].values);
        c.AuthorList.Add(c.chatlist[1].key, c.chatlist[1].values);
        return c;
    }

    private void Start()
    {
        Debug.Log(Application.persistentDataPath);
        ChatBotData save = CreateSaveJsonData();
        string json = JsonUtility.ToJson(save);
        File.WriteAllText(Application.persistentDataPath + "/" + "Nagendra" + ".json", json);
        GetChatFromBot();
    }

    public void GetChatFromBot()
    {
        ChatBotData galleryId = JsonConvert.DeserializeObject<ChatBotData>(File.ReadAllText(Application.persistentDataPath + "/" + "Nagendra" + ".json"));
        string j = JsonUtility.ToJson(galleryId);
        ChatBotData userdata = JsonUtility.FromJson<ChatBotData>(j);

        Debug.Log(userdata.chatlist[1].key); 
    }
}

