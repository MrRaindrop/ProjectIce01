using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Loop {

    public static class MessageManager {

        private static Queue<Message> _msgQueue;

	    public static void SendMessage(MessageType type, Message.Handler h,
             System.Object extraParam1 = null, System.Object extraParam2 = null) {
             Debug.Log(" SendMessage : " + type);

             Message msg = new Message(type, h, extraParam1, extraParam2);
             PushMessageQueue(msg);
        }

        public static void PushMessageQueue(Message msg) {
            _msgQueue.Enqueue(msg);
        }

        public static Message PopMessageQueue() {
            if (_msgQueue.Count != 0)
                return _msgQueue.Dequeue();
            return null;
        }

        public static bool IsMessageQueueEmpty() {
            return _msgQueue.Count == 0;
        }

        // 初始化消息队列
        public static void InitMessageQueue() {

            Debug.Log("-- Func : InitMessageQueue --");

            _msgQueue = new Queue<Message>();
        }

    }

}