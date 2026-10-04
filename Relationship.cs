// ---------------------------------------------------------------------------------------
//                                   Hackolade.Model
//
// This file is part of Hiperspace and is distributed under the GPL Open Source License. 
// ---------------------------------------------------------------------------------------
using System.Text.Json.Serialization;

namespace Hackolade.Model;

public sealed class Relationship : BaseModel
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("relationshipType")]
    public string? RelationshipType { get; set; }

    [JsonPropertyName("hackoladeStyles")]
    public HackoladeStyles? HackoladeStyles { get; set; }

    [JsonPropertyName("isActivated")]
    public bool? IsActivated { get; set; } = true;

    [JsonPropertyName("parentCollection")]
    public Guid? ParentCollection { get; set; }

    [JsonPropertyName("childCollection")]
    public Guid? ChildCollection { get; set; }

    [JsonPropertyName("parentField")]
    public List<List<Guid>>? ParentField { get; set; }

    [JsonPropertyName("parentCardinality")]
    public string? parentCardinality { get; set; }

    [JsonPropertyName("childField")]
    public List<List<Guid>>? ChildField { get; set; }

    [JsonPropertyName("childCardinality")]
    public string? ChildCardinality { get; set; }

    [JsonPropertyName("level")]
    public string? Level { get; set; }

    [JsonPropertyName("lineSize")]
    public string? LineSize { get; set; }

    [JsonPropertyName("hackoladeMeta")]
    public HackoladeMeta HackoladeMeta { get; set; } = new();

    [JsonIgnore]
    public Entity? Parent => Root?.Content[ParentCollection ?? default] as Entity;

    [JsonIgnore]
    public Entity? Child => Root?.Content[ChildCollection ?? default] as Entity;


    public void Link(Root root)
    {
        Root = root;
        HackoladeStyles?.Link(root);
        if (Guid is not null) root.Content.Add(Guid.Value, this);
    }
}