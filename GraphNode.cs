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
    public class GraphNode
    {
        [JsonPropertyName("GUID")]
        public string? GUID { get; set; }

        [JsonPropertyName("size")]
        public double? Size { get; set; }

        [JsonPropertyName("x")]
        public double? X { get; set; }

        [JsonPropertyName("y")]
        public double? Y { get; set; }
    }
}