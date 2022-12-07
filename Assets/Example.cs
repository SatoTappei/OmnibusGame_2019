using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Jobs;
using Unity.Collections;

public class Example : MonoBehaviour
{
    void Start()
    {
        Do();
    }

    void Do()
    {
        // Allocator.TempJobはジョブが終わったら解放する、結果を受け取る事はない
        NativeArray<float> resultArray = new NativeArray<float>(1, Allocator.TempJob);

        // 生成 & 初期化
        SimpleJob job = new SimpleJob
        {
            a = 5f,
            result = resultArray
        };

        AnorherJob secondJob = new AnorherJob();
        secondJob.result = resultArray;

        // スケジュール
        JobHandle handle = job.Schedule();
        JobHandle secondHandle = secondJob.Schedule(handle);

        secondHandle.Complete();

        float resultingValue = resultArray[0];
        Debug.Log(resultingValue);
        Debug.Log(job.a);

        resultArray.Dispose();
    }

    struct SimpleJob : IJob
    {
        public float a;
        public NativeArray<float> result;
        
        public void Execute()
        {
            result[0] = a;
            a = 23;
        }
    }

    struct AnorherJob : IJob
    {
        public NativeArray<float> result;

        public void Execute()
        {
            result[0] = result[0] + 1;
        }
    }
}
