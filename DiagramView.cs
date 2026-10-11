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
    public class DiagramView : BaseModel
    {
        [JsonPropertyName("entities")]
        public List<ErdItem>? Entities { get; set; }

        [JsonPropertyName("buckets")]
        public List<LevelBucket>? Buckets { get; set; }

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