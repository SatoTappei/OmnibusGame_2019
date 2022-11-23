using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Physics;

/// <summary>
/// 現在未使用、リファレンスとして残している
/// </summary>
[AlwaysSynchronizeSystem]
public class IncreaseVelocityOverTimeSystem : JobComponentSystem
{
    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        //float deltaTime = Time.DeltaTime;

        //Entities.ForEach((ref PhysicsVelocity vel, in SpeedIncreaseOverTimeData data) =>
        //{
        //    float2 modifier = new float2(data.IncreasePerSec * deltaTime);

        //    float2 newVel = vel.Linear.xy;
        //    newVel += math.lerp(-modifier, modifier, math.sign(newVel));
        //    vel.Linear.xy = newVel;
        //}).Run();

        return default;
    }
}
