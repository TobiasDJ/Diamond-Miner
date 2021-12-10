using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MongoDB.Driver;
using MongoDB;
using MongoDB.Bson;
using Debug = UnityEngine.Debug;
using Random = UnityEngine.Random;

public class MongoDbStorage : MonoBehaviour
{

    // Start is called before the first frame update

    private MongoClient dbClient;
    private IMongoDatabase db;

    public MongoDbStorage(){
        dbClient = new MongoClient("mongodb://root:example@62.107.0.222:27017");
        db = dbClient.GetDatabase("diamondminer");
    }


    public List<HiscoreModel> FetchTop15Scores(){
        var ranks = db.GetCollection<HiscoreModel>("ranks");

        var list = ranks.Find(FilterDefinition<HiscoreModel>.Empty ).Limit(15).SortBy(i=> i.Score).ToList();

        return list;
    }

    public void AddOrUpdate(HiscoreModel modelToAdd){

        var ranks = db.GetCollection<HiscoreModel>("ranks");
        bool exists = ranks.Find(_ => _.Name == modelToAdd.Name).Any();

        if(exists){
            Debug.Log("Player exits - Updating");
            var filter = Builders<HiscoreModel>.Filter.Eq("name", modelToAdd.Name);
            HiscoreModel model = ranks.Find(filter).Limit(1).ToList()[0];
            if(modelToAdd.Score > model.Score ){
                var filter2 = Builders<HiscoreModel>.Filter.Eq("name", modelToAdd.Name);
                var update = Builders<HiscoreModel>.Update.Set("score", modelToAdd.Score);
                var updateOptions = new UpdateOptions()
                {
                    IsUpsert = true
                };
                var updateResult = ranks.UpdateOne(filter2, update, updateOptions);
            }
        }
        else
        {   
                var ranksDocs = db.GetCollection<BsonDocument>("ranks");
                ranksDocs.InsertOne(ModelToBsonDocument(modelToAdd));
        }
    }
    

    public void GerneateTestDatabase(){
      
        var ranks = db.GetCollection<BsonDocument>("ranks");
        
        var models = GenerateData();
        ranks.InsertMany(models);
    }

   private List<BsonDocument> GenerateData(){
        
        List<BsonDocument> models = new List<BsonDocument>();

       string[] names = {"peter", "John", "William", "James", "Charles",
                              "George", "Frank", "Joseph", "Thomas", "Henry",
                              "Robert", "Edward", "Harry", "Walter", "Arthur", 
                              "Fred", "Albert","Samuel", "David", "Louis", "Joe", 
                              "Charlie","Clarence"};
        
        for(int i = 0; i<names.Length; i++){
            
            int rank = i + 1;
            int score = Random.Range(0,10000);

            var model = new HiscoreModel(names[i], score);
            models.Add(ModelToBsonDocument(model));
        }
        return models;
    }

    private BsonDocument ModelToBsonDocument(HiscoreModel model){
        var doc = new BsonDocument
        {
            {"name", model.Name},
            {"score", model.Score}
        };
        return doc;
    }

}
