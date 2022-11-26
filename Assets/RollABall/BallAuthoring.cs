using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

namespace RollABall
{
    [RequiresEntityConversion]
    public class BallAuthoring : MonoBehaviour, IConvertGameObjectToEntity
    {
        public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
        {
            dstManager.AddComponentData(entity, new Ball());
            dstManager.AddComponentData(entity, new Force { mag = 10 });
        }
    }
}