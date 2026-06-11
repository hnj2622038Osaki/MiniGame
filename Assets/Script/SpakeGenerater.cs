using UnityEngine;

public class SpakeGenerater : MonoBehaviour
{
    [SerializeField] private GameObject SpikedbollPrefab;   // 弾のプレハブ
    [SerializeField] private int SpikedbollCount = 12;      // 発射する弾の数
    [SerializeField] private float speed = 5f;              // 弾の移動速度
    [SerializeField] private float attackInterval = 1f;     // 攻撃のインターバル
    private float timer = 0f;

    private void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        // タイマーを進める
        timer += Time.deltaTime;

        // 3秒が経ったら攻撃
        if (timer >= attackInterval)
        {
            timer = 0f; // タイマーをリセット
        }
        // 画面外に出たらオブジェクトを破壊する
        if (transform.position.y < -5.0f)
        {
            Destroy(gameObject);
        }
    }
}
