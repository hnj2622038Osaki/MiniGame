using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpikeController : MonoBehaviour
{
    [SerializeField] private int attackCount = 12;       // 発射する弾の数
    [SerializeField] private float attackspeed = 1f;     // 弾の移動速度
    [SerializeField] private float attackInterval = 0.1f;  // 攻撃のインターバル
    [SerializeField] private float attackrotation = 15f; // 攻撃の角度

    private float CurrentBaceRotation = 0f; // 現在の角度

    private float timer = 0f;
    private Rigidbody2D rigid;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // タイマーを進める
        timer += Time.deltaTime;


        //画面外に出たらオブジェクトを破壊する
        if (transform.position.y < -7.0f)
        {
            Destroy(gameObject);
        }
        if (transform.position.y > 7.0f)
        {
            Destroy(gameObject);
        }
        if (transform.position.x < -10.0f)
        {
            Destroy(gameObject);
        }
        if (transform.position.x > 10.0f)
        {
            Destroy(gameObject);
        }
        GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(gameObject.name + "と" + collision.gameObject.name + "があたった(衝突)");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(gameObject.name + "と" + collision.gameObject.name + "があたった");
    }
}
