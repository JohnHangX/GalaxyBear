using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinStart : BaseWindow
{

    protected WindowEnum myEnum = WindowEnum.WinStart;
    protected string resPath = "WinStart";
    public override void Init()
    {
        if (resPath == "")
        {
            return;
        }
        myPerfab = Resources.Load<GameObject>(resPath);
        myObj = GameObject.Instantiate(myPerfab, WindowManager.Instance.windowPos, false);
        BearGestureListener.Instance.OnRaiseRightHand += OnRaiseRightHand;
    }

    private void OnRaiseRightHand()
    {
        if (WindowManager.Instance.curWinEnum == myEnum)
        {
            WindowManager.Instance.OpenWin(WindowEnum.WinGame);
        }
    }

    ~WinStart()
    {

    }
}
