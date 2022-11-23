using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance;

    [Header("★ステージの幅と高さ設定")]
    [SerializeField] float _stageWidth = 5;
    [SerializeField] float _stageHeight = 5;
    [Header("★弾の表示範囲の設定")]
    [SerializeField] Vector2 _leftUpPos = new Vector2(-5, 5);
    [SerializeField] Vector2 _rightBottomPos = new Vector2(5, -5);

    public float StageWidth { get => _stageWidth; }
    public float StageHeight { get => _stageHeight; }
    public Vector2 LeftUpPos { get => _leftUpPos; }
    public Vector2 RightBottomPos { get => _rightBottomPos; }

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
        // TODO:弾を作る
        // TODO:敵を動かす
        // TODO:敵から弾を発射する
        // TODO:プレイヤーの当たり判定の実装
    }

    void Update()
    {
        
    }
}
