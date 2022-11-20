using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance;

    [Header("★ステージ設定")]
    [SerializeField] float _stageWidth = 5;
    [SerializeField] float _stageHeight = 5;

    public float StageWidth { get => _stageWidth; }
    public float StageHeight { get => _stageHeight; }

    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
