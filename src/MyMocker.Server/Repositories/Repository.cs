using System.Text.Json;
using Microsoft.Extensions.Logging;
using MyMocker.Core;
using MyMocker.Models;

namespace MyMocker.Server;

public interface IRepository
{
    IEnumerable<JsonElement> Get(string resourceName, params string[] fieldValue);
}

public class Repository : IRepository
{
    private readonly Resources _resources;

    public Repository(Resources resources) => _resources = resources;

    public IEnumerable<JsonElement> Get(string resourceName, params string[] fieldValue)
    {
        var resource = _resources.Where(p => p.Name == resourceName).FirstOrDefault();

        if (resource is null)
            throw new ResourceNotFoundException($"Resource {resourceName} not found.");

        foreach (var entity in resource.Entities)
            yield return entity.Json;
    }
}