namespace MyMocker.Models;

public class Resource 
{
    public string Name { get; init; }
    public Routes Routes { get; init; }
    public Entities Entities { get; set; }

    public Resource(string name, Routes routes, Entities entities) =>
        (Name, Routes, Entities) = (name, routes, entities);
}

public class Resources : List<Resource> 
{
    public const string JsonPropertyName = "resources";
}