using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

namespace Danmaku3D
{
    /// <summary>
    /// 弾だという事を識別するための構造体
    /// </summary>
    [GenerateAuthoringComponent]
    public struct BulletTag : IComponentData
    {
        [Header("弾速")]
        public float _speed;
    }
}