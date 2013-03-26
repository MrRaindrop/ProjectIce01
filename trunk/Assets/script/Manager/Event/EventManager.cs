using UnityEngine;
using System.Collections;
using System.Collections.Generic;


namespace Loop
{

    public static class EventManager
    {

        private static EventManager _eventManager;
        private static Queue _eventQueue;
        private static Event[] _eventArray;

        // getter and setter

        public static Event[] EventArray {
            get { return _eventArray; }
            set { _eventArray = value; }
        }

        // EventManagerµÄ·½·¨

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

        public static void AddEventHandler(int eIndex, Loop.Event.Handler handler) {
            _eventArray[eIndex].AddHandler(handler);
        }

    }

}
