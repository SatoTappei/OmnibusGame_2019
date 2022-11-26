using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

namespace RollABall
{
    public class CubeAuthoring : MonoBehaviour, IConvertGameObjectToEntity
    {
        public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
        {
            dstManager.AddComponentData(entity, new Cube());
            dstManager.AddComponentData(entity, new CubeRotationSpeed { value = 2 });
        }
    }
}
