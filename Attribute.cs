// ---------------------------------------------------------------------------------------
//                                   Hackolade.Model
//                        Copyright (c) 2026 Cepheis Ltd
//                                    www.cepheis.com
//
// This file is part of Hiperspace and is distributed under the GPL Open Source License. 
// ---------------------------------------------------------------------------------------
using System.Text.Json.Serialization;

namespace Hackolade.Model;

public sealed class Attribute : BaseModel
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; }

    [JsonPropertyName("childType")]
    public string? ChildType { get; set; }

    [JsonPropertyName("required")]
    public bool? Required { get; set; }

    [JsonPropertyName("primaryKey")]
    public bool? PrimaryKey { get; set; }

    [JsonPropertyName("compositePrimaryKey")]
    public bool? CompositePrimaryKey { get; set; }

    [JsonPropertyName("compositeUniqueKey")]
    public bool? CompositeUniqueKey { get; set; }

    [JsonPropertyName("alternateKey")]
    public bool? AlternateKey { get; set; }

    [JsonPropertyName("compositeKey")]
    public List<String>? CompositeKey { get; set; }

    [JsonPropertyName("error")]
    public List<Error>? Error { get; set; }

    [JsonPropertyName("foreignCollection")]
    public System.Guid? ForeignCollection { get; set; }

    [JsonPropertyName("foreignField")]
    public List<System.Guid>? ForeignField { get; set; }

    [JsonPropertyName("relationshipType")]
    public string? RelationshipType { get; set; }

    [JsonPropertyName("parentRelationship")]

    public System.Guid? ParentRelationship { get; set; }
    [JsonPropertyName("childRelationships")]
    public List<System.Guid>? ChildRelationships { get; set; }

    [JsonPropertyName("isActivated")]
    public bool? IsActivated { get; set; } = true;

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("comments")]
    public string? Comments { get; set; }

    [JsonIgnore]
    public Entity? Entity { get; set; }

    [JsonIgnore]
    public Relationship? ForeignRelation => Root?.Content[ParentRelationship ?? default] as Relationship;

    [JsonIgnore]
    public Attribute? ParentAttribute =>
        (from attribute in ForeignRelation?.Parent?.Attributes
         let foreignField = ForeignField?.Last()
         where attribute is not null && foreignField is not null && attribute.Guid == foreignField.Value
         select attribute
        ).FirstOrDefault();

    [JsonIgnore]
    public IEnumerable<Relationship>? ChildRelations =>
        from item in Root?.Content
        let relation = item.Value as Relationship
        where relation is not null && Entity is not null && relation.ChildCollection == Entity?.Guid
        select relation;


    public void Link (Root root, Entity? entity)
    {
        Root = root;
        Entity = entity;
        root.Content.Add(Guid, this);
    }
}