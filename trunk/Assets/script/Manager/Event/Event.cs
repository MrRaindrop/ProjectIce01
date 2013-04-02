using UnityEngine;
using System.Collections;

namespace Loop
{

    public class Event
    {
        public delegate void Handler();

        private Handler _handlers;  // 事件处理函数集

        private uint _index;    // 事件序号

        private GameObject _associatedObject;

        private bool _isFiredOnce;  // 是否曾经已出发

        private bool _isValid;  // 是否仍然有效

        private uint _firedTimes;   // 已触发次数

        private float _delayPeriod;     // 延迟处理时间(s)
        
        private float _expiredPeriod; // 失效时间(s)
        
        private ArrayList _prevEvents;  // 先序条件（事件序号列表）


        public Event(uint index) {
            _index = index;
            _associatedObject = null;
            _isFiredOnce = false;
            _isValid = false;
            _firedTimes = 0;
            _delayPeriod = 0f;
            _expiredPeriod = 0f;
            _prevEvents = new ArrayList();
        }

        public Event(uint index, float delayPeriod, float expiredPeriod = 0f) {
            _index = index;
            _isFiredOnce = false;
            _isValid = false;
            _firedTimes = 0;
            _delayPeriod = delayPeriod;
            _expiredPeriod = expiredPeriod;
            _prevEvents = new ArrayList();
        }

        // setters and getters
        public uint Index {
            get { return _index; }
            set { _index = value; }
        }

        public GameObject AssociatedObject {
            get { return _associatedObject; }
            set { _associatedObject = value; }
        }

        public bool IsFiredOnce {
            get { return _isFiredOnce; }
            set { _isFiredOnce = value; }
        }

        public bool IsValid
        {
            get { return _isValid; }
            set { _isValid = value; }
        }

        public uint FiredTimes
        {
            get { return _firedTimes; }
            set { _firedTimes = value; }
        }

        public float DelayPeriod
        {
            get { return _delayPeriod; }
            set { _delayPeriod = value; }
        }

        public float ExpiredPeriod
        {
            get { return _expiredPeriod; }
            set { _expiredPeriod = value; }
        }

        // 增加某个事件(的序列号)做为先序条件之一
        public void AddPrevEvents(uint index){
            if (_prevEvents.Contains(index))
                return;
            _prevEvents.Add(index);
        }

        // 从先序条件中去掉某个事件(的序列号)
        public void RmvPrevEvents(uint index){
            if (_prevEvents.Contains(index))
                _prevEvents.Remove(index);
        }

        // 测试所有条件事件是否都曾经发生过
        public bool IsAllPrevEventsFired() {
            if(_prevEvents.Count == 0)
                return true;
            foreach(uint index in _prevEvents){
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

        // 添加事件处理
        public void AddHandler(Handler h) {
            _handlers += h;
        }

    }

}
