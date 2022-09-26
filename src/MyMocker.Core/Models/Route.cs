using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Routing.Template;

namespace MyMocker.Models;

public class Route
{
    public Method Verb { get; init; }
    public string Path { get; init; }
    internal RouteTemplate ParsedTemplate { get; private set; }

    public Route(string verb, string path)
    {
        (Verb, Path) = (new Method(verb), path);

        try
        {
            ParsedTemplate = TemplateParser.Parse(path);
        }
        catch (Exception exception)
        {
            throw new RouteCreationException($"Failed to create route for Verb: {verb}, Path: {path}", exception);
        }
    }

    public Maybe<RouteParameter> GetParameter(string parameterName)
    {
        var parameter = ParsedTemplate.GetParameter(parameterName);
        
        if (parameter is null)
            return Maybe.None;
        
        var constraints = parameter.InlineConstraints.Select(p => p.Constraint).ToArray();
        var routeParameter = new RouteParameter(parameter.Name, parameter.DefaultValue, constraints);

        return Maybe.From<RouteParameter>(routeParameter);
    }
}

public class Routes : List<Route> 
{
    public const string JsonPropertyName = "routes";
}