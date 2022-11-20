using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Jobs;
using Unity.Transforms;
using Unity.Mathematics;

/// <summary>
/// 入力された移動データをもとにプレイヤーを移動させるスクリプト
/// </summary>
[AlwaysSynchronizeSystem]
public class PlayerMovementSystem : JobComponentSystem
{
    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        float deltaTime = Time.DeltaTime;
        float height = GameManager._instance.StageHeight;
        float width = GameManager._instance.StageWidth;

        // プレイヤーの移動処理
        Entities.ForEach((ref Translation trans, in PlayerMovementData data) =>
        {
            trans.Value.z = math.clamp(trans.Value.z + (data._speed * data.Vert * deltaTime), -height, height);
            trans.Value.x = math.clamp(trans.Value.x + (data._speed * data.Hori * deltaTime), -width, width);
        }).Run();

        return default;
    }
}
