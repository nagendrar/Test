using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using MongoDB.Bson;

public class MongoTest : MonoBehaviour
{
    IMongoDatabase database;
    IMongoCollection<BsonDocument> playercollection;

    // Start is called before the first frame update
    void Start()
    {
        MongoClient dbClient = new MongoClient("mongodb+srv://cjlohith:cjlohith@cluster0-5mb5p.mongodb.net/test?retryWrites=true&w=majority");

        var dbList = dbClient.ListDatabases().ToList();

        //Debug.Log("The list of databases on this server is: ");
        //foreach (var db in dbList)
        //{
        //    Debug.Log(db);
        //}

         database = dbClient.GetDatabase("test");
         playercollection = database.GetCollection<BsonDocument>("employees");


        //InsertNewDocument();
        //InsertMultipleDocuments();

        //SelectAll();
        //SelectFirstOne();
        SelectFromPlayers();
    }

    //***INSERT***//
    public void InsertNewDocument()
    {
        playercollection.InsertOne(new BsonDocument
        {
            { "name", "Fabi" },
            { "email", "ff023@hdm-s.de" },
            {"password", "123456" }
        });
    }

    public void InsertMultipleDocuments()
    {
        BsonDocument[] batch ={
            
            new BsonDocument{
                { "level", 8},
                { "name", "Vati" },
                { "scores", 1936 },
                { "email", "g@b.b" }
            },

             new BsonDocument{
                { "level", 9},
                { "name", "Vati" },
                { "scores", 1936 },
                { "email", "g@b.a" }
            }
        };
        playercollection.InsertMany(batch, null);
    }

    //***SELECT***//
    public void SelectAll()
    {
        var documents = playercollection.Find(new BsonDocument()).ToList();
        foreach (var document in documents)
        {
            Debug.Log("SELECT ALL DOCS: \n" + document);
        }
    }

    public void SelectFirstOne()
    {
        var firstDocument = playercollection.Find(new BsonDocument()).FirstOrDefault();
        Debug.Log(firstDocument.ToString());
    }

    public void SelectFromPlayers()
    {
        var filter = Builders<BsonDocument>.Filter.Eq("email","g@b.i");
        var studentDocument = playercollection.Find(filter).FirstOrDefault();
        Debug.Log(studentDocument);
    }
}
