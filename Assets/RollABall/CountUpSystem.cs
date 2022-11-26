using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using System;

namespace RollABall
{
    public class CountUpSystem : ComponentSystem
    {
        CounterMonoBehavior _counter;
        EntityManager _entityManager;

        protected override void OnCreate()
        {
            _counter = GameObject.FindObjectOfType<CounterMonoBehavior>();
#pragma warning disable CS0618 // 型またはメンバーが旧型式です
            _entityManager = World.Active.EntityManager;
#pragma warning restore CS0618 // 型またはメンバーが旧型式です
        }

        protected override void OnUpdate()
        {
            Entities.ForEach((Entity entity, ref Count count, ref CountUp countUp) =>
            {
                count.value += 1;
                _counter.SetCount(count.value);
                _entityManager.RemoveComponent<CountUp>(entity);
            });
        }
    }
}