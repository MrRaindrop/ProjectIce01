using UnityEngine;
using System.Collections;

namespace Loop
{
    

    public class Event
    {

        private uint _index;    // �¼����

        private bool _isFiredOnce;  // �Ƿ������ѳ���

        private uint _firedTimes;   // �Ѵ�������
        
        private uint _expiredTimes; // ʧЧʱ��(s)
        
        private ArrayList _prevEvents;  // �����������¼�����б�

        delegate void Handler();
        public Handler handlers;

        public void AddPrevEvents(int index){
            _prevEvents.Add(index);
        }
    }

}
