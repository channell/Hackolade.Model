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
    public class ActiveRelationshipFields
    {
        [JsonPropertyName("childField")]
        public List<object>? ChildField { get; set; }

        [JsonPropertyName("parentField")]
        public List<object>? ParentField { get; set; }
    }
}