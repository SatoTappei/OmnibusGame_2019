using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Jobs;

namespace Danmaku3D
{
    /// <summary>
    /// 画面外に出た弾を削除するスクリプト
    /// 弾の移動の後に処理する
    /// </summary>
    [UpdateAfter(typeof(BulletMovementSystem))]
    public class BulletDestroySystem : JobComponentSystem
    {
        EndSimulationEntityCommandBufferSystem _entityCommandBufferSystem;

        protected override void OnCreate()
        {
            _entityCommandBufferSystem = World.GetOrCreateSystem<EndSimulationEntityCommandBufferSystem>();
        }

        protected override void OnStartRunning()
        {

        }

        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            EntityCommandBuffer commandBuffer = _entityCommandBufferSystem.CreateCommandBuffer();

            Vector2 borderL = GameManager._instance.LeftUpPos;
            Vector2 borderR = GameManager._instance.RightBottomPos;

            // WithAll()メソッドはForeach()メソッドの中で使用しない構造体ならエラーが出ない
            Entities.WithAll<BulletTag>()
                    .WithoutBurst()
                    .ForEach((Entity entity, in Translation trans) =>
                    {
                    // 画面外に出たら消す
                    if (trans.Value.x > borderR.x || trans.Value.x < borderL.x ||
                            trans.Value.z > borderL.y || trans.Value.z < borderR.y)
                        {
                            commandBuffer.DestroyEntity(entity);
                        }
                    }).Run();

            // JobをCommandBufferで流し込む
            _entityCommandBufferSystem.AddJobHandleForProducer(inputDeps);

            return default;
        }
    }
}