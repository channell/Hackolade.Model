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
    public sealed class RootBucket : BaseModel
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("type")]
        public string? Type { get; set; }

        [JsonPropertyName("collectionIds")]
        public List<Guid>? CollectionIds { get; set; }

        [JsonPropertyName("backgroundColor")]
        public RgbaColor? BackgroundColor { get; set; }

        [JsonPropertyName("show")]
        public bool? Show { get; set; }

        [JsonPropertyName("isActivated")]
        public bool? IsActivated { get; set; }

        [JsonPropertyName("indexes")]
        public List<object>? Indexes { get; set; }

        [JsonPropertyName("hackoladeMeta")]
        public HackoladeMeta? HackoladeMeta { get; set; }

        public void Link(Root root)
        {
            Root = root;
            root.Content.Add(Guid, this);
        }
    }
}