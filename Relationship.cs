// ---------------------------------------------------------------------------------------
//                                   Hackolade.Model
//                        Copyright (c) 2026 Cepheis Ltd
//                                    www.cepheis.com
//
// This file is part of Hiperspace and is distributed under the GPL Open Source License. 
// ---------------------------------------------------------------------------------------
using System.Text.Json.Serialization;

namespace Hackolade.Model;

public sealed class Relationship : BaseModel
{
    const string Link = "Link Relationship ";

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

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("comments")]
    public string? Comments { get; set; }

    [JsonIgnore]
    public Entity? Parent => Root?.Content[ParentCollection ?? default] as Entity;

    [JsonIgnore]
    public Entity? Child => Root?.Content[ChildCollection ?? default] as Entity;

    public Relationship() { }

    /// <summary>
    /// Create a relationship between two entities using keys
    /// </summary>
    /// <param name="parent"></param>
    /// <param name="child"></param>
    /// <param name="keys"></param>
    /// <param name="name"></param>
    public Relationship
        ( Entity parent
        , Entity child
        , List<(Attribute parent, Attribute child)> keys
        , string? name) 
    {
        Guid = Guid.NewGuid();

        ParentCollection = parent.Guid;
        ChildCollection = child.Guid;
        foreach (var key in keys)
        {
            key.parent.ForeignCollection = ChildCollection;

            if (key.parent.ChildRelationships is null) key.parent.ChildRelationships = new List<Guid>();
            key.parent.ChildRelationships.Add(Guid);

            key.child.ParentRelationship = Guid;
            key.child.ForeignCollection = parent.Guid;
            key.child.ForeignField = [parent.Guid, key.parent.Guid];
            key.child.RelationshipType = ForeignKey;
        }
    }

    /// <summary>
    /// Delete this relationship, and update orphaned relations
    /// </summary>
    public void Delete()
    {
        if (ParentField is not null)
        {
            foreach (var pair in ParentField)
            {
                if (pair is not null)
                {
                    var field = Root?.Content[pair.Last()] as Attribute;
                    field?.ChildRelationships?.Remove(Guid);
                }
            }
        }
        if (ChildField is not null)
        {
            foreach (var pair in ChildField)
            {
                if (pair is not null)
                {
                    var field = Root?.Content[pair.Last()] as Attribute;
                    if (field is not null)
                    {
                        if (field.ParentRelationship is Guid) field.ParentRelationship = default;
                        if (ParentCollection is not null && field.ForeignCollection == ParentCollection.Value)
                        { 
                            field.ForeignCollection = default;
                            field.ForeignField = default;
                        }
                    }
                }
            }
        }
    }

    public const string ForeignKey = "Foreign Key";

    public void Link(Root root)
    {
        Root = root;
        HackoladeStyles?.Link(root);
        root.Content.Add(Guid, this);
    }
}