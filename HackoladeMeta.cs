// ---------------------------------------------------------------------------------------
//                                   Hackolade.Model
//
// This file is part of Hiperspace and is distributed under the GPL Open Source License. 
// ---------------------------------------------------------------------------------------
using System.Text.Json.Serialization;

public sealed class HackoladeMeta
{
    [JsonPropertyName("validationErrors")]
    public Dictionary<string, bool> ValidationErrors { get; set; } = new();
}