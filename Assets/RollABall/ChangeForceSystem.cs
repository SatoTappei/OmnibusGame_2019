using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Physics;
using UnityEngine;

namespace RollABall
{
    public class ChangeForceSystem : JobComponentSystem
    {
        [BurstCompile]
        struct ChangeForceJob : IJobForEach<PhysicsVelocity, PhysicsMass, Ball, Force>
        {
            public float3 Dir { get; set; }

            public void Execute(ref PhysicsVelocity velo, 
                     [ReadOnly] ref PhysicsMass mass,
                     [ReadOnly] ref Ball ball,
                                ref Force force)
            {
                force.dir = Dir;
            }
        }

        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            ChangeForceJob job = new ChangeForceJob();

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                job.Dir = math.float3(-1, 0, 0);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                job.Dir = math.float3(1, 0, 0);
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                job.Dir = math.float3(0, 0, 1);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                job.Dir = math.float3(0, 0, -1);
            }

            return job.Schedule(this, inputDeps);
        }
    }
}
