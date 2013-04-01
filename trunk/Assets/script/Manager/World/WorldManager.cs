using UnityEngine;
using System.Collections;

namespace Loop
{

    public static class WorldManager {

        private static WorldName _currentWorld;    // 当前的世界名称

        // 获取当前的世界编号
        public static int GetCurrentWorldIndex()
        {
            return (int)_currentWorld;
        }

        // 设置当前的世界编号，成功返回当前世界编号，失败返回-1
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
