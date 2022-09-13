const string DB_FILE_NAME = "db.json";

var rootDirectory = Directory.GetCurrentDirectory();
Console.WriteLine($"Root Directory: {rootDirectory}");

var rootDbFiles = Directory.GetFiles(rootDirectory, "db.json");

if (rootDbFiles.Length > 1)
    Console.WriteLine("Mais de um arquivo db.json foi encontrado");

using var streamReader = new StreamReader(DB_FILE_NAME);

var jsonFileString = streamReader.ReadToEnd();

Console.WriteLine($"Arquivo lido: {jsonFileString}");