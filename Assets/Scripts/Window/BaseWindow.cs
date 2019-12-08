using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWindow {
    protected GameObject myPerfab;
    protected GameObject myObj;
    protected Transform myTran;
    protected WindowEnum myEnum;
    protected string resPath = "";
    public BaseWindow()
    {
       
    }

    public virtual void Init()
    {

    }

    public virtual void Open()
    {
        myObj.SetActive(true);
    }

    public virtual void Close()
    {
        myObj.SetActive(false);
    }
}
