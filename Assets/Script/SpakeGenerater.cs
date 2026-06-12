using UnityEngine;
using UnityEngine.EventSystems;

public class SpakeGenerater : MonoBehaviour
{
    [SerializeField] private GameObject attackPrefab;   // 弾のプレハブ
    [SerializeField] private int attackCount = 12;      // 発射する弾の数
    [SerializeField] private float speed = 5f;              // 弾の移動速度
    [SerializeField] private float attackInterval = 1f;     // 攻撃のインターバル
    [SerializeField] private float attackrotation = 15f;     // 攻撃の角度
    private Rigidbody2D rigid;
    private float timer = 0f;
    private float CurrentBaceRotation = 0f; // 現在の角度

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // タイマーを進める
        timer += Time.deltaTime;
        // 弾の発射間隔
        if (timer >= attackInterval)
        {
            AttackRotationCircle();
            timer = 0f;
        }

        // 現在の角度を回転させる
        CurrentBaceRotation += Time.deltaTime * attackrotation;

        // １周したら元に戻す
        if (CurrentBaceRotation > 360f) CurrentBaceRotation -= 360f;

        // 画面外に出たらオブジェクトを破壊する
        if (transform.position.y < -5.0f)
        {
            Destroy(gameObject);
        }
    }
    private void AttackRotationCircle()
    {
        // 弾と弾の間の角度
        float RotationStep = 360f / attackCount;

    }
}
