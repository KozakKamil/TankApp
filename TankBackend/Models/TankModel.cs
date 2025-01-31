using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TankBackend.Models;

public class TankModel
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    [BsonElement("TankName")]
    public string? TankName { get; set; }
    public string? Weight { get; set; }
    public string? TankType { get; set; }
    public string? TankCountry { get; set; }
    public string? Weapon { get; set; }
    public string? Engine { get; set; }
    public string? MaxSpeed { get; set; }
    public string? Range { get; set; }
    public string? Armor { get; set; }
    public string? EnginePower { get; set; }
    public string? Crew { get; set; }
    public string? Image { get; set; }
}

