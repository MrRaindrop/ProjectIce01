
/* Observer对象: 从头到尾一直存在于游戏中
 * 作用：初始化，处理事件队列，保存和装载 */

using UnityEngine;
using System;
using System.Collections;

public class Observer : MonoBehaviour {

    private uint _currentEventIndex;    // 事件队列中当前处理的事件的序号
    private Loop.Player _currentPlayer;     // 当前玩家实例

    void Awake() {

        _currentEventIndex = 0;
        Init();

    }

	// Use this for initialization
	void Start () {

        _currentPlayer.AttachedGameObject.AddComponent<PlayerMove>();
        _currentPlayer.EnableAct();
        _currentPlayer.EnableInput();

	}
	
	// Update is called once per frame
    void Update() {

        StartCoroutine(PopAndExecEvent());
        StartCoroutine(PopAndExecMessage());

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

    // 取消息队列并执行（区分同步和异步事件的执行方式）
    public IEnumerator PopAndExecMessage() {
        if (!Loop.MessageManager.IsMessageQueueEmpty()) {

            Loop.Message currentMessage = Loop.MessageManager.PopMessageQueue();

            Debug.Log("Pop Message Queue and execute MessageHandler : " + currentMessage.Type);

            float cd = currentMessage.DelayPeriod;

            if (cd != 0) {
                yield return StartCoroutine(DelayExecMessage(currentMessage, cd));
            } else {
                currentMessage.ExecHanlders();
            }

        }
        else
            yield return null;
    }

    // 初始化新游戏
    private void Init() {

        InitGameInfra();
        CalcPlayerCap();
        InitPlayer();

    }

    // 初始化并装载游戏
    private void InitAndLoadGameData() {

        // 初始化新游戏
        Init();

        // 装载游戏数据
        LoadGameData();

    }

    // 初始化游戏基础设施
    public void InitGameInfra() {

        // 初始化所有的标志
        Loop.FlagManager.InitFlagArray();

        // 初始化事件队列基础设施
        Loop.EventManager.InitEventArray();
        Loop.EventManager.InitEventQueue();

        // 初始化消息队列
        Loop.MessageManager.InitMessageQueue();

        // 绑定事件处理
        Loop.EventManager.InitBindingHandlers();

        // 初始化世界数组
        Loop.WorldManager.InitWorldArray();

        // 初始化摄像机
        Loop.CameraManager.InitAllCameras();
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

    // 延迟处理消息
    private IEnumerator DelayExecMessage(Loop.Message msg, float delay){

        yield return new WaitForSeconds(delay);
        msg.ExecHanlders();

    }

    // 游戏暂停
    public void PauseGame(){

        // 停止输入

        // 停止角色行动

        // pause是同步事件

    }

    // 游戏保存
    public IEnumerator SaveGame() {

        Debug.Log("-- Func : Observer.SaveGame() --");

        // TODO : 保存确认对话框
        
        // TODO : 摄像机效果

        SaveGameData();

        // TODO : 摄像机效果

        yield return null;
        
    }

    // 切换世界
    public void SwitchWorld(Loop.WorldName targetWorld) {

        Debug.Log("-- Func : Observer.SwitchWorld --");

        _currentPlayer.DisableInput();

        StartCoroutine(WaitAndSwitchWorld(targetWorld, Loop.WorldConstants.TIME_BEFORE_SWITCH));

    }

    // 等待特定秒数以后开始切换
    private IEnumerator WaitAndSwitchWorld(Loop.WorldName targetWorld, float seconds) {
        
        Debug.Log("Switch world after " + seconds + " seconds...");

        yield return new WaitForSeconds(seconds);

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

    // 保存游戏数据
    private void SaveGameData(){

        Debug.Log("-- Func : SaveGameData --");

        // Flags
        Loop.FlagManager.SaveFlagData();

        // Events
        Loop.EventManager.SaveEventData();

        // Environments
        Loop.EnvManager.SaveEnvData();
        
        // Worlds
        Loop.WorldManager.SaveWorldData();

        // Camera
        Loop.CameraManager.SaveCameraData();

        // Characters
        Loop.CharacterManager.SaveCharacterData();

        /* ... */

    }

    // 装载游戏数据
    private void LoadGameData() {

        // Flags
        Loop.FlagManager.LoadFlagData();

        // Events
        Loop.EventManager.LoadEventData();

        // Environments
        Loop.EnvManager.LoadEnvData();

        // Worlds
        Loop.WorldManager.LoadWorldData();

        // Camera
        Loop.CameraManager.RecoverCamera();

        // Characters
        Loop.CharacterManager.LoadCharacterData();

        // 恢复主角位置
        Loop.CharacterManager.RecoverPlayerPosition();

        /* ... */
    }
    
}
