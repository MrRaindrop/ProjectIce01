using UnityEngine;
using System.Collections;

// 不能在地图上通过添加事件触发器添加Message
// 只能由程序员来定义Message及其消息处理器
// Message是始终是异步执行的
// can't trigger messages in TriggerEvent.cs
// only programmer can use it
// Message is always asynchronous

namespace Loop
{
    public class Message {

        public delegate void Handler();

        private MessageType _type;    // 消息类型
        private float _delayPeriod;     // 延迟处理时间(s) - 立即发送，延时处理
        private ArrayList _prevEvents;  // 先序条件（事件序号列表）
        protected Handler _handlers;  // 消息处理函数集
        private System.Object _param1;      // 可选参数1
        private System.Object _param2;      // 可选参数2

        // set and get

        public MessageType Type {
            get { return _type; }
            set { _type = value; }
        }

        public float DelayPeriod
        {
            get { return _delayPeriod; }
            set { _delayPeriod = value; }
        }

        public ArrayList PrevEvents
        {
            get { return _prevEvents; }
            set { _prevEvents = value; }
        }

        public System.Object Param1
        {
            get { return _param1; }
            set { _param1 = value; }
        }

        public System.Object Param2
        {
            get { return _param2; }
            set { _param2 = value; }
        }

        // methods

        // 构造函数

        public Message(MessageType type, Handler h,
            System.Object extraParam1 = null, System.Object extraParam2 = null) {
            _type = type;
            _delayPeriod = 0f;
            _handlers += h;
            _param1 = extraParam1;
            _param2 = extraParam2;
        }

        public Message (MessageType type, float delayPeriod,
            Handler h, System.Object extraParam1, System.Object extraParam2)
        {
            _type = type;
            _delayPeriod = delayPeriod;
            _handlers += h;
            _param1 = extraParam1;
            _param2 = extraParam2;
        }

        // 增加某个事件(的序列号)做为先序条件之一
        public void AddPrevEvents(uint index)
        {
            if (_prevEvents.Contains(index))
                return;
            _prevEvents.Add(index);
        }

        // 从先序条件中去掉某个事件(的序列号)
        public void RmvPrevEvents(uint index)
        {
            if (_prevEvents.Contains(index))
                _prevEvents.Remove(index);
        }

        // 测试所有条件事件是否都曾经发生过
        public bool IsAllPrevEventsFired()
        {
            if (_prevEvents.Count == 0)
                return true;
            foreach (uint index in _prevEvents)
            {
                if (EventManager.EventArray[index].IsFiredOnce == false)
                    return false;
            }
            return true;
        }

        // 测试所有条件事件是否都仍然有效
        public bool IsAllPrevEventsValid()
        {
            Debug.Log("-- Func : IsAllPrevEventsValid --");

            if (_prevEvents.Count == 0)
                return true;
            foreach (uint index in _prevEvents)
            {
                if (EventManager.EventArray[index].IsValid == false)
                    return false;
            }
            return true;
        }

        // 添加消息处理器
        public void AddHandler(Handler h) {
            _handlers += h;
        }

        // 执行消息处理器
        public void ExecHanlders() {
            _handlers();
        }


    }

}
