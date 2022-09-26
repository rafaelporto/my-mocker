using System.Text.Json;
using CSharpFunctionalExtensions;
using MyMocker.Models;
using Entity = MyMocker.Models.Entity;

namespace MyMocker.Core;

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
            var resource = MapResource(resourceJson);

            if (resource.HasValue)
                resources.Add(resource.Value);
        }

        return resources;
    }

    internal static Maybe<Resource> MapResource(JsonElement resourceJson)
    {
        if (resourceJson.TryGetProperty("name", out var nameJson) is false)
            throw new ResourceNameNotFoundException("Resource name not found");
        
        var name = nameJson.GetString();
        if (string.IsNullOrWhiteSpace(name))
            throw new ResourceNameNotFoundException("Resource name not found");

        var routes = new Routes();
        var entities = new Entities();

        if (resourceJson.TryGetProperty("routes", out var routePropertyJson) is false)
            return Maybe<Resource>.None;

        var routesJson = routePropertyJson.EnumerateArray();
        
        foreach (var routeJson in routesJson)
            routes.Add(MapRoute(name, routeJson));

        if (resourceJson.TryGetProperty("entities", out var entitiesPropertyJson))
        {
            var entitiesJson = entitiesPropertyJson.EnumerateArray();
            foreach (var entityJson in entitiesJson)
            {
                var entity = new Entity() { Json = entityJson };
                entities.Add(entity);
            }
        }

        var resource = new Resource(name, routes, entities);
        return resource;
    }

    internal static Route MapRoute(string resourceName, JsonElement routeJson)
    {
        var verb = MapVerb(resourceName, routeJson);
        var path = MapPath(resourceName, verb, routeJson);
        
        return new Route(verb, path);
    }

    internal static Method MapVerb(string resourceName, JsonElement routeJson)
    {
        if (routeJson.TryGetProperty("verb", out var verbJson) is false)
            throw new VerbNotFoundException($"Verb not found at Resource: {resourceName}");

        var verb = verbJson.GetString();

        if (string.IsNullOrWhiteSpace(verb))
            throw new InvalidVerbException($"Verb can not be null or empty at Resource: {resourceName}");

        return new Method(verb);
    }
    
    internal static string MapPath(string resourceName, string verb, JsonElement routeJson)
    {
        if(routeJson.TryGetProperty("path", out var pathJson) is false)
            throw new PathNotFoundException($"Path not found at Resource: {resourceName} for Verb: {verb}");
        
        var path = pathJson.GetString();
        
        if (string.IsNullOrWhiteSpace(path))
            throw new InvalidPathException($"Path can not be null or empty at Resource: {resourceName} for Verb: {verb}");

        return path;
    }
}