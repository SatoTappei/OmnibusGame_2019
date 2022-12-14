using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

[GenerateAuthoringComponent]
public struct WaveData : IComponentData
{
    public float amplitude;
    public float xOffset;
    public float yOffset;
}
