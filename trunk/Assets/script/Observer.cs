using UnityEngine;
using System;
using System.Collections;

public class Observer : MonoBehaviour {

    public uint currentEventIndex = 0;

    void Awake() {

        InitGame();
        InitPlayer();

    }

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

        if(!Loop.EventManager.IsEventQueueEmpty()){
            currentEventIndex = Loop.EventManager.PopEventQueue();
            Loop.Event currentEvent = Loop.EventManager.EventArray[currentEventIndex];
            float cd = currentEvent.DelayPeriod;
            float ce = currentEvent.ExpiredPeriod;
            if (cd != 0 || ce != 0) {
                StartCoroutine(DelayOrExpireEvent(currentEvent, cd, ce));
            }
        }
	}

    void InitGame() {

        // 初始化所有的标志
        Loop.FlagManager.InitFlagArray();

        // 初始化事件队列基础设施
        Loop.EventManager.InitEventArray();
        Loop.EventManager.InitEventQueue();

        // 绑定事件处理
        Loop.EventManager.InitBindingHandlers();
    }

    void InitPlayer() {
    }

    // 延迟处理事件，若失效时间不为0则做失效处理
    IEnumerator DelayOrExpireEvent(Loop.Event e, float delay, float expire){
        
        yield return new WaitForSeconds(delay);
        e.IsValid = true;
        e.ExecHanlders();
        
        // 失效处理
        if(expire != 0) {
            yield return new WaitForSeconds(expire);
            e.IsValid = false;
        }

    }
    
}
