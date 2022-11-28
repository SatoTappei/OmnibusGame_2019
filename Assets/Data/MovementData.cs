using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

namespace Domino
{
    /// <summary>
    /// プレイヤーの移動量のデータ
    /// </summary>
    [GenerateAuthoringComponent]
    public struct MovementData : IComponentData
    {
        public float MoveX { get; set; }
        public float MoveZ { get; set; }

        [Header("移動速度")]
        public int Speed;
    }
}
