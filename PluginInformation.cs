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
    public class PluginInformation
    {
        [JsonPropertyName("pluginName")]
        public string PluginName { get; set; } = string.Empty;

        [JsonPropertyName("pluginVersion")]
        public string PluginVersion { get; set; } = string.Empty;

        [JsonPropertyName("pluginEngineVersion")]
        public string PluginEngineVersion { get; set; } = string.Empty;
    }
}