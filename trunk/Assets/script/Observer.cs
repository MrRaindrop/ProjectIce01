using UnityEngine;
using System;
using System.Collections;

public class Observer : MonoBehaviour {

    private uint _currentEventIndex = 0;    // 事件队列中当前处理的事件的序号
    private Loop.Player _currentPlayer;     // 当前玩家实例

    void Awake() {

        InitGame();
        CalcPlayerCap();
        InitPlayer();

    }

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

        if(!Loop.EventManager.IsEventQueueEmpty()){
            _currentEventIndex = Loop.EventManager.PopEventQueue();
            Loop.Event currentEvent = Loop.EventManager.EventArray[_currentEventIndex];
            float cd = currentEvent.DelayPeriod;
            float ce = currentEvent.ExpiredPeriod;
            if (cd != 0 || ce != 0) {
                StartCoroutine(DelayOrExpireEvent(currentEvent, cd, ce));
            }
        }
	}

    public void InitGame() {

        // 初始化所有的标志
        Loop.FlagManager.InitFlagArray();

        // 初始化事件队列基础设施
        Loop.EventManager.InitEventArray();
        Loop.EventManager.InitEventQueue();

        // 绑定事件处理
        Loop.EventManager.InitBindingHandlers();
    }

    // 实例化玩家角色类
    public void InitPlayer() {

        Debug.Log("-- Func : InitPlayer --");
        _currentPlayer = new Loop.Player();

    }

    // 获取当前玩家类实例， 若没有则返回null
    public Loop.Player GetCurrentPlayer() {
        if (_currentPlayer != null)
            return _currentPlayer;
        else return null;
    }

    // 初始化角色能力数值
    public void CalcPlayerCap() {

        Debug.Log("-- Func : CalcPlayerCap --");
        Loop.EnvManager.CalculatePlayerCapability();
    }


    // 延迟处理事件，若失效时间不为0则做失效处理
    private IEnumerator DelayOrExpireEvent(Loop.Event e, float delay, float expire){
        
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
