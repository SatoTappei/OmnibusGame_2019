using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;
using Unity.Jobs;

public class RotationSystem : JobComponentSystem
{
    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        float deltaTime = Time.DeltaTime;

        Entities.ForEach((ref Rotation rot, in RotateTag tag) =>
            {
                quaternion normalizedRot = math.normalizesafe(rot.Value);
                quaternion angleToRotate = quaternion.AxisAngle(math.up(), tag._speed * deltaTime);

                rot.Value = math.mul(normalizedRot, angleToRotate);
            }).Run();

        return inputDeps;
    }
}
