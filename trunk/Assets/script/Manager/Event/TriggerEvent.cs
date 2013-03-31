using UnityEngine;
using System.Collections;

public class TriggerEvent : MonoBehaviour {

    public Loop.EventType eventType = Loop.EventType.None;  // ��ǰ�����¼�����
    public Loop.EventType conditionEventType1 = Loop.EventType.None;  // �����¼�����
    public Loop.EventType conditionEventType2 = Loop.EventType.None;
    public Loop.EventType conditionEventType3 = Loop.EventType.None;
    public Loop.EventType conditionEventType4 = Loop.EventType.None;
    public Loop.EventType conditionEventType5 = Loop.EventType.None;
    
    //public bool isFiredOnce;  // �Ƿ������ѳ���
    //public bool isValid;  // �Ƿ���Ȼ��Ч
    //public uint firedTimes;   // �Ѵ�������
    public float delayPeriod;     // �ӳٴ���ʱ��(s)
    public float expiredPeriod;     // ʧЧʱ��(s)
    //public ArrayList _prevEvents;  // �����������¼�����б�

    void OnTriggerEnter(Collider other){
        if (other.gameObject.CompareTag("Player")) {
            
            // �������¼������ж��б�
            if (conditionEventType1 != Loop.EventType.None) {
                Loop.EventManager.EventArray[]
            }


            Loop.EventManager.FireEvent(Loop.EventManager.EventArray[(int)eventType]);
            // do something
            Debug.Log("onTriggerEnter!");
            Debug.Log(conditionEventType1);
            Debug.Log(conditionEventType2);
            Debug.Log(conditionEventType3);
            Debug.Log(conditionEventType4);
            Debug.Log(conditionEventType5);

        }
    }
}
