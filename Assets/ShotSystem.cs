using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Jobs;
using Unity.Transforms;
using Unity.Rendering;
using Unity.Collections;
using Unity.Mathematics;

// TODO:ShotTagを持つエンティティであるShotGunオブジェクトから弾を撃ちたい
/// <summary>
/// ShotTagを持つエンティティから弾を撃つシステム
/// </summary>
public class ShotSystem : MonoBehaviour
{
    [SerializeField] Mesh _unitMesh;
    [SerializeField] Material _unitMaterial;
    [SerializeField] GameObject _prefab;
    [Header("生成されるグリッドの設定")]
    [SerializeField] int _sizeX;
    [SerializeField] int _sizeY;
    [SerializeField] float _spacing;

    Entity _entityPrefab;
    World _defaultWorld;
    EntityManager _entityManager;

    void Start()
    {
        //MakeEntity();
        _defaultWorld = World.DefaultGameObjectInjectionWorld;
        _entityManager = _defaultWorld.EntityManager;

        // 従来のGameObjectのワールドからECSのワールドに変換するための設定
        GameObjectConversionSettings settings = GameObjectConversionSettings.FromWorld(_defaultWorld, null);
        _entityPrefab = GameObjectConversionUtility.ConvertGameObjectHierarchy(_prefab, settings);
        InstantiateEntityGrid(_sizeX, _sizeY, _spacing);
    }

    void InstantiateEntity(float3 pos)
    {
        Entity myEntity = _entityManager.Instantiate(_entityPrefab);
        _entityManager.SetComponentData(myEntity, new Translation
        {
            Value = pos
        });
    }

    void InstantiateEntityGrid(int dimX, int dimY, float spacing = 1f)
    {
        for (int i = 0; i < dimX; i++)
        {
            for (int j = 0; j < dimY; j++)
            {
                InstantiateEntity(new float3(i * spacing, j * spacing, 0));
            }
        }
    }

    void MakeEntity()
    {
        EntityManager manager = World.DefaultGameObjectInjectionWorld.EntityManager;
        EntityArchetype archetype = manager.CreateArchetype(
            typeof(Translation),
            typeof(Rotation),
            typeof(RenderMesh),
            typeof(RenderBounds),
            typeof(LocalToWorld));
        manager.CreateEntity(archetype);

        Entity entity = manager.CreateEntity(archetype);
        manager.AddComponentData(entity, new Translation
        {
            Value = new float3(2f, 0f, 4f)
        });

        manager.AddSharedComponentData(entity, new RenderMesh
        {
            mesh = _unitMesh,
            material = _unitMaterial,
        });
    }
}
