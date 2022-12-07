using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;
using Unity.Jobs;

public class WaveSystem : JobComponentSystem
{
    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        float elapsedTime = (float)Time.ElapsedTime;

        JobHandle jobHandle = Entities.ForEach((ref Translation trans, in MoveSpeedData data, in WaveData waveData) =>
        {
            float zPos = waveData.amplitude * math.sin(elapsedTime * data.Value +
                trans.Value.x * waveData.xOffset + trans.Value.y * waveData.yOffset);
            trans.Value = new float3(trans.Value.x, trans.Value.y, zPos);
        }).Schedule(inputDeps);

        return jobHandle;
    }
}
