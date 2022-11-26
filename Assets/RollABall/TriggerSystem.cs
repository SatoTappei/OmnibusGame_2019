using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Physics;
using Unity.Physics.Systems;

namespace RollABall
{
    [UpdateAfter(typeof(EndFramePhysicsSystem))]
    public class TriggerSystem : JobComponentSystem
    {
        BuildPhysicsWorld _buildPhysicsWorld;
        StepPhysicsWorld _stepPhysicsWorld;
        EntityCommandBufferSystem _bufferSystem;

        EntityQuery _entityQuery;

        protected override void OnCreate()
        {
            _buildPhysicsWorld = World.GetOrCreateSystem<BuildPhysicsWorld>();
            _stepPhysicsWorld = World.GetOrCreateSystem<StepPhysicsWorld>();
            _bufferSystem = World.GetOrCreateSystem<EndSimulationEntityCommandBufferSystem>();

            _entityQuery = GetEntityQuery(ComponentType.ReadOnly<Count>());
        }

        struct TriggerJob : ITriggerEventsJob
        {
            [ReadOnly] public ComponentDataFromEntity<Cube> Cube;
            [ReadOnly] public ComponentDataFromEntity<Ball> Ball;
            public EntityCommandBuffer CommandBuffer;

            [DeallocateOnJobCompletion]
            [ReadOnly]
            public NativeArray<Entity> CountArray;

            public void Execute(TriggerEvent triggerEvent)
            {
                Entity entityA = triggerEvent.Entities.EntityA;
                Entity entityB = triggerEvent.Entities.EntityB;

                bool isBodyACube = Cube.Exists(entityA);
                bool isBodyBCube = Cube.Exists(entityB);

                bool isBodyABall = Ball.Exists(entityA);
                bool isBodyBBall = Ball.Exists(entityB);

                // Cubeではないもの同士なら何もしない
                if (!isBodyACube && !isBodyBCube) return;
                // Ballではないもの同士なら何もしない
                if (!isBodyABall && !isBodyBBall) return;

                Entity cubeEntity = isBodyACube ? entityA : entityB;
                Entity ballEntity = isBodyABall ? entityA : entityB;

                CommandBuffer.DestroyEntity(cubeEntity);

                foreach (Entity entity in CountArray)
                {
                    CommandBuffer.AddComponent(entity, new CountUp());
                }
            }
        }

        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            JobHandle jobHandle = new TriggerJob
            {
                Cube = GetComponentDataFromEntity<Cube>(true),
                Ball = GetComponentDataFromEntity<Ball>(true),
                CommandBuffer = _bufferSystem.CreateCommandBuffer(),
                CountArray = _entityQuery.ToEntityArray(Allocator.TempJob)
            }.Schedule(_stepPhysicsWorld.Simulation, ref _buildPhysicsWorld.PhysicsWorld, inputDeps);

            _bufferSystem.AddJobHandleForProducer(jobHandle);

            return jobHandle;
        }
    }

}