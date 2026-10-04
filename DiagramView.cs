// ---------------------------------------------------------------------------------------
//                                   Hackolade.Model
//
// This file is part of Hiperspace and is distributed under the GPL Open Source License. 
// ---------------------------------------------------------------------------------------
using System.Text.Json.Serialization;

namespace Hackolade.Model;

public sealed class DiagramView : BaseModel
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("entities")]
    public List<string>? Entities { get; set; }
    public void Link(Root root)
    {
        Root = root;
        if (Guid is not null) root.Content.Add(Guid.Value, this);
    }
}