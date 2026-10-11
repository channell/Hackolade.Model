// ---------------------------------------------------------------------------------------
//                                   Hackolade.Model
//                        Copyright (c) 2026 Cepheis Ltd
//                                    www.cepheis.com
//
// This file is part of Hiperspace and is distributed under the GPL Open Source License. 
// ---------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Hackolade.Model
{
    public class LevelBucket : BaseModel
    {
        [JsonPropertyName("x")]
        public double? X { get; set; }

        [JsonPropertyName("y")]
        public double? Y { get; set; }
        public void Link(Root root)
        {
            Root = root;
            root.Content.Add(Guid, this);
        }
    }
}

namespace Hackolade.Model
{
}