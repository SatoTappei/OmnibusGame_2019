using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

/// <summary>
/// プレイヤーの移動に使うキーのデータ
/// </summary>
[GenerateAuthoringComponent]
public struct InputData : IComponentData
{
    [Header("プレイヤーの移動に使うキー")]
    public KeyCode Up;
    public KeyCode Down;
    public KeyCode Right;
    public KeyCode Left;
}
