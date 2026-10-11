// ---------------------------------------------------------------------------------------
//                                   Hackolade.Model
//                        Copyright (c) 2026 Cepheis Ltd
//                                    www.cepheis.com
//
// This file is part of Hiperspace and is distributed under the GPL Open Source License. 
// ---------------------------------------------------------------------------------------
using System.Text.Json.Serialization;

public sealed class HackoladeMeta
{
    [JsonPropertyName("validationErrors")]
    public Dictionary<string, bool> ValidationErrors { get; set; } = new();
}