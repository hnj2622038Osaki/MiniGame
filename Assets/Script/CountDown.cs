using TMPro;
using UnityEngine;

public class CountDown : MonoBehaviour
{
    GameObject timerText;
    [SerializeField] float time = 12.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timerText = GameObject.Find("Time");
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        timerText.GetComponent<TextMeshProUGUI>().text = time.ToString("F1");
    }
}
