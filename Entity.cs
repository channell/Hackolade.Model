// ---------------------------------------------------------------------------------------
//                                   Hackolade.Model
//
// This file is part of Hiperspace and is distributed under the GPL Open Source License. 
// ---------------------------------------------------------------------------------------
using System.Text.Json.Serialization;

namespace Hackolade.Model;

public sealed class Entity : BaseModel
{
    [JsonPropertyName("collectionName")]
    public string? CollectionName { get; set; }

    [JsonPropertyName("properties")]
    public List<Attribute>? Attributes { get; set; }

    [JsonPropertyName("definitions")]
    public Definitions? Definitions { get; set; }

    [JsonPropertyName("isActivated")]
    public bool? IsActivated { get; set; } = true;

    public void Link(Root root)
    {
        Root = root;
        Definitions?.Link(root);
        Attributes?.ForEach(p => p.Link(root, this));
        if (Guid is not null) root.Content.Add(Guid.Value, this);
    }

    [JsonIgnore]
    public IEnumerable<Relationship> Relations =>
        from item in Root?.Content
        let relation = item.Value as Relationship
        where relation is not null &&
              relation.ParentCollection == Guid
        select relation;

}