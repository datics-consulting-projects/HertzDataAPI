namespace _50HertzDataAPI;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Measurement
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    [BsonElement("timestamp")]
    public DateTime Timestamp { get; set; }

    [BsonElement("value")]
    public double Value { get; set; }

    [BsonElement("unit")]
    public string Unit { get; set; }
}
