using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Entities;
using System;

namespace RollABall
{
    public class CounterMonoBehavior : MonoBehaviour
    {
        Text _countText;

        /// <summary>World.Activeは旧形式なので</summary>
        [Obsolete]
        void Awake()
        {
            _countText = GetComponent<Text>();

            // ConvertToEntityが使えないのでEntityManagerを通して作成する
            EntityManager entityManager = World.Active.EntityManager;
            entityManager.CreateEntity(typeof(Count));
        }

        public void SetCount(int count)
        {
            _countText.text = count.ToString();
        }
    }
}