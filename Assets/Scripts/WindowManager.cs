using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowManager{

    private WindowManager()
    {
    }
    private static WindowManager _instance;

    public static WindowManager Instance
    {
        get{
            if (_instance == null)
            {
                _instance = new WindowManager();
            }
            return _instance;
        } 
    }
    private Transform _windowPos;
    public Transform windowPos
    {
        get
        {
            if(_windowPos==null)
            {
                _windowPos = GameObject.FindGameObjectWithTag("WindowPos").transform;
            }
            return _windowPos;
        }
    }

    public Dictionary<WindowEnum, BaseWindow> winDic = new Dictionary<WindowEnum, BaseWindow>();
    public Dictionary<WindowEnum, BaseWindow> winObjDic = new Dictionary<WindowEnum, BaseWindow>();
    public BaseWindow curWin;
    public void Init()
    {
        OpenWin(WindowEnum.Win1);
    }

    public void OpenWin(WindowEnum win)
    {
        if (curWin!=null)
        {
            curWin.Close();
        }
        if(winDic.ContainsKey(win) && winDic[win]!=null)
        {
            winDic[win].Open();
        }
        else
        {
            winDic[win] = GetWinByEnum(win);
        }
        curWin = winDic[win];
    }

    private BaseWindow GetWinByEnum(WindowEnum win)
    {
        string typeName = win.ToString();
        Type type = typeof(BaseWindow);
        BaseWindow myWin = type.Assembly.CreateInstance(typeName) as BaseWindow;
        //BaseWindow myWin = Activator.CreateInstance(type) as BaseWindow;
        myWin.Init();
        return myWin;
    }
}
