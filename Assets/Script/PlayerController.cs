using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 0.1f;
    [SerializeField] float jumpForce = 600.0f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] Sprite walkSprites;
    private Rigidbody2D rigid;
    private bool Grounded; 
    private float timer = 0f;

    float time = 0;
    SpriteRenderer spriteRenderer;

    void Start()
    {
        Application.targetFrameRate = 60;
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        timer = Time.deltaTime;
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
            rigid.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        if (timer >= 12f)
        {
            Debug.Log("クリア‼");
            SceneManager.LoadScene("ClearScene");
            return;
        }
        GetComponent<AudioSource>().loop = true;
    }
    // 地面との接触判定
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Grounded = true;
        }
        if (collision.gameObject.CompareTag("SpikedBall"))
        {   
            Destroy(gameObject);
            Debug.Log("ゲームオーバー");
            SceneManager.LoadScene("OverScene");
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