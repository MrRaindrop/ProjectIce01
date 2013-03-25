using UnityEngine;
using System.Collections;

namespace Loop
{
    

    public class Event
    {

        private uint _index;    // 事件序号

        private bool _isFiredOnce;  // 是否曾经已出发

        private uint _firedTimes;   // 已触发次数
        
        private uint _expiredTimes; // 失效时间(s)
        
        private ArrayList _prevEvents;  // 先序条件（事件序号列表）

        delegate void Handler();
        public Handler handlers;

        public void AddPrevEvents(int index){
            _prevEvents.Add(index);
        }
    }

}
