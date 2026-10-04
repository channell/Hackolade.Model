// ---------------------------------------------------------------------------------------
//                                   Hackolade.Model
//
// This file is part of Hiperspace and is distributed under the GPL Open Source License. 
// ---------------------------------------------------------------------------------------
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Hackolade.Model;

public abstract class BaseModel
{
    [JsonPropertyName("GUID")]
    public System.Guid? Guid { get; set; }

    [JsonExtensionData]
    public Dictionary<string, JsonElement>? AdditionalData { get; set; }

    [JsonIgnore]
    public Root? Root { get; set; }
}