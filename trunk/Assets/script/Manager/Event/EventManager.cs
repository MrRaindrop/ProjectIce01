using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;


namespace Loop
{
    // 定义所有的事件类型
    enum EventType {
        None = 0,
        AfterGettingKey = 1,
    }

    
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
    }

}
