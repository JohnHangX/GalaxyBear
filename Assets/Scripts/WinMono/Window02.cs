﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Window02 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(KeyCode.Space))
            WindowManager.Instance.OpenWin(WindowEnum.Win1);
	}
}
