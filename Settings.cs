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
    public class Settings
    {
        [JsonPropertyName("centralPane")]
        public CentralPane? CentralPane { get; set; }

        [JsonPropertyName("dtDiagram")]
        public DtDiagram? DtDiagram { get; set; }
    }
}