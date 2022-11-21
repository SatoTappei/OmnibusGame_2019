using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

[GenerateAuthoringComponent]
public struct RotateTag : IComponentData
{
    [Header("回転速度")]
    public float _speed;
}
