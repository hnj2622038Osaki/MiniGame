using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    GameObject Spike;
    [SerializeField] float moveSpeed = 0.1f;
    [SerializeField] float jumpForce = 600.0f;
    [SerializeField] Sprite walkSprites;
    private Rigidbody2D rigid;
    private bool Grounded;

    float time = 0;
    int idx = 0;
    SpriteRenderer spriteRenderer;

    void Start()
    {
        Application.targetFrameRate = 60;
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        Spike = GameObject.Find("Spiked Ball");
    }

    void Update()
    {
            GetComponent<Animator>().SetBool("Run", false);
        // 右に移動
        if (Keyboard.current.rightArrowKey.isPressed)
        {
            transform.Translate(moveSpeed, 0, 0);
            GetComponent<Animator>().SetBool("Run", true);
        }
        // 左に移動
        if (Keyboard.current.leftArrowKey.isPressed)
        {
            transform.Translate(-moveSpeed, 0, 0);
            GetComponent<Animator>().SetBool("Run", true);
        }
        // ジャンプ
        if (Keyboard.current.upArrowKey.wasPressedThisFrame && rigid.linearVelocityY == 0)
        {
            //rigid.AddForce(transform.up * jumpForce);
            transform.Translate(0, jumpForce, 0);
        }
        // 当たり判定
        Vector2 p1 = Spike.transform.position;
        Vector2 p2 = transform.position;
        Vector2 dir = p1 - p2;
        float d = dir.magnitude;
        float r1 = 0.5f;
        float r2 = 1.0f;

        if (d < r1 + r2)
        {
            // 衝突した場合はプレイヤーを消す
            Destroy(gameObject);
        }
    }
    // 地面との接触判定
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Grounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Grounded = false;
        }
    }
}