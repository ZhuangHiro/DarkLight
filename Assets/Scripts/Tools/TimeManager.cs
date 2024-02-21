using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{

    //private static TimeManager _instance = null;

    //public static TimeManager Instance
    //{
    //    get
    //    {
    //        if (_instance == null)
    //        {
    //            GameObject go = new GameObject();
    //            go.name = "TimeManager";
    //            go.AddComponent<TimeManager>();
    //            Debug.LogError("TimerManager Instance  is null");
    //        }
    //        return _instance;
    //    }
    //}
  
    private float totalTime = 0;
    // 当前时间
    private float timer = 0;

    void Awake()
    {
        //_instance = this;
    }

    void Update()
    {


    }

    public void TimerToDo(Action action, float MaxTime = 1)
    {
        //累加每帧消耗时间
        totalTime += Time.deltaTime;
        if (totalTime >= MaxTime)//每过1秒执行一次
        {
            timer++;
            action();

            totalTime = 0;

            // Debug.Log("Time:" + timer);
        }
    }

    public float GetTimer()
    {
        return timer;
    }

    public void SetTimer(int time)
    {
        this.timer = time;
    }

    public void AddTime(float time = 10)
    {
        timer += time;
    }

    public void MinusTime(float time = 10)
    {
        timer -= time;
    }
}
