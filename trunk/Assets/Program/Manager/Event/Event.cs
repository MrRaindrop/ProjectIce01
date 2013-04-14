using UnityEngine;
using System.Collections;

namespace Loop
{

    public class Event
    {
        public delegate void Handler();

        protected bool _isAsync;    // �Ƿ��첽ִ��,Ĭ��Ϊͬ��ִ��
        protected Handler _handlers;  // �¼���������
        protected uint _index;    // �¼����
        protected bool _isFiredOnce;  // �Ƿ�����������
        protected bool _isValid;  // �Ƿ���Ȼ��Ч
        protected uint _firedTimes;   // �Ѵ�������
        protected float _delayPeriod;     // �ӳٴ���ʱ��(s) - ������������ʱ����      
        protected float _expiredPeriod; // ʧЧʱ��(s)
        protected ArrayList _prevEvents;  // �����������¼�����б�

        // �¼��Ĺ��캯����ָ���¼������
        public Event(uint index)
        {
            _index = index;
            _isAsync = false;
            _isFiredOnce = false;
            _isValid = false;
            _firedTimes = 0;
            _delayPeriod = 0f;
            _expiredPeriod = 0f;
            _prevEvents = new ArrayList();
        }

        // �¼��Ĺ��캯����ָ���¼�����š��Ƿ��첽ִ��
        public Event(uint index, bool isAsync)
        {
            _index = index;
            _isAsync = isAsync;
            _isFiredOnce = false;
            _isValid = false;
            _firedTimes = 0;
            _delayPeriod = 0f;
            _expiredPeriod = 0f;
            _prevEvents = new ArrayList();
        }

        // �¼����캯������ָ���¼�����š��ӳٴ���ʱ�䡢ʧЧʱ��
        public Event(uint index, float delayPeriod, float expiredPeriod = 0f)
        {
            _index = index;
            _isAsync = false;
            _isFiredOnce = false;
            _isValid = false;
            _firedTimes = 0;
            _delayPeriod = delayPeriod;
            _expiredPeriod = expiredPeriod;
            _prevEvents = new ArrayList();
        }

        // �¼����캯������ָ���¼�����š��ӳٴ���ʱ�䡢ʧЧʱ�䡢�Ƿ��첽ִ��
        public Event(uint index, bool isAsync, float delayPeriod, float expiredPeriod = 0f)
        {
            _index = index;
            _isAsync = isAsync;
            _isFiredOnce = false;
            _isValid = false;
            _firedTimes = 0;
            _delayPeriod = delayPeriod;
            _expiredPeriod = expiredPeriod;
            _prevEvents = new ArrayList();
        }

        // setters and getters

        public bool IsAsync
        {
            get { return _isAsync; }
            set { _isAsync = value; }
        }

        public uint Index
        {
            get { return _index; }
            set { _index = value; }
        }

        public bool IsFiredOnce
        {
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
        public void AddPrevEvents(uint index)
        {
            if (_prevEvents.Contains(index))
                return;
            _prevEvents.Add(index);
        }

        // ������������ȥ��ĳ���¼�(�����к�)
        public void RmvPrevEvents(uint index)
        {
            if (_prevEvents.Contains(index))
                _prevEvents.Remove(index);
        }

        // �������������¼��Ƿ�����������
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
        public void AddHandler(Handler h)
        {
            _handlers += h;
        }

        // ִ���¼�������
        public virtual void ExecHanlders()
        {
            _handlers();
        }

    }

}
