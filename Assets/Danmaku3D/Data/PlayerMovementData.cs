using UnityEngine;
using Unity.Entities;

/// <summary>
/// プレイヤーの移動に使用するデータの構造体
/// </summary>
[GenerateAuthoringComponent]
public struct PlayerMovementData : IComponentData
{
    [Header("移動速度")]
    public float _speed;

    public float Hori { get; set; }
    public float Vert { get; set; }
}
