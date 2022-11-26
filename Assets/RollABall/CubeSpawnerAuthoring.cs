using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

namespace RollABall
{
    [RequiresEntityConversion]
    public class CubeSpawnerAuthoring : MonoBehaviour, IConvertGameObjectToEntity, IDeclareReferencedPrefabs
    {
        [SerializeField] GameObject cubePrefab = default;

        public void DeclareReferencedPrefabs(List<GameObject> referencedPrefabs)
        {
            referencedPrefabs.Add(cubePrefab);
        }

        public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
        {
            CubeSpawnerData data = new CubeSpawnerData
            {
                number = 24,
                radius = 7.5f * 3f,
                cubePrefabEntity = conversionSystem.GetPrimaryEntity(cubePrefab)
            };

            dstManager.AddComponentData(entity, data);
        }
    }
}