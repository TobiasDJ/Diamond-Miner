
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
public class HiscoreModel
{
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    [BsonElement("name")]    public string Name { get; set; }

    [BsonElement("score")]
    public int Score { get; set; }

    [BsonConstructor]
    public HiscoreModel(string name, int score)
    {
        Score = score;
        Name = name;
    }

}