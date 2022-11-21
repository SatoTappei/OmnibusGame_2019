using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

/// <summary>
/// 弾の発射源だという事を識別するための構造体
/// </summary>
[GenerateAuthoringComponent]
public struct MuzzleTag : IComponentData
{
    [Header("弾のプレハブ")]
    public Entity _bulletPrefab;
}
