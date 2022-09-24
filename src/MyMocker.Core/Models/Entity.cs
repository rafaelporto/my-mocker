using System.Text.Json;

namespace MyMocker.Models;

public class Entity 
{
    public JsonElement Json { get; set; }
}

public class Entities : List<Entity> 
{
    public const string JsonPropertyName = "entities";
}