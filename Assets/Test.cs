using System;
using UnityEngine;
using UnityEngine.UI;
using System.Net.Mail;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.IO.Compression;
using System.IO;
using MongoDB.Driver;
using MongoDB.Bson;

public class Test : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        MongoClient dbClient = new MongoClient("mongodb+srv://cjlohith:cjlohith@cluster0-5mb5p.mongodb.net/test?retryWrites=true&w=majority");

        var dbList = dbClient.ListDatabases().ToList();

        Debug.Log("The list of databases on this server is: ");
        foreach (var db in dbList)
        {          
            Debug.Log(db.AsBsonDocument);
        }
        var database = dbClient.GetDatabase("test");
        var playercollection = database.GetCollection<BsonDocument>("employees");
        playercollection.InsertOne(new BsonDocument{
            { "level", 7 },
            { "name", "Fabi" },
            { "scores", 4711 },
            { "email", "ff023@hdm-s.de" }
        });
    }

    //To SEND MAIL
    public void SendMail()
    {
        MailMessage m = new MailMessage();

        m.From = new MailAddress("ravillanagendra@gmail.com");
        m.To.Add("ravillanagendra@gmail.com");
        m.Subject = "HI";
        m.Body = "Hello Nagendra";
        Attachment data = new Attachment(@"D:\TestImages\1.jpg", System.Net.Mime.MediaTypeNames.Image.Jpeg);
        m.Attachments.Add(data);

        SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
        smtpServer.Port = 587;
        smtpServer.Credentials = new NetworkCredential("ravillanagendra@gmail.com", "nxko ftga qrwb fmlu");
        smtpServer.EnableSsl = true;
        ServicePointManager.ServerCertificateValidationCallback =
            delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
            {
                return true;
            };
        try
        {
            smtpServer.Send(m);
        }
        catch (Exception e)
        {
            Debug.Log(e.GetBaseException());
        }
    }

    public class students
    {
        public string Name;
        public float sizeonDisk;
        public bool empty;
    }
}

