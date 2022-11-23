using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

/// <summary>
/// 入力に使うキーのデータを保持している構造体
/// </summary>
[GenerateAuthoringComponent]
public struct PlayerInputData : IComponentData
{
    [Header("プレイヤーの移動に割り当てるキー")]
    public KeyCode _up;
    public KeyCode _down;
    public KeyCode _left;
    public KeyCode _right;
}
