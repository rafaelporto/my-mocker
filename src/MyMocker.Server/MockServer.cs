using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using MyMocker.Models;

namespace MyMocker.Server;
public class MockServer
{
    private readonly Resources _resources;
    private WebApplication? _server;

    public MockServer(Resources resources)
    {
        this._resources = resources ??
                            throw new ArgumentNullException(nameof(resources));
        this._server = null;
    }

   public void Start()
    {
        var builder = WebApplication.CreateBuilder();

        builder.Services.AddServices(_resources);

        _server = builder.Build();

        // Configure the HTTP request pipeline.
        if (_server.Environment.IsDevelopment())
        {
            _server.UseSwagger();
            _server.UseSwaggerUI(setup =>
            {
                setup.RoutePrefix = string.Empty;
                setup.SwaggerEndpoint("/swagger/v1/swagger.json", "My mocker");
            });
        }

        _server.MapGet("/resources", () =>
        {
            return _resources;
        })
        .WithName("GetResources");

        _server.MapEndpoints(_resources);

        _server.Run();
    }

    public Task Stop() =>
         _server is null 
         ? Task.CompletedTask
         : _server.StopAsync();
}
