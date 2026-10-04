// ---------------------------------------------------------------------------------------
//                                   Hackolade.Model
//
// This file is part of Hiperspace and is distributed under the GPL Open Source License. 
// ---------------------------------------------------------------------------------------
using System.Text.Json.Serialization;

namespace Hackolade.Model;

public sealed class Definitions : BaseModel
{
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    [JsonPropertyName("properties")]
    public List<Attribute>? Properties { get; set; }
    public void Link(Root root)
    {
        Root = root;
        Properties?.ForEach(p => p.Link(root, null));
        if (Guid is not null) root.Content.Add(Guid.Value, this);
    }
}