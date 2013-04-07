using UnityEngine;
using System.Collections;

// 不能在地图上通过添加事件触发器添加ExtraEvents
// 只能由程序员来定义ExtraEvent及其处理器
// can't use extra events in TriggerEvent.cs
// only programmer can use it

namespace Loop {

    public enum MessageType {
        DestroyGameObject
    }

}
