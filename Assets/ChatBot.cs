using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatBot : MonoBehaviour
{
    Dictionary<string, object> AuthorList = new Dictionary<string, object>();

    public string[] array1, array2, array3, array4, array5;

    public string BotText;
    // Start is called before the first frame update
    void Start()
    {
        AuthorList.Add("module Chand", array1);
        AuthorList.Add("module Gold", array2);
        AuthorList.Add("Praveen Kumar", array3);
        AuthorList.Add("Raj Beniwal", array4);
        AuthorList.Add("Dinesh Beniwal", array5);

        //Dictionary<string, object>.KeyCollection keys = AuthorList.Keys;
        foreach (KeyValuePair<string, object> author in AuthorList)
        {
            Debug.Log(string.Format("Key: {0}, Value: {1}",author.Key, (author.Value)));

            if(author.Key.Contains(BotText))
            {
                string[] s = (string[])author.Value;
                Debug.Log(s[UnityEngine.Random.Range(0, s.Length)]);
            }          
        }
    }
}
