using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.Entities;

namespace RollABall
{
    [Serializable]
    public struct Count : IComponentData
    {
        public int value;
    }
}