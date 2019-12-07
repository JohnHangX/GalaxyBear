using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win1 : BaseWindow
{

    protected WindowEnum myEnum = WindowEnum.Win1;
    protected string resPath = "Window01";
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
