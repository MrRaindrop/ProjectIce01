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

        // EventManager的方法

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

        // 初始化事件索引列表
        public static void InitEventArray() {

            Debug.Log("-- Func : InitEventArray --");

            _eventArray = new Event[EventConstants.TOTAL_NUM];
            _eventArray[0] = null;

            /* TODO: 预设所有事件的序列号、延迟触发时间、消亡时间 */

            _eventArray[(int)EventType.GetKey1] = new Event(1, 2.0f, 2.0f);

            for (uint i = 2; i <= EventConstants.KEY_NUM; i++) {
                _eventArray[i] = new Event(i);
            }

            for (uint i = 101; i < 101 + EventConstants.GATE_NUM; i++) {
                _eventArray[i] = new Event(i, 0.1f, 0.0f);
            }
        }

        // 初始化事件队列
        public static void InitEventQueue() {

            Debug.Log("-- Func : InitEventQueue --");

            _eventQueue = new Queue<uint>();
        }

        // 绑定事件处理器
        public static void InitBindingHandlers() {
            
            /* TODO: 绑定处理器到事件，可绑定多个 */


            // Event GetKey1 for Example
            AddEventHandler((uint)EventType.GetKey1, delegate(){
                               
                Debug.Log("Player Get Key 1!");

            });

        }
    }

}
