using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Jobs;

namespace Danmaku3D
{
    public class BulletMovementSystem : JobComponentSystem
    {
        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            float deltaTime = Time.DeltaTime;

            Entities.ForEach((ref Translation trans, in LocalToWorld localToWorld, in BulletTag bulletTag) =>
            {
                trans.Value += localToWorld.Forward * bulletTag._speed * deltaTime;
            }).Run();

            return default;
        }
    }
}
