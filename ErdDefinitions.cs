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
    public class ErdDefinitions
    {
        [JsonPropertyName("erd")]
        public List<object>? Erd { get; set; }

        [JsonPropertyName("rootPath")]
        public List<object>? RootPath { get; set; }

        [JsonPropertyName("entities")]
        public List<object>? Entities { get; set; }

        [JsonPropertyName("decorativeSymbols")]
        public List<object>? DecorativeSymbols { get; set; }
    }
}