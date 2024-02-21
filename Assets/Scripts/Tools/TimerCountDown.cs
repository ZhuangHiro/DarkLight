using UnityEngine;

using System.Collections;

using UnityEngine;

using System.Collections;

using UnityEngine.UI;
[RequireComponent(typeof(Text))]
public class TimerCountDown : MonoBehaviour
{

    private static TimerCountDown _instance = null;
    public static TimerCountDown Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject go = new GameObject();
                go.name = "TimerCountDown";
                Debug.LogError("TimerCountDown Instance  is null，already created..");
            }
            return _instance;
        }
    }


    public int TotalTime = 5;//总时间

    public Text TimeText;//在UI里显示时间

    private int mumite;//分

    private int second;//秒

    private bool TimeUp;

    void Awake()
    {
        _instance = this;
        TimeText = GetComponent<Text>();
    }

    void Start()
    {
        //运行一开始就进行协程
        StartCoroutine(StartTime());
    }

    public IEnumerator StartTime()
    {

        while (TotalTime >= 0)
        {
            //由于开始倒计时，需要经过一秒才开始减去1秒，所以要先用yield return new WaitForSeconds(1),然后再进行TotalTime--,运算.
            yield return new WaitForSeconds(1);

            TotalTime--;

            // TimeText.text = "Time:" + TotalTime;

            if (TotalTime <= 0)
            {
                //如果倒计时剩余总时间为0时，就执行Action
                TimeOver();
            }
            //输出显示分
            mumite = TotalTime / 60;
            //输出显示秒
            second = TotalTime % 60;

            string length = mumite.ToString();
            if (second >= 10)
            {
                //如果秒大于10的时候，就输出格式为 00：00
                TimeText.text = "0" + mumite + ":" + second;
            }
            else
            {
                if (TimeUp)
                {
                    //解决计时为0的时候的bug
                    TimeText.text = "0" + mumite + ":00";
                }
                else
                {
                    //如果秒小于10的时候，就输出格式为 00：00
                    TimeText.text = "0" + mumite + ":0" + second;
                }
            }
        }
    }

    public void TimeOver()
    {
        TimeUp = true;
    }

    public bool GetTimeUp()
    {
        return TimeUp;
    }

}