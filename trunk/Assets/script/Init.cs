using UnityEngine;
using System;
using System.Collections;

public class Init : MonoBehaviour {

	// Use this for initialization
	void Start () {

        InitEventArray();
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    // 初始化事件列表
    private void InitEventArray() {

        Debug.Log("-- Func:InitEventArray --");

        Loop.EventManager.EventArray = new Loop.Event[Loop.EventConstants.TOTAL_NUM];

        Loop.EventManager.EventArray[0] = null;

        for (uint i = 1; i <= Loop.EventConstants.KEY_NUM; i++) {
            Loop.EventManager.EventArray[i] = new Loop.Event(i);
        }

        for (uint i = 101; i < 101 + Loop.EventConstants.GATE_NUM; i++) {
            Loop.EventManager.EventArray[i] = new Loop.Event(i);
        }
     
    }
}
