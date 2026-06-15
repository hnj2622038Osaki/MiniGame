using UnityEngine;
using UnityEngine.SceneManagement; // シーン移動に必要

public class ToStart : MonoBehaviour
{
    // 待機する時間（秒）
    public float waitTime = 8.0f;
    // 移動先のシーン名
    public string StartScene = "StartScene";

    private float timer = 0f;

    void Update()
    {
        // 経過時間をカウント
        timer += Time.deltaTime;

        if (timer >= waitTime)
        {
            // 指定時間になったらシーンを読み込む
            SceneManager.LoadScene(StartScene);
        }
        GetComponent<AudioSource>();
    }
}

