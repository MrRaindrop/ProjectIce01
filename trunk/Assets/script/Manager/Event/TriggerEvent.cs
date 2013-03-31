using UnityEngine;
using System.Collections;

public class TriggerEvent : MonoBehaviour {

    public Loop.EventType eventType = Loop.EventType.None;  // 当前触发事件类型
    public Loop.EventType conditionEventType1 = Loop.EventType.None;  // 条件事件类型
    public Loop.EventType conditionEventType2 = Loop.EventType.None;
    public Loop.EventType conditionEventType3 = Loop.EventType.None;
    public Loop.EventType conditionEventType4 = Loop.EventType.None;
    public Loop.EventType conditionEventType5 = Loop.EventType.None;
    
    //public bool isFiredOnce;  // 是否曾经已出发
    //public bool isValid;  // 是否仍然有效
    //public uint firedTimes;   // 已触发次数
    public float delayPeriod;     // 延迟处理时间(s)
    public float expiredPeriod;     // 失效时间(s)
    //public ArrayList _prevEvents;  // 先序条件（事件序号列表）

    void OnTriggerEnter(Collider other){
        if (other.gameObject.CompareTag("Player")) {
            
            // 将条件事件加入判断列表
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
