using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;

namespace Domino
{
    /// <summary>
    /// プレイヤーの移動量を実際に移動に反映するシステム
    /// </summary>
    [AlwaysSynchronizeSystem]
    [UpdateAfter(typeof(PlayerInputSystem))]
    public class PlayerMoveSystem : JobComponentSystem
    {
        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            float dt = Time.DeltaTime;
            float width = GameManager.StageWidth;
            float height = GameManager.StageHeight;

            Entities.ForEach((ref Translation trans, in MovementData movementData) =>
            {
                trans.Value.x = math.clamp(trans.Value.x + movementData.MoveX * movementData.Speed * dt, -width, width);
                trans.Value.z = math.clamp(trans.Value.z + movementData.MoveZ * movementData.Speed * dt, -height, height);
            }).Run();

            return default;
        }
    }
}
