using TMPro; // 添加这一行来使用TextMeshPro
using UnityEngine;
//using UnityEngine.UI; // 引入UI命名空间

public class CountdownTimer : MonoBehaviour
{
    public float timeRemaining = 60; // 设置初始时间
    public bool timerIsRunning = false; // 控制计时器是否运行
    //public Text timeText; // 引用UI文本组件
    public TextMeshProUGUI timeText; // 现在这里使用的是TextMeshProUGUI而不是UnityEngine.UI.Text

    private void Start()
    {
        // 启动计时器
        timerIsRunning = true;
    }

    private void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
                // 这里可以添加时间结束后的逻辑，比如重新开始或者返回菜单等
            }
        }
    }


    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay = Mathf.Max(0, timeToDisplay);
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        // 在这里加入了“Time Remaining: ”文本
        timeText.text = string.Format("Time Remaining: {0:00}:{1:00}", minutes, seconds);
    }

}
