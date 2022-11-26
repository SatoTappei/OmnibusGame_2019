using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Jobs;

namespace Danmaku3D
{
    /// <summary>
    /// 入力をプレイヤーの移動データに伝えるためのスクリプト
    /// </summary>
    // メインスレッドで動作させるために強制的に同期させる属性
    [AlwaysSynchronizeSystem]
    public class PlayerInputSystem : JobComponentSystem
    {
        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            // Entities.ForEach()…エンティティそれぞれのデータを操作する
            // ref 書き込み先 in 読み込み先 .Run() <= メインスレッドでの実行
            Entities.ForEach((ref PlayerMovementData moveData, in PlayerInputData inputData) =>
            {
                moveData.Hori = 0;
                moveData.Vert = 0;

                moveData.Hori += Input.GetKey(inputData._left) ? -1 : 0;
                moveData.Hori += Input.GetKey(inputData._right) ? 1 : 0;
                moveData.Vert += Input.GetKey(inputData._up) ? 1 : 0;
                moveData.Vert += Input.GetKey(inputData._down) ? -1 : 0;
            }).Run();

            // inputDepsを弄っていないと明確にするためdefaultを返す
            return default;
        }
    }

}