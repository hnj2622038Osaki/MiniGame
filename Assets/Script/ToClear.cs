using UnityEngine;
using UnityEngine.SceneManagement;

public class ToClear : MonoBehaviour
{
    // 待機する時間（秒）
    public float waitTime = 12.0f;
    // 移動先のシーン名
    public string ClearScene = "ClearScene";

    private float timer = 0f;

    // Update is called once per frame
    void Update()
    {
        // 経過時間をカウント
        timer += Time.deltaTime;

        if (timer >= waitTime)
        {
            // 指定時間になったらシーンを読み込む
            SceneManager.LoadScene(ClearScene);
        }
        GetComponent<AudioSource>();
    }
}
