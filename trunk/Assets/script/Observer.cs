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

        // ��ʼ�����еı�־
        Loop.FlagManager.InitFlagArray();

        // ��ʼ���¼����л�����ʩ
        Loop.EventManager.InitEventArray();
        Loop.EventManager.InitEventQueue();

        // ���¼�����
        Loop.EventManager.InitBindingHandlers();
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
        Loop.EnvManager.CalculatePlayerCapability();
    }


    // �ӳٴ����¼�����ʧЧʱ�䲻Ϊ0����ʧЧ����
    private IEnumerator DelayOrExpireEvent(Loop.Event e, float delay, float expire){
        
        yield return new WaitForSeconds(delay);
        e.IsValid = true;
        e.ExecHanlders();
        
        // ʧЧ����
        if(expire != 0) {
            yield return new WaitForSeconds(expire);
            e.IsValid = false;
        }

    }
    
}
