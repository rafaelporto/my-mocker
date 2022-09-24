using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyMocker.Models;

namespace MyMocker.Server;
public class MockServer
{
    private readonly Resources _resources;
    private WebApplication _server;

    public MockServer(Resources resources)
    {
        this._resources = resources ??
                            throw new ArgumentNullException(nameof(resources));
    }

   public void Start()
    {
        var builder = WebApplication.CreateBuilder();

        // Add services to the container.
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var server = builder.Build();

        // Configure the HTTP request pipeline.
        if (server.Environment.IsDevelopment())
        {
            server.UseSwagger();
            server.UseSwaggerUI();
        }

        server.MapGet("/resources", () =>
        {
            return _resources;
        })
        .WithName("GetResources");

        server.Run();
    }

    public Task Stop() => _server.StopAsync();
}
