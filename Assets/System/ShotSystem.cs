using Unity.Entities;
using Unity.Jobs;
using Unity.Transforms;

public class ShotSystem : JobComponentSystem
{
    // ジョブで処理した内容をためるバッファー
    BeginSimulationEntityCommandBufferSystem _entityCommandBufferSystem;

    float _interval;

    protected override void OnCreate()
    {

        // Worldからバッファーのシステムを生成する
        _entityCommandBufferSystem = World.GetOrCreateSystem<BeginSimulationEntityCommandBufferSystem>();
    }

    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        // 毎フレーム処理をためるためのバッファーを生成する
        EntityCommandBuffer commandBuffer = _entityCommandBufferSystem.CreateCommandBuffer();

        if (_interval > 0.15f)
        {
            // タグで絞り込むとエラーが出るのでコメントアウト
            Entities/*.WithAll<MuzzleTag>()*/
                    .WithoutBurst()
                    .ForEach((in MuzzleTag tag, in LocalToWorld localToWorld) =>
                    {
                        // GameObjectのプレハブから弾を生成する
                        Entity bullet = commandBuffer.Instantiate(tag._bulletPrefab);

                        // 位置をローカル座標系でセットする
                        commandBuffer.SetComponent(bullet, new Translation
                        {
                            Value = localToWorld.Position
                        });

                        // 回転をローカル座標系でセットする
                        commandBuffer.SetComponent(bullet, new Rotation
                        {
                            Value = localToWorld.Rotation
                        });
                    }).Run();

            // コマンドバッファをジョブに依存させてJobが完了する前に実行されるのを防ぐ
            _entityCommandBufferSystem.AddJobHandleForProducer(inputDeps);
            _interval = 0;
        }

        _interval += Time.DeltaTime;

        return default;
    }
}
