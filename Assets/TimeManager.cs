using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 计时器
/// </summary>
public class TimeManager{
    private List<TimeoutDir> timeoutList = new List<TimeoutDir>();
    private TimeManager() {
        Main.Instance.onUpdate += OnUpdate;
    }
    private static TimeManager _instance;

    public static TimeManager Instance
    {
        get{
            if (_instance == null)
            {
                _instance = new TimeManager();
            }
            return _instance;
        }
        
    }
    private void OnUpdate()
    {
        if (timeoutList.Count <= 0)
            return;
        for (int i = 0; i < timeoutList.Count; i++)
        {
            timeoutList[i].OnUpdate();
        }
    }

    public TimeoutDir AddTimeOut(float time, Action callback)
    {
        TimeoutDir dir = new TimeoutDir(time, callback);
        dir.AddOverCallback(() => { RemoveTimeout(dir); });
        timeoutList.Add(dir);
        return dir;
    }
    public TimeoutDir AddTimeOut(float interval, Action intervalCallback, float time, Action callback)
    {
        TimeoutDir dir = new TimeoutDir(interval, intervalCallback, time, callback);
        dir.AddOverCallback(() => { RemoveTimeout(dir); });
        timeoutList.Add(dir);
        return dir;
    }

    public void RemoveTimeout(TimeoutDir dir)
    {
        timeoutList.Remove(dir);
        dir = null;
    }
}

public class TimeoutDir
{
    float countTime;
    Action myCallback;
    Action OverCallback;
    Action IntervalCallback;
    float deltalTime;
    float myInterval;
    float intervalDetal;
    public TimeoutDir(float time, Action callback)
    {
        countTime = time;
        myCallback = callback;
        deltalTime = time;
    }
    public TimeoutDir(float interval, Action intervalCB, float time, Action callback)
    {
        countTime = time;
        myCallback = callback;
        deltalTime = time;
        myInterval = interval;
        IntervalCallback = intervalCB;
    }
    public void AddOverCallback(Action callback)
    {
        OverCallback = callback;
    }
    public void OnUpdate()
    {
        if (deltalTime > 0)
        {
            deltalTime -= Time.deltaTime;

            if (IntervalCallback!=null)
            {
                if(intervalDetal < myInterval)
                {
                    intervalDetal += Time.deltaTime;
                }
                else
                {
                    intervalDetal = 0;
                    IntervalCallback();
                }
            }
        }
        else
        {
            myCallback();
            OverCallback();
        }
    }
}
