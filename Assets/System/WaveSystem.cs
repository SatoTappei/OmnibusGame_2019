using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;

public class WaveSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        Entities.ForEach((ref Translation trans, ref MoveSpeedData data) =>
        {
            float zPos = math.sin((float)Time.ElapsedTime * data.Value);
            trans.Value = new float3(trans.Value.x, trans.Value.y, zPos);
        });
    }
}
