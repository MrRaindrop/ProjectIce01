
/* Observer����: ��ͷ��βһֱ��������Ϸ��
 * ���ã���ʼ���������¼����� */

using UnityEngine;
using System;
using System.Collections;

public class Observer : MonoBehaviour {

    private uint _currentEventIndex = 0;    // �¼������е�ǰ������¼������
    private Loop.Player _currentPlayer;     // ��ǰ���ʵ��

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

    // ȡ�¼����в�ִ�У�����ͬ�����첽�¼���ִ�з�ʽ��
    public IEnumerator PopAndExecEvent(){
        if (!Loop.EventManager.IsEventQueueEmpty() && !Loop.EventManager.SyncFlag)
        {
            _currentEventIndex = Loop.EventManager.PopEventQueue();
            Loop.Event currentEvent = Loop.EventManager.EventArray[_currentEventIndex];

            // �����¼��Ƿ����첽ִ��
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

        // ��ʼ�����еı�־
        Loop.FlagManager.InitFlagArray();

        // ��ʼ���¼����л�����ʩ
        Loop.EventManager.InitEventArray();
        Loop.EventManager.InitEventQueue();

        // ���¼�����
        Loop.EventManager.InitBindingHandlers();

        // ��ʼ����������
        Loop.WorldManager.InitWordArray();

        // ��ʼ�������
        Loop.CameraManager.initAllCameras();
    }

    // ʵ������ҽ�ɫ��
    public void InitPlayer() {

        Debug.Log("-- Func : InitPlayer --");
        _currentPlayer = new Loop.Player();

    }

    // ��ȡ��ǰ�����ʵ���� ��û���򷵻�null
    public Loop.Player GetCurrentPlayer() {
        if (_currentPlayer != null)
            return _currentPlayer;
        else return null;
    }

    // ��ʼ����ɫ������ֵ
    public void CalcPlayerCap() {

        Debug.Log("-- Func : CalcPlayerCap --");
        Loop.CharacterManager.CalculatePlayerCapability();
    }


    // �ӳٴ����¼�����ʧЧʱ�䲻Ϊ0����ʧЧ����
    private IEnumerator DelayOrExpireEvent(Loop.Event e, float delay, float expire){
        
        yield return new WaitForSeconds(delay);
        e.IsValid = true;
        e.ExecHanlders();
        Loop.EventManager.SyncFlag = false;
        
        // ʧЧ����
        if(expire != 0) {
            yield return new WaitForSeconds(expire);
            e.IsValid = false;
        }

    }

    // ��Ϸ��ͣ
    public void PauseGame(){

    }

    // ��Ϸ����
    public void SaveGame() {

        Debug.Log("-- Func : Observer.SaveGame() --");

        /* TODO : ���� */ 
    }

    // �л�����
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

    // �ȴ��ض������Ժ�ָ��������
    private IEnumerator WaitToInput(float seconds) {
        Debug.Log("Wait to Recover Player Input after " + seconds + " s.");
        yield return new WaitForSeconds(seconds);
        _currentPlayer.EnableInput();
    }
    
}
