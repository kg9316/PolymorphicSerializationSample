using System.Text.Json;
using App;
using Shared;

var jsonSerializerOptions = new JsonSerializerOptions
{
    Converters = {new TweakedPolymorphicJsonConverter<HierarchyRoot>()},
    //PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
    WriteIndented = true
};

Console.WriteLine("Serialized:");
var jj = new HierarchyRoot[] { new A(1, 2), new B(3, 4), new C(100, 200,new A(44,67)), new A(1, 2) };
Console.WriteLine(JsonSerializer.Serialize(
   jj,    jsonSerializerOptions));

Console.WriteLine();

using var jsonSample = File.OpenRead("sample.json");
var deserialized = JsonSerializer.Deserialize<IReadOnlyCollection<HierarchyRoot>>(jsonSample, jsonSerializerOptions)!;
Console.WriteLine("Deserialized:");
Console.WriteLine(JsonSerializer.Serialize(
   deserialized, jsonSerializerOptions));