using TMPro; // 添加这一行来使用TextMeshPro
using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEngine.UI; // 引入UI命名空间

public class CountdownTimer : MonoBehaviour
{
    public float timeRemaining = 30; // 设置初始时间
    public bool timerIsRunning = false; // 控制计时器是否运行
    //public Text timeText; // 引用UI文本组件
    public TextMeshProUGUI timeText; // 现在这里使用的是TextMeshProUGUI而不是UnityEngine.UI.Text
    public float initialTime;

    public float timeUsed;



    private void Start()
    {
        // 启动计时器
        timeText = GameObject.Find("Timer").GetComponent<TextMeshProUGUI>();
        //timerIsRunning = true;
        string sceneName = SceneManager.GetActiveScene().name;
        switch (sceneName)
        {
            case "level1":
                initialTime = 60;
                break;
            case "level2":
                initialTime = 90;
                break;
            case "level3":
                initialTime = 120;
                break;
        }
        //timeText.text = "Test Start";
        ResetTimer();
        Debug.Log($"Initial time for {sceneName} is {initialTime}");

    }
    private void OnEnable()
    {
        //ResetTimer();
    }


    private void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                //Debug.Log($"Time Remaining: {timeRemaining}"); // Add this for debugging
                timeUsed = initialTime - timeRemaining;
                DisplayTime(timeRemaining);
            }
            else
            {
                Debug.Log("Time has run out!");
                //timeRemaining = 0;
                timerIsRunning = false;
                GlobalSceneManager.Instance.UpdateLastScene(SceneManager.GetActiveScene().name);
                SceneManager.LoadScene("GameOver");
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
        string formattedTime = string.Format("Time Remaining: {0:00}:{1:00}", minutes, seconds);
        //Debug.Log($"Formatted Time: {formattedTime}"); // Debugging
        timeText.text = formattedTime;
    }
        public void ResetTimer()
    {
        timeRemaining = initialTime; // Reset to initial time
        timerIsRunning = true; // Start the timer running
        timeUsed = 0;
        DisplayTime(timeRemaining); // Update display immediately
    }

}
