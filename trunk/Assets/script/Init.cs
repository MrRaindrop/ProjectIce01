using UnityEngine;
using System;
using System.Collections;

public class Init : MonoBehaviour {

	// Use this for initialization
	void Start () {

        Loop.FlagManager.InitFlagArray();
        Loop.EventManager.InitEventArray();

        // ���¼�����
        Loop.EventManager.InitBindingHandlers();
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    
}
