using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;


namespace Loop
{
    
    public static class EventManager
    {
        private static Queue<uint> _eventQueue;     // �¼�ִ�ж���
        private static Event[] _eventArray;         // �¼��ֵ�

        private static bool _syncFlag;      // ͬ���¼���־(��ʾ�¼�����ͬ��ִ����)

        // getter and setter

        public static bool SyncFlag
        {
            get { return EventManager._syncFlag; }
            set { EventManager._syncFlag = value; }
        }

        public static Event[] EventArray {
            get { return _eventArray; }
            set { _eventArray = value; }
        }

        // EventManager�ķ���

        // ��ȡָ����ŵ��¼�
        public static Event GetEvent(uint index) {
            if (index < 0 || index >= EventConstants.TOTAL_NUM) {
                Debug.Log("Error : index out of range @ EventManager.GetEvent.");
                return null;
            }

            return _eventArray[index];
        }

        public static void FireEvent(EventType e) {
            Debug.Log(" FireEvent : " + e);

            EventArray[(int)e].IsFiredOnce = true;
            EventArray[(int)e].FiredTimes++;
            PushEventQueue(EventArray[(int)e]);
        }

       

        public static void PushEventQueue(Event e) {
            _eventQueue.Enqueue(e.Index);
        }

        public static uint PopEventQueue(){
            if(_eventQueue.Count != 0)
                return _eventQueue.Dequeue();
            return 0;
        }

        public static bool IsEventQueueEmpty() {
            return _eventQueue.Count == 0;
        }

        public static void AddEventHandler(EventType type, Loop.Event.Handler handler) {
            _eventArray[(int)type].AddHandler(handler);
        }

        // �����¼���ص�����
        public static void SaveEventData() {

            int eventQueueCount = _eventQueue.Count;
            if (eventQueueCount > 0) {
                int[] array = new int[eventQueueCount];
                for (int i = 0; i < eventQueueCount; i++)
                    array[i] = (int)_eventQueue.Dequeue();

                PlayerPrefs.SetInt("eventQueueCount", eventQueueCount);
                PlayerPrefsX.SetIntArray("eventQueue", array);
            } else {
                PlayerPrefs.SetInt("eventQueueCount", 0);
            }
        }

        // װ���¼���ص�����
        public static void LoadEventData()
        {
            int eventQueueCount = PlayerPrefs.GetInt("eventQueueCount");
            if (eventQueueCount > 0) {
                int[] array = new int[eventQueueCount];
                array = PlayerPrefsX.GetIntArray("eventQueue");

                for (int i = 0; i < eventQueueCount; i++)
                    _eventQueue.Enqueue((uint)array[i]);
            }
            
        }

        // ��ʼ���¼������б�
        public static void InitEventArray() {

            Debug.Log("-- Func : InitEventArray --");

            _eventArray = new Event[EventConstants.TOTAL_NUM];
            _eventArray[0] = null;

            /* TODO: Ԥ�������¼������кš����������¼����ӳٴ���ʱ�䡢����ʱ�� */

            _eventArray[(int)EventType.PauseGame] = new Event((int)EventType.PauseGame);

            _eventArray[(int)EventType.SwitchToWorld0] = new Event((int)EventType.SwitchToWorld0);
            _eventArray[(int)EventType.SwitchToWorld1] = new Event((int)EventType.SwitchToWorld1);

            _eventArray[(int)EventType.GetKey1] = new SyncEvent(1, 2f, 2f);

            for (uint i = 2; i <= EventConstants.KEY_NUM; i++) {
                _eventArray[i] = new SyncEvent(i);
            }

            for (uint i = 101; i < 101 + EventConstants.GATE_NUM; i++) {
                _eventArray[i] = new Event(i, 0.1f, 0.0f);
            }
        }

        // ��ʼ���¼�����
        public static void InitEventQueue() {

            Debug.Log("-- Func : InitEventQueue --");

            _eventQueue = new Queue<uint>();
        }

        // ���¼�������
        public static void InitBindingHandlers() {

            Debug.Log("-- Func : EventManager.InitBindingHandlers --");

            /* TODO: �󶨴��������¼����ɰ󶨶�� */

            // Event GetKey1 for Example
            AddEventHandler(EventType.GetKey1, delegate(){
                               
                Debug.Log("Handler : Player Get Key 1!");

            });

            AddEventHandler(EventType.PauseGame, delegate(){
                Debug.Log("Event : Pause game!");

                // TODO

            });

            AddEventHandler(EventType.SwitchToWorld0, delegate(){
                Debug.Log("Event : Switch to world 0!");

                Observer ob = GameObject.FindWithTag("Observer").GetComponent<Observer>();
                ob.SwitchWorld((WorldName)0);

            });

            AddEventHandler(EventType.SwitchToWorld1, delegate(){
                Debug.Log("Event : Switch to world 1!");

                Observer ob = GameObject.FindWithTag("Observer").GetComponent<Observer>();
                ob.SwitchWorld((WorldName)1);
            });

        }
    }

}
