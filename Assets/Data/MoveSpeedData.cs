using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

[GenerateAuthoringComponent]
public struct MoveSpeedData : IComponentData
{
    public float Value;
}
