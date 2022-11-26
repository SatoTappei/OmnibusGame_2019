using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.Entities;

namespace RollABall
{
    [Serializable]
    public struct CubeSpawnerData : IComponentData
    {
        public float radius;
        public int number;
        public Entity cubePrefabEntity;
    }
}
