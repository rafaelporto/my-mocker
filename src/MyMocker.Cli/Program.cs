using System.Text;
using MyMocker.Cli;
using MyMocker.Server;

var json = File.ReadAllText("appsettings.json", Encoding.UTF8);

var resources = JsonMapper.UsingJsonElement(json);

var server = new MockServer(resources);
server.Start();

Console.CancelKeyPress += (sender, args) => {
    server.Stop().GetAwaiter().GetResult();
};