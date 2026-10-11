// ---------------------------------------------------------------------------------------
//                                   Hackolade.Model
//                        Copyright (c) 2026 Cepheis Ltd
//                                    www.cepheis.com
//
// This file is part of Hiperspace and is distributed under the GPL Open Source License. 
// ---------------------------------------------------------------------------------------

using System.Text.Json.Serialization;

namespace Hackolade.Model
{
    /// <summary>
    /// Diagram View list in the root element
    /// </summary>
    public class RootDiagramView : BaseModel
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("comments")]
        public string? Comments { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("entities")]
        public List<Guid>? Entities { get; set; }

        [JsonPropertyName("buckets")]
        public List<Guid>? Buckets { get; set; }

        [JsonPropertyName("graphView")]
        public GraphView? GraphView { get; set; }

        [JsonPropertyName("relationships")]
        public List<object>? Relationships { get; set; }

        [JsonPropertyName("displayOptions")]
        public object? DisplayOptions { get; set; }

        [JsonPropertyName("options")]
        public List<object>? Options { get; set; }

        public void Link(Root root)
        {
            Root = root;
            root.Content.Add(Guid, this);
        }
    }
}