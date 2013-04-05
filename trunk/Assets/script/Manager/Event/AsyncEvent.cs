using UnityEngine;
using System.Collections;

namespace Loop
{
    public class AsyncEvent : Event {

        public AsyncEvent(uint index) : base(index){
            _isAsync = true;
        }

        public AsyncEvent(uint index, float delayPeriod, float expiredPeriod = 0f) :
            base(index, delayPeriod, expiredPeriod) {
                _isAsync = true;
        }
    }
}
