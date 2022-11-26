using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;

namespace RollABall
{
    public class RotateCubeSystem : JobComponentSystem
    {
        [BurstCompile]
        struct RotateCubeJob : IJobForEach<Rotation, Cube, CubeRotationSpeed>
        {
            public float DeltaTime;

            public void Execute(ref Rotation rot, 
                     [ReadOnly] ref Cube cube, 
                     [ReadOnly] ref CubeRotationSpeed speed)
            {
                rot.Value = math.mul(quaternion.AxisAngle(math.up(), speed.value * DeltaTime), math.normalize(rot.Value));
            }
        }

        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            RotateCubeJob job = new RotateCubeJob
            {
                DeltaTime = Time.DeltaTime,
            };

            return job.Schedule(this, inputDeps);
        }
    }
}
