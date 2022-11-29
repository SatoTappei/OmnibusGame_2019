using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Jobs;
using Unity.Entities;

/// <summary>
/// プレイヤーの入力を移動量に反映するシステム
/// </summary>
[AlwaysSynchronizeSystem]
public class PlayerInputSystem : JobComponentSystem
{
    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        //Entities.ForEach((ref MovementData movementData, in InputData inputData) =>
        //{
        //    movementData.MoveX = 0;
        //    movementData.MoveZ = 0;

        //    movementData.MoveX += Input.GetKey(inputData.Right) ? 1 : 0;
        //    movementData.MoveX += Input.GetKey(inputData.Left) ? -1 : 0;

        //    movementData.MoveZ += Input.GetKey(inputData.Up) ? 1 : 0;
        //    movementData.MoveZ += Input.GetKey(inputData.Down) ? -1 : 0;
        //}).Run();

        return default;
    }
}