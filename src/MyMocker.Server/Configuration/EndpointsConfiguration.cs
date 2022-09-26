using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using MyMocker.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace MyMocker.Server;
internal static class EndpointsConfiguration
{
    internal static IEndpointRouteBuilder MapEndpoints(this IEndpointRouteBuilder endpoints, Resources resources)
    {
        foreach (var resource in resources)
        {
            foreach (var route in resource.Routes)
            {
               if (route.Verb == Verb.GET)
               {
                    var routePattern = string.Concat(resource.Name, "/", route.Path);
                    endpoints.MapGet(routePattern, (string id, IRepository repository) => repository.Get(resource.Name, id))
                            .WithMetadata(new SwaggerOperationAttribute(resource.Name, "description001"));
               }
            }
        }

        return endpoints;
    }
}