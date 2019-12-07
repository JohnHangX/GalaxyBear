using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour {

    public static Main Instance;
    public delegate void UpdateHandle();
    public UpdateHandle onUpdate;
    public delegate void FixedUpdateHandle();
    public FixedUpdateHandle onFixedUpdate;
    void Awake()
    {
        Instance = this;
    }
	void Start () {
        WindowManager.Instance.Init();
	}
	
	// Update is called once per frame
	void Update () {
        if(onUpdate != null)
            onUpdate();
	}

    void FixedUpdate()
    {
        if(onFixedUpdate!=null)
            onFixedUpdate();
    }
}
