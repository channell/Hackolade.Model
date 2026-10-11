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
    public class GraphView
    {
        [JsonPropertyName("erd")]
        public List<GraphNode>? Erd { get; set; }

        [JsonPropertyName("buckets")]
        public List<LevelBucket>? Buckets { get; set; }

        [JsonPropertyName("decorativeSymbols")]
        public List<DecorativeSymbol>? DecorativeSymbols { get; set; }

        [JsonPropertyName("forceLayout")]
        public bool? ForceLayout { get; set; }

        [JsonPropertyName("defaultLinkLength")]
        public int? DefaultLinkLength { get; set; }

        [JsonPropertyName("options")]
        public List<object>? Options { get; set; }
    }
}