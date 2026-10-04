// ---------------------------------------------------------------------------------------
//                                   Hackolade.Model
//
// This file is part of Hiperspace and is distributed under the GPL Open Source License. 
// ---------------------------------------------------------------------------------------
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Hackolade.Model;

public sealed class Bucket : BaseModel
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; }

    [JsonPropertyName("collectionIds")]
    public List<string>? CollectionIds { get; set; }

    [JsonPropertyName("backgroundColor")]
    public JsonElement? BackgroundColor { get; set; }

    public void Link(Root root)
    {
        Root = root;
        if (Guid is not null) root.Content.Add(Guid.Value, this);
    }
}