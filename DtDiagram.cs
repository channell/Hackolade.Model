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
    public class DtDiagram
    {
        [JsonPropertyName("collapsedNodes")]
        public List<object>? CollapsedNodes { get; set; }

        [JsonPropertyName("shouldDistributeCollections")]
        public bool? ShouldDistributeCollections { get; set; }
    }
}