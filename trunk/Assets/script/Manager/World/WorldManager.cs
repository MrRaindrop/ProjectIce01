using UnityEngine;
using System.Collections;

namespace Loop
{

    public static class WorldManager {

        private static WorldName _currentWorld;    // ��ǰ����������

        // ��ȡ��ǰ��������
        public static int GetCurrentWorldIndex()
        {
            return (int)_currentWorld;
        }

        // ���õ�ǰ�������ţ��ɹ����ص�ǰ�����ţ�ʧ�ܷ���-1
        public static int SetCurrentWorldIndex(int index)
        {
            if (index >= 0 && index < WorldConstants.WORLDS_NUM)
            {
                _currentWorld = (WorldName)index;
                return index;
            }
            else
                return -1;
        }



    }

}
