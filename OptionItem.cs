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
    public class OptionItem
    {
        [JsonPropertyName("hackoladeStyles")]
        public HackoladeStyles? HackoladeStyles { get; set; }

        [JsonPropertyName("GUID")]
        public string? GUID { get; set; }

        [JsonPropertyName("autoWidth")]
        public bool? AutoWidth { get; set; }

        [JsonPropertyName("autoHeight")]
        public bool? AutoHeight { get; set; }
    }
}