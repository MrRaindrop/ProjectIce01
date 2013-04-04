using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;


namespace Loop
{
    
    public static class EventManager
    {
        private static Queue<uint> _eventQueue;
        private static Event[] _eventArray;

        // getter and setter

        public static Event[] EventArray {
            get { return _eventArray; }
            set { _eventArray = value; }
        }

        // EventManager�ķ���

        public static void FireEvent(Event e) {
            e.IsFiredOnce = true;
            e.FiredTimes++;
            PushEventQueue(e);
        }

        public static void PushEventQueue(Event e)
        {
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

        public static void AddEventHandler(uint eIndex, Loop.Event.Handler handler) {
            _eventArray[eIndex].AddHandler(handler);
        }

        // ��ʼ���¼������б�
        public static void InitEventArray() {

            Debug.Log("-- Func : InitEventArray --");

            _eventArray = new Event[EventConstants.TOTAL_NUM];
            _eventArray[0] = null;

            /* TODO: Ԥ�������¼������кš��ӳٴ���ʱ�䡢����ʱ�� */

            _eventArray[(int)EventType.GetKey1] = new Event(1, 2.0f, 2.0f);

            for (uint i = 2; i <= EventConstants.KEY_NUM; i++) {
                _eventArray[i] = new Event(i);
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
            
            /* TODO: �󶨴��������¼����ɰ󶨶�� */


            // Event GetKey1 for Example
            AddEventHandler((uint)EventType.GetKey1, delegate(){
                               
                Debug.Log("Player Get Key 1!");

            });

        }
    }

}
