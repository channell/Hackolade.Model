// ---------------------------------------------------------------------------------------
//                                   Hackolade.Model
//                        Copyright (c) 2026 Cepheis Ltd
//                                    www.cepheis.com
//
// This file is part of Hiperspace and is distributed under the GPL Open Source License. 
// ---------------------------------------------------------------------------------------
using System.Text.Json.Serialization;

namespace Hackolade.Model;

public sealed class HackoladeStyles : BaseModel
{
    [JsonPropertyName("thickness")]
    public int? Thickness { get; set; }

    [JsonPropertyName("color")]
    public string? Color{ get; set; }

    public void Link(Root root)
    {
        Root = root;
        root.Content.Add(Guid, this);
    }
}