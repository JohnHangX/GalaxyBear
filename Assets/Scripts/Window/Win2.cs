using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win2 : BaseWindow
{

    protected WindowEnum myEnum = WindowEnum.Win2;
    protected string resPath = "Window02";
    public override void Init()
    {
        if (resPath == "")
        {
            return;
        }
        myPerfab = Resources.Load<GameObject>(resPath);
        myObj = GameObject.Instantiate(myPerfab, WindowManager.Instance.windowPos, false);
    }
}
