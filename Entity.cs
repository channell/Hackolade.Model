// ---------------------------------------------------------------------------------------
//                                   Hackolade.Model
//                        Copyright (c) 2026 Cepheis Ltd
//                                    www.cepheis.com
//
// This file is part of Hiperspace and is distributed under the GPL Open Source License. 
// ---------------------------------------------------------------------------------------
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Text.Json.Serialization;

namespace Hackolade.Model;

public sealed class Entity : BaseModel
{
    const string Hub = "Hub Table ";
    const string Satalite = "Satalite Table ";
    const string Link = "Link Table ";
    const string PIT = "Pit Table ";

    [JsonPropertyName("collectionName")]
    public string? CollectionName { get; set; }

    [JsonPropertyName("properties")]
    public List<Attribute>? Attributes { get; set; }

    [JsonPropertyName("definitions")]
    public Definitions? Definitions { get; set; }

    [JsonPropertyName("isActivated")]
    public bool? IsActivated { get; set; } = true;

    [JsonPropertyName("childCollection")]
    public List<Guid>? ChildCollection { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("comments")]
    public string? Comments { get; set; }

    /// <summary>
    /// Create a Daigram View for this Entity
    /// </summary>
    public RootDiagramView? CreateContextView ()
    {
        if (Root is not null)
        {
            var current =
                (from i in Root.Content
                 let d = i.Value as RootDiagramView
                 where d != null && d.Name == CollectionName
                 select d
                ).FirstOrDefault();

            var relations =
                (from i in Root.Content
                 let r = i.Value as Relationship
                 where r != null && (r.Parent == this || r.Child == this)
                 select r).ToList();

            var refs =
                (from r in relations
                 where r.ParentCollection.HasValue
                 select r.ParentCollection!.Value
                ).Union
                (from r in relations
                 where r.ChildCollection.HasValue
                 select r.ChildCollection!.Value)
                .Distinct()
                .ToHashSet();

            var buckets =
                (from i in Root.Content
                 let b = i.Value as RootBucket
                 where b != null &&
                       b.CollectionIds != null &&
                       b.CollectionIds.Any(g => refs.Contains(g))
                 select b.Guid
                 ).ToList();

            if (current is null)
            {
                current = new RootDiagramView
                {
                    Guid = Guid.NewGuid(),
                    Name = CollectionName,
                    Entities = refs.ToList(),
                    Buckets = buckets
                };
                current.Link(Root);
                if (Root is not null)
                {
                    if (Root.DiagramViews is null) Root.DiagramViews = new List<RootDiagramView>();
                    Root?.DiagramViews.Add(current);
                }
                return current;
            }
            else
            {
                if (current.Entities is null) current.Entities = new List<Guid>();
                current.Entities = current.Entities.Union(refs.ToList()).ToList();
                if (current.Buckets is null) current.Buckets = new List<Guid>();
                current.Buckets = current.Buckets.Union(buckets).ToList();
                return current;
            }
        }
        return default;
    }

    public void Link(Root root)
    {
        Root = root;
        Definitions?.Link(root);
        Attributes?.ForEach(p => p.Link(root, this));
        root.Content.Add(Guid, this);
    }

    [JsonIgnore]
    public IEnumerable<Relationship> Relations =>
        from item in Root?.Content
        let relation = item.Value as Relationship
        where relation is not null &&
              relation.ParentCollection == Guid
        select relation;

}