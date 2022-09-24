using System.Text.Json;

namespace MyMocker.Cli;

public class Entity 
{
    public JsonElement Json { get; set; }
}

public class Entities : List<Entity> 
{
    public const string JsonPropertyName = "entities";
}