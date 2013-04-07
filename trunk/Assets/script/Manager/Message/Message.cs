using UnityEngine;
using System.Collections;

// �����ڵ�ͼ��ͨ������¼����������Message
// ֻ���ɳ���Ա������Message������Ϣ������
// Message��ʼ�����첽ִ�е�
// can't trigger messages in TriggerEvent.cs
// only programmer can use it
// Message is always asynchronous

namespace Loop
{
    public class Message {

        public delegate void Handler();

        private MessageType _type;    // ��Ϣ����
        private float _delayPeriod;     // �ӳٴ���ʱ��(s) - �������ͣ���ʱ����
        private ArrayList _prevEvents;  // �����������¼�����б�
        protected Handler _handlers;  // ��Ϣ��������
        private System.Object _param1;      // ��ѡ����1
        private System.Object _param2;      // ��ѡ����2

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

        // ���캯��

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

        // �����Ϣ������
        public void AddHandler(Handler h) {
            _handlers += h;
        }

        // ִ����Ϣ������
        public void ExecHanlders() {
            _handlers();
        }


    }

}
