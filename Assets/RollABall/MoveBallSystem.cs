using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Physics;
using UnityEngine;

namespace RollABall
{
    public class MoveBallSystem : JobComponentSystem
    {
        [BurstCompile]
        struct MoveBallJob : IJobForEach<PhysicsVelocity, PhysicsMass, Ball, Force>
        {
            public float DeltaTime;

            public void Execute(ref PhysicsVelocity velo,
                     [ReadOnly] ref PhysicsMass mass,
                     [ReadOnly] ref Ball ball,
                                ref Force force)
            {
                velo.Linear += mass.InverseMass * force.dir * force.mag * DeltaTime;
            }
        }

        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            MoveBallJob job = new MoveBallJob
            {
                DeltaTime = Time.DeltaTime,
            };

            return job.Schedule(this, inputDeps);
        }
    }
}