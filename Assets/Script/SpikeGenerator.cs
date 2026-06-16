using UnityEngine;

public class SpikeGenerator : MonoBehaviour
{
    [SerializeField] private GameObject attackPrefab;    // 弾のプレハブ
    [SerializeField] private float span = 0.5f;
    [SerializeField] int angle = 20;
    private float timer = 0f;
    int amount = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // タイマーを進める
        timer += Time.deltaTime;

        if (timer > span)
        {
            GameObject go = Instantiate(attackPrefab);
            go.transform.position = new Vector3(0, -1, 0);
            Vector2 vec = new Vector2 (-100f, 0f);  // 初期の発射方向 左
            go.GetComponent<Rigidbody2D>().AddForce(Quaternion.Euler(0, 0, amount* angle) * vec);

            GameObject go2 = Instantiate(attackPrefab);
            go2.transform.position = new Vector3(0, -1, 0);
            Vector2 vec2 = new Vector2 ( 100f, 0f);   // 初期の発射方向 右
            go2.GetComponent<Rigidbody2D>().AddForce(Quaternion.Euler(0, 0, amount* angle) * vec2);

            GameObject go3 = Instantiate(attackPrefab);
            go3.transform.position = new Vector3(0, -1, 0);
            Vector2 vec3 = new Vector2 (0f, -100f);   // 初期の発射方向 下
            go3.GetComponent<Rigidbody2D>().AddForce(Quaternion.Euler(0, 0, amount* angle) * vec3);

            GameObject go4 = Instantiate(attackPrefab);
            go4.transform.position = new Vector3(0, -1, 0);
            Vector2 vec4 = new Vector2 (0f, 100f);   // 初期の発射方向 上
            go4.GetComponent<Rigidbody2D>().AddForce(Quaternion.Euler(0, 0, amount* angle) * vec4);

            GameObject go5 = Instantiate(attackPrefab);
            go5.transform.position = new Vector3(0, -1, 0);
            Vector2 vec5 = new Vector2 (100f, 100f);   // 初期の発射方向 右上
            go5.GetComponent<Rigidbody2D>().AddForce(Quaternion.Euler(0, 0, amount* angle) * vec5);

            GameObject go6 = Instantiate(attackPrefab);
            go6.transform.position = new Vector3(0, -1, 0);
            Vector2 vec6 = new Vector2 (100f, -100f);   // 初期の発射方向 右下
            go6.GetComponent<Rigidbody2D>().AddForce(Quaternion.Euler(0, 0, amount* angle) * vec6);

            GameObject go7 = Instantiate(attackPrefab);
            go7.transform.position = new Vector3(0, -1, 0);
            Vector2 vec7 = new Vector2 (-100f, 100f);   // 初期の発射方向 左上
            go7.GetComponent<Rigidbody2D>().AddForce(Quaternion.Euler(0, 0, amount* angle) * vec7);

            GameObject go8 = Instantiate(attackPrefab);
            go8.transform.position = new Vector3(0, -1, 0);
            Vector2 vec8 = new Vector2 (-100f, -100f);   // 初期の発射方向 左下
            go8.GetComponent<Rigidbody2D>().AddForce(Quaternion.Euler(0, 0, amount* angle) * vec8);
            timer = 0f;
            amount++;
        }

    }
}