using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
using App;
using Shared;

static void IgnoreNegativeValues(JsonTypeInfo typeInfo)
{
    if (typeInfo.Type != typeof(A))
        return;

    foreach (JsonPropertyInfo propertyInfo in typeInfo.Properties)
    {
        if (propertyInfo.PropertyType == typeof(int))
        {
            propertyInfo.ShouldSerialize = static (obj, value) =>
                (int)value! >= 0;
        }
    }
}

var jsonSerializerOptions = new JsonSerializerOptions
{
    Converters = {new TweakedPolymorphicJsonConverter<BObject>()},
    WriteIndented = true,
    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault,
    TypeInfoResolver = new DefaultJsonTypeInfoResolver
    {
        Modifiers = { IgnoreNegativeValues }
    }
};

Console.WriteLine("Serialized:");
var RunningStaion = new BObject[] { new A(-1, 2), new B(-3, 4), new C(100, 200,new A(44,67)), new A(1, 2) };
Console.WriteLine(JsonSerializer.Serialize(
   RunningStaion, jsonSerializerOptions));

Console.WriteLine();

using var jsonSample = File.OpenRead("sample.json");
var deserialized = JsonSerializer.Deserialize<IReadOnlyCollection<BObject>>(jsonSample, jsonSerializerOptions)!;
Console.WriteLine("Deserialized:");
Console.WriteLine(JsonSerializer.Serialize(
   deserialized, jsonSerializerOptions));