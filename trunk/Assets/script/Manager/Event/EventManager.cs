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

        // EventManager的方法

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

        // 初始化事件索引列表
        public static void InitEventArray() {

            Debug.Log("-- Func : InitEventArray --");
            _eventArray = new Event[EventConstants.TOTAL_NUM];
            _eventArray[0] = null;

            for (uint i = 1; i <= EventConstants.KEY_NUM; i++) {
                _eventArray[i] = new Event(i);
            }

            for (uint i = 101; i < 101 + EventConstants.GATE_NUM; i++) {
                _eventArray[i] = new Event(i);
            }
        }

        // 绑定事件处理器
        public static void InitBindingHandlers() {

            // Event GetKey1 for Example
            AddEventHandler((uint)EventType.GetKey1, delegate(){
                Debug.Log("Player Get Key 1!");
            });

            /* TODO: bind EventHandler to Events */

        }

    }

}
