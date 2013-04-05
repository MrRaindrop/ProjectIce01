
/* Observer对象: 从头到尾一直存在于游戏中
 * 作用：初始化，处理事件队列 */

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
    void Update() {

        StartCoroutine(PopAndExecEvent());

    }

    // 取事件队列并执行（区分同步和异步事件的执行方式）
    public IEnumerator PopAndExecEvent(){
        if (!Loop.EventManager.IsEventQueueEmpty() && !Loop.EventManager.SyncFlag)
        {
            _currentEventIndex = Loop.EventManager.PopEventQueue();
            Loop.Event currentEvent = Loop.EventManager.EventArray[_currentEventIndex];

            // 出队事件是否是异步执行
            if (currentEvent.IsAsync)
                Loop.EventManager.SyncFlag = false;
            else
                Loop.EventManager.SyncFlag = true;

            Debug.Log("Pop Event Queue and execute Event : " + (Loop.EventType)currentEvent.Index);
            float cd = currentEvent.DelayPeriod;
            float ce = currentEvent.ExpiredPeriod;
            
            if (cd != 0 || ce != 0)
            {
                yield return StartCoroutine(DelayOrExpireEvent(currentEvent, cd, ce));
            }
            else
            {
                currentEvent.IsValid = true;
                currentEvent.ExecHanlders();
                Loop.EventManager.SyncFlag = false;
            }
        } else if(Loop.EventManager.SyncFlag) {
            yield return null;
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

        // 初始化世界数组
        Loop.WorldManager.InitWordArray();

        // 初始化摄像机
        Loop.CameraManager.initAllCameras();
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
        Loop.CharacterManager.CalculatePlayerCapability();
    }


    // 延迟处理事件，若失效时间不为0则做失效处理
    private IEnumerator DelayOrExpireEvent(Loop.Event e, float delay, float expire){
        
        yield return new WaitForSeconds(delay);
        e.IsValid = true;
        e.ExecHanlders();
        Loop.EventManager.SyncFlag = false;
        
        // 失效处理
        if(expire != 0) {
            yield return new WaitForSeconds(expire);
            e.IsValid = false;
        }

    }

    // 游戏暂停
    public void PauseGame(){

    }

    // 游戏保存
    public void SaveGame() {

        Debug.Log("-- Func : Observer.SaveGame() --");

        /* TODO : 保存 */ 
    }

    // 切换世界
    public void SwitchWorld(Loop.WorldName targetWorld) {

        _currentPlayer.DisableInput();

        StartCoroutine(WaitAndSwitchWorld(targetWorld, Loop.WorldConstants.TIME_BEFORE_SWITCH));

    }

    private IEnumerator WaitAndSwitchWorld(Loop.WorldName targetWorld, float seconds) {
        
        Debug.Log("Switch world after " + seconds + " seconds...");
        yield return new WaitForSeconds(seconds);

        SaveGame();

        Loop.WorldManager.SwitchToWorld(targetWorld);
        _currentPlayer.SwitchToWorld(targetWorld);
        Loop.CameraManager.SwitchWorldCamera(targetWorld);

        StartCoroutine(WaitToInput(Loop.WorldConstants.TIME_AFTER_SWITCH));
    }

    // 等待特定秒数以后恢复玩家输入
    private IEnumerator WaitToInput(float seconds) {
        Debug.Log("Wait to Recover Player Input after " + seconds + " s.");
        yield return new WaitForSeconds(seconds);
        _currentPlayer.EnableInput();
    }
    
}
