
/* Observer����: ��ͷ��βһֱ��������Ϸ��
 * ���ã���ʼ���������¼����У������װ�� */

using UnityEngine;
using System;
using System.Collections;

public class Observer : MonoBehaviour {

    private uint _currentEventIndex;    // �¼������е�ǰ������¼������
    private Loop.Player _currentPlayer;     // ��ǰ���ʵ��

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

    // ȡ��Ϣ���в�ִ�У�����ͬ�����첽�¼���ִ�з�ʽ��
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

    // ��ʼ������Ϸ
    private void Init() {

        InitGameInfra();
        CalcPlayerCap();
        InitPlayer();

    }

    // ��ʼ����װ����Ϸ
    private void InitAndLoadGameData() {

        // ��ʼ������Ϸ
        Init();

        // װ����Ϸ����
        LoadGameData();

    }

    // ��ʼ����Ϸ������ʩ
    public void InitGameInfra() {

        // ��ʼ�����еı�־
        Loop.FlagManager.InitFlagArray();

        // ��ʼ���¼����л�����ʩ
        Loop.EventManager.InitEventArray();
        Loop.EventManager.InitEventQueue();

        // ��ʼ����Ϣ����
        Loop.MessageManager.InitMessageQueue();

        // ���¼�����
        Loop.EventManager.InitBindingHandlers();

        // ��ʼ����������
        Loop.WorldManager.InitWorldArray();

        // ��ʼ�������
        Loop.CameraManager.InitAllCameras();
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

    // �ӳٴ�����Ϣ
    private IEnumerator DelayExecMessage(Loop.Message msg, float delay){

        yield return new WaitForSeconds(delay);
        msg.ExecHanlders();

    }

    // ��Ϸ��ͣ
    public void PauseGame(){

        // ֹͣ����

        // ֹͣ��ɫ�ж�

        // pause��ͬ���¼�

    }

    // ��Ϸ����
    public IEnumerator SaveGame() {

        Debug.Log("-- Func : Observer.SaveGame() --");

        // TODO : ����ȷ�϶Ի���
        
        // TODO : �����Ч��

        SaveGameData();

        // TODO : �����Ч��

        yield return null;
        
    }

    // �л�����
    public void SwitchWorld(Loop.WorldName targetWorld) {

        Debug.Log("-- Func : Observer.SwitchWorld --");

        _currentPlayer.DisableInput();

        StartCoroutine(WaitAndSwitchWorld(targetWorld, Loop.WorldConstants.TIME_BEFORE_SWITCH));

    }

    // �ȴ��ض������Ժ�ʼ�л�
    private IEnumerator WaitAndSwitchWorld(Loop.WorldName targetWorld, float seconds) {
        
        Debug.Log("Switch world after " + seconds + " seconds...");

        yield return new WaitForSeconds(seconds);

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

    // ������Ϸ����
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

    // װ����Ϸ����
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

        // �ָ�����λ��
        Loop.CharacterManager.RecoverPlayerPosition();

        /* ... */
    }
    
}
