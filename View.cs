// ---------------------------------------------------------------------------------------
//                                   Hackolade.Model
//                        Copyright (c) 2026 Cepheis Ltd
//                                    www.cepheis.com
//
// This file is part of Hiperspace and is distributed under the GPL Open Source License. 
// ---------------------------------------------------------------------------------------
using System.Text.Json.Serialization;

namespace Hackolade.Model;

public sealed class View : BaseModel
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; }

    [JsonPropertyName("properties")]
    public List<ViewProperty> Properties { get; set; } = new();

    [JsonPropertyName("isActivated")]
    public bool IsActivated { get; set; }

    [JsonPropertyName("pipeline")]
    public string? Pipeline { get; set; }

    [JsonPropertyName("viewOn")]
    public string? ViewOn { get; set; }

    [JsonPropertyName("bucketId")]
    public string? BucketId { get; set; }

    [JsonPropertyName("hackoladeMeta")]
    public HackoladeMeta HackoladeMeta { get; set; } = new();
    public void Link(Root root)
    {
        Root = root;
        root.Content.Add(Guid, this);
    }
}
