namespace MyMocker.Models;

public record struct RouteParameter
{
    public readonly string Name;
    public readonly object? DefaultValue;
    public readonly string[] Constraints;

    public RouteParameter(string name, object? defaultValue = null, string[]? constraints = null)
    {
        Name = name;
        DefaultValue = defaultValue;
        Constraints = constraints ?? Array.Empty<string>();
    }
}