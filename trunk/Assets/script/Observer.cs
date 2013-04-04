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

        // ��ʼ�����еı�־
        Loop.FlagManager.InitFlagArray();

        // ��ʼ���¼����л�����ʩ
        Loop.EventManager.InitEventArray();
        Loop.EventManager.InitEventQueue();

        // ���¼�����
        Loop.EventManager.InitBindingHandlers();
    }

    void InitPlayer() {
    }

    // �ӳٴ����¼�����ʧЧʱ�䲻Ϊ0����ʧЧ����
    IEnumerator DelayOrExpireEvent(Loop.Event e, float delay, float expire){
        
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
