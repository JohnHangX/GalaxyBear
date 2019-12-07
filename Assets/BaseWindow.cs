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
    public virtual void SetActive(bool isActive)
    {
        if(isActive)
        {
            myObj.SetActive(true);
        }
        else
        {
            myObj.SetActive(false);
        }
    }
}
