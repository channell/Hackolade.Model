// ---------------------------------------------------------------------------------------
//                                   Hackolade.Model
//
// This file is part of Hiperspace and is distributed under the GPL Open Source License. 
// ---------------------------------------------------------------------------------------
using System.Text.Json.Serialization;

public sealed class ViewProperty
{
    [JsonPropertyName("GUID")]
    public Guid? Guid { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("ref")]
    public string? Ref { get; set; }

    [JsonPropertyName("reftype")]
    public string? RefType { get; set; }

    [JsonPropertyName("refIdPath")]
    public List<string> RefIdPath { get; set; } = new();

    [JsonPropertyName("$ref")]
    public string? JsonReference { get; set; }

    [JsonPropertyName("isActivated")]
    public bool IsActivated { get; set; }

    [JsonPropertyName("hackoladeMeta")]
    public HackoladeMeta HackoladeMeta { get; set; } = new();

    [JsonPropertyName("error")]
    public Dictionary<string, object?> Error { get; set; } = new();
}
