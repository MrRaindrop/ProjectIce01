using UnityEngine;
using System.Collections;

namespace Loop
{

    public class Event
    {
        public delegate void Handler();

        private Handler _handlers;  // �¼���������
        private uint _index;    // �¼����
        private bool _isFiredOnce;  // �Ƿ�����������
        private bool _isValid;  // �Ƿ���Ȼ��Ч
        private uint _firedTimes;   // �Ѵ�������
        private float _delayPeriod;     // �ӳٴ���ʱ��(s) - ������������ʱ����      
        private float _expiredPeriod; // ʧЧʱ��(s)
        private ArrayList _prevEvents;  // �����������¼�����б�

        // �¼��Ĺ��캯����ָ���¼������
        public Event(uint index) {
            _index = index;
            _isFiredOnce = false;
            _isValid = false;
            _firedTimes = 0;
            _delayPeriod = 0f;
            _expiredPeriod = 0f;
            _prevEvents = new ArrayList();
        }

        // �¼����캯������ָ���¼�����š��ӳٴ���ʱ�䡢ʧЧʱ��
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

        // ����ĳ���¼�(�����к�)��Ϊ��������֮һ
        public void AddPrevEvents(uint index){
            if (_prevEvents.Contains(index))
                return;
            _prevEvents.Add(index);
        }

        // ������������ȥ��ĳ���¼�(�����к�)
        public void RmvPrevEvents(uint index){
            if (_prevEvents.Contains(index))
                _prevEvents.Remove(index);
        }

        // �������������¼��Ƿ�����������
        public bool IsAllPrevEventsFired() {
            if(_prevEvents.Count == 0)
                return true;
            foreach(uint index in _prevEvents){
                if (EventManager.EventArray[index].IsFiredOnce == false)
                    return false;
            }
            return true;
        }

        // �������������¼��Ƿ���Ȼ��Ч
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

        // ����¼�����
        public void AddHandler(Handler h) {
            _handlers += h;
        }

        // ִ���¼�������
        public void ExecHanlders(){
            _handlers();
        }

    }

}
