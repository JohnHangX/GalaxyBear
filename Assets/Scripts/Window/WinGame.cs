using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinGame : BaseWindow
{

    protected WindowEnum myEnum = WindowEnum.WinGame;
    protected string resPath = "WinGame";
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
