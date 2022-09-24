namespace MyMocker.Models;

public class Route
{
    public HttpMethod Verb { get; init; }
    public string Path { get; init; }

    public Route(string verb, string path) =>
        (Verb, Path) = (new HttpMethod(verb), path);
}

public class Routes : List<Route> 
{
    public const string JsonPropertyName = "routes";
}