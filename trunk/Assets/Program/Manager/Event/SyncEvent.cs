using UnityEngine;
using System.Collections;

using UnityEngine;
using System.Collections;

namespace Loop
{
    public class SyncEvent : Event
    {
        public SyncEvent(uint index) : base(index) {
            _isAsync = false;
        }

        public SyncEvent(uint index, float delayPeriod, float expiredPeriod = 0f) :
            base(index, delayPeriod, expiredPeriod) {
            _isAsync = false;
        }


    }
    
}
