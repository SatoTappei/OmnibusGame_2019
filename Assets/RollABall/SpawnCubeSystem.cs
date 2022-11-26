using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;

namespace RollABall
{
    public class SpawnCubeSystem : JobComponentSystem
    {
        EntityCommandBufferSystem _bufferSystem;

        protected override void OnCreate()
        {
            _bufferSystem = World.GetExistingSystem<EndSimulationEntityCommandBufferSystem>();
        }

        struct SpawnCubeJob : IJobForEachWithEntity<CubeSpawnerData, LocalToWorld>
        {
            public EntityCommandBuffer.Concurrent CommandBuffer;

            public void Execute(Entity entity,
                                int index, 
                                [ReadOnly] ref CubeSpawnerData data, 
                                ref LocalToWorld localToWorld)
            {
                for (int i = 0; i < data.number; i++)
                {
                    Entity instance = CommandBuffer.Instantiate(index, data.cubePrefabEntity);
                    float posX = data.radius * math.cos(2 * math.PI / data.number * i);
                    float posZ = data.radius * math.sin(2 * math.PI / data.number * i);

                    CommandBuffer.SetComponent(index, instance, new Translation
                    {
                        Value = math.float3(posX, 1.5f, posZ) 
                    });
                }

                // 1回Executeを実行したらCubeSpawnEntityを削除する
                CommandBuffer.DestroyEntity(index, entity);
            }
        }

        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            var job = new SpawnCubeJob
            {
                CommandBuffer = _bufferSystem.CreateCommandBuffer().ToConcurrent()
            }.Schedule(this, inputDeps);

            _bufferSystem.AddJobHandleForProducer(job);
            return job;
        }
    }
}
