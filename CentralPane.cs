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
    public class CentralPane
    {
        [JsonPropertyName("dbLevel")]
        public DbLevel? DbLevel { get; set; }

        [JsonPropertyName("collectionLevel")]
        public object? CollectionLevel { get; set; }

        [JsonPropertyName("changed")]
        public bool Changed { get; set; }
    }
}