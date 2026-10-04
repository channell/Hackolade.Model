// ---------------------------------------------------------------------------------------
//                                   Hackolade.Model
//
// This file is part of Hiperspace and is distributed under the GPL Open Source License. 
// ---------------------------------------------------------------------------------------
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Hackolade.Model;

public sealed class Root
{
    #region state
    [JsonPropertyName("GUID")]
    public System.Guid? Guid { get; set; }

    [JsonExtensionData]
    public Dictionary<string, JsonElement>? AdditionalData { get; set; }

    [JsonPropertyName("modelName")]
    public string? ModelName { get; set; }

    [JsonPropertyName("collections")]
    public List<Entity>? Entities { get; set; }

    [JsonPropertyName("buckets")]
    public List<Bucket>? Buckets { get; set; }

    [JsonPropertyName("views")]
    public List<View>? Views { get; set; }

    [JsonPropertyName("relationships")]
    public List<Relationship>? Relationships { get; set; }

    [JsonPropertyName("users")]
    public List<JsonElement>? Users { get; set; }

    [JsonPropertyName("diagramViews")]
    public List<DiagramView>? DiagramViews { get; set; }

    [JsonPropertyName("idToNameHashTable")]
    public Dictionary<string, string>? IdToNameHashTable { get; set; }

    [JsonPropertyName("definitions")]
    public Definitions? Definitions { get; set; }

    [JsonPropertyName("polyglotDefinitions")]
    public Definitions? PolyglotDefinitions { get; set; }

    [JsonPropertyName("externalDefinitions")]
    public Definitions? ExternalDefinitions { get; set; }

    [JsonPropertyName("sources")]
    public List<JsonElement>? Sources { get; set; }

    [JsonPropertyName("decorativeSymbols")]
    public List<DecorativeSymbol>? DecorativeSymbols { get; set; }

    [JsonPropertyName("businessGlossaries")]
    public List<JsonElement>? BusinessGlossaries { get; set; }

    [JsonPropertyName("businessGlossaryTerms")]
    public List<JsonElement>? BusinessGlossaryTerms { get; set; }

    #endregion

    [JsonIgnore]
    public Dictionary<Guid, BaseModel> Content { get; } = new Dictionary<Guid, BaseModel>();


    public static Root? Open(string path)
    {
        if (!Path.Exists(path)) throw new FileNotFoundException($"File {path} could not be found");
        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
            DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
        };

        var inputJson = File.ReadAllText(path);
        var model = JsonSerializer.Deserialize<Root>(inputJson, options);
        model?.Link();
        return model;
    }
    public void Save(string path)
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
            DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
        };
        var outputJson = JsonSerializer.Serialize(this, options);
        File.WriteAllText(path, outputJson);
    }

    private void Link()
    {
        Entities?.ForEach(p => p.Link(this));
        Buckets?.ForEach(p => p.Link(this));
        Views?.ForEach(p => p.Link(this));
        Relationships?.ForEach(p => p.Link(this));
        DiagramViews?.ForEach(p => p.Link(this));
        Definitions?.Link(this);
        PolyglotDefinitions?.Link(this);
        ExternalDefinitions?.Link(this);
        DecorativeSymbols?.ForEach(p => p.Link(this));
    }
}