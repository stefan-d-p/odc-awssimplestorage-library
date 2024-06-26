﻿using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.SimpleStorage.Structures;

[OSStructure(Description = "Object Metadata Value Pair")]
public struct ObjectMetadata
{
    [OSStructureField(Description = "Metadata name",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string Name;
    
    [OSStructureField(Description = "Metadata value",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string Value;
}