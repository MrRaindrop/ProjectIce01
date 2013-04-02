using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;


namespace Loop
{
    
    public static class EventManager
    {
        private static Queue _eventQueue;
        private static Event[] _eventArray;

        // getter and setter

        public static Event[] EventArray {
            get { return _eventArray; }
            set { _eventArray = value; }
        }

        // EventManager�ķ���

        public static void FireEvent(Event e) {
            e.IsFiredOnce = true;
            e.IsValid = true;
            e.FiredTimes++;
        }

        public static void PushEventQueue(Event e)
        {
            _eventQueue.Enqueue(e.Index);
        }

        public static uint PopEventQueue(){
            return ((Event)_eventQueue.Dequeue()).Index;
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

            for (uint i = 1; i <= EventConstants.KEY_NUM; i++) {
                _eventArray[i] = new Event(i);
            }

            for (uint i = 101; i < 101 + EventConstants.GATE_NUM; i++) {
                _eventArray[i] = new Event(i, 0.1f, 0.0f);
            }
        }

        // ���¼�������
        public static void InitBindingHandlers() {
            
            /* TODO: �󶨴��������¼����ɰ󶨶�� */

            // Event GetKey1 for Example
            AddEventHandler((uint)EventType.GetKey1, delegate(){

                if (EventArray[(uint)EventType.GetKey1].ExpiredPeriod != 0) {
                    // TODO: ....unity coroutines & yields
                    // after ExpiredPeriod seconds...
                    {
                        EventArray[(uint)EventType.GetKey1].IsValid = false;
                    }
                }

                if (EventArray[(uint)EventType.GetKey1].DelayPeriod != 0) {
                    // TODO: ....unity coroutines & yields
                    Debug.Log("Player Get Key 1!");
                }

            });

        }
    }

}
