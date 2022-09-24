using System.Text.Json;
using MyMocker.Models;

namespace MyMocker.Cli;

public static class JsonMapper
{
    public static Resources UsingJsonElement(string jsonString)
    {
        var jsonElement = JsonSerializer.Deserialize<JsonElement>(jsonString);
        return FromJsonElement(jsonElement);
    }
    private static Resources FromJsonElement(JsonElement jsonElement)
    {
        var resources = new Resources();
        var resourcesJson = jsonElement
            .GetProperty(Resources.JsonPropertyName)
            .EnumerateArray();
        
        foreach (var resourceJson in resourcesJson)
        {
            var routes = new Routes();
            var entities = new Entities();
            var name = resourceJson.GetProperty("name").GetString();
            var routesJson = resourceJson.GetProperty("routes").EnumerateArray();

            foreach (var routeJson in routesJson)
            {
                var verb = routeJson.GetProperty("verb").GetString();
                var path = routeJson.GetProperty("path").GetString();

                routes.Add(new Route(verb, path));
            }

            var entitiesJson = resourceJson.GetProperty("entities").EnumerateArray();

            foreach (var entityJson in entitiesJson)
            {
                var entity = new Entity() { Json = entityJson };
                entities.Add(entity);
            }

            var resource = new Resource(name, routes, entities);
            resources.Add(resource);
        }

        return resources;
    }
}