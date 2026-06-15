using UnityEngine;

public class SpikeGenerator : MonoBehaviour
{
    [SerializeField] private GameObject attackPrefab;    // 弾のプレハブ
    private float timer = 0f;
    [SerializeField] private float span = 1.0f;
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
            //go.transform.Rotate(new Vector3(0f, 0f, 1f), amount*10);
            Vector2 vec = new Vector2 (50f, 0f);
            go.GetComponent<Rigidbody2D>().AddForce(Quaternion.Euler(0, 0, amount*10) * vec);
            timer = 0f;
            amount++;
        }

    }
}