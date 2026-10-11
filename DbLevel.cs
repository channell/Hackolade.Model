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
    public class DbLevel
    {
        [JsonPropertyName("erd")]
        public List<ErdItem>? Erd { get; set; }

        [JsonPropertyName("erdDefinitions")]
        public ErdDefinitions? ErdDefinitions { get; set; }

        [JsonPropertyName("buckets")]
        public List<LevelBucket>? Buckets { get; set; }

        [JsonPropertyName("collapsedNodes")]
        public List<object>? CollapsedNodes { get; set; }

        [JsonPropertyName("activeRelationship")]
        public string? ActiveRelationship { get; set; }

        [JsonPropertyName("activeRelationshipFields")]
        public ActiveRelationshipFields? ActiveRelationshipFields { get; set; }

        [JsonPropertyName("selectedCollections")]
        public List<object>? SelectedCollections { get; set; }

        [JsonPropertyName("displayColorPicker")]
        public bool? DisplayColorPicker { get; set; }

        [JsonPropertyName("graphView")]
        public GraphView? GraphView { get; set; }

        [JsonPropertyName("diagramViews")]
        public List<DiagramView>? DiagramViews { get; set; }

        [JsonPropertyName("decorativeSymbols")]
        public List<DecorativeSymbol>? DecorativeSymbols { get; set; }

        [JsonPropertyName("nestedCollectionsLayout")]
        public string? NestedCollectionsLayout { get; set; }

        [JsonPropertyName("options")]
        public List<OptionItem>? Options { get; set; }

        [JsonPropertyName("relationshipUpdateDisabled")]
        public bool? RelationshipUpdateDisabled { get; set; }

        [JsonPropertyName("displayOptions")]
        public object? DisplayOptions { get; set; }
    }
}