using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.Entities;
using Unity.Mathematics;

namespace RollABall
{
    [Serializable]
    public struct Force : IComponentData
    {
        public float3 dir;
        public float mag;
    }
}