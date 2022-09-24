using System.Text;
using MyMocker.Cli;

var json = File.ReadAllText("appsettings.json", Encoding.UTF8);

Console.WriteLine($"Json: {json}");

var resources = JsonMapper.UsingJsonElement(json);