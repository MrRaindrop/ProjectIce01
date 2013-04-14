using UnityEngine;
using System.Collections;

namespace Loop
{

    public static class WorldManager {

        // fields

        private static World[] _worldArray;
        private static WorldName _prevWorld;        // 角色发动切换之前的世界名称
        private static WorldName _currentWorld;    // 当前的世界名称
        

        // methods

        // 获取指定名称的世界
        public static World GetWorld(WorldName name) {
            return _worldArray[(int)name];
        }

        // 获取指定序列号的世界
        public static World GetWorld(int index) {
            if (index < 0 || index >= WorldConstants.WORLDS_NUM) {
                throw new System.IndexOutOfRangeException(
                    "IndexOutOfRangeException @ WorldManager.GetWorld Func.");
            }

            return _worldArray[index];
        }

        // 获取由名字指定的世界的中心坐标
        public static Vector3 GetWorldPos(WorldName name) {
            return _worldArray[(int)name].WorldPos;
        }

        // 获取由序号指定的世界的中心坐标
        public static Vector3 GetWorldPos(int index)
        {
            if (index < 0 || index >= WorldConstants.WORLDS_NUM) {
                throw new System.IndexOutOfRangeException(
                    "IndexOutOfRangeException @ WorldManager.GetWorldPos Func.");
            }

            return _worldArray[index].WorldPos; 
        }

        // 切换世界
        public static void SwitchToWorld(WorldName name) {

            if ((int)name < 0 || (int)name >= WorldConstants.WORLDS_NUM) {
                Debug.Log("Error : Switch World Failed - worldIndex out of range. World name: " + name);
                return;
            }

            _prevWorld = _currentWorld;
            _currentWorld = name;

            Debug.Log("switch to world : " + name + " from world " + _prevWorld);
            
            // ...

        }

        // 获取前一个的世界编号
        public static int GetPrevWorldIndex() {
            return (int)_prevWorld;
        }

        // 获取前一个世界的名字
        public static WorldName GetPrevWorldName() {
            return _prevWorld;
        }

        // 获取前一个世界对象
        public static World GetPrevWorld() {
            return _worldArray[(int)_prevWorld];
        }

        // 获取当前的世界编号
        public static int GetCurrentWorldIndex() {
            return (int)_currentWorld;
        }

        // get current world name
        public static WorldName GetCurrentWorldName() {
            return _currentWorld;
        }

        // 获取当前世界对象
        public static World GetCurrentWorld() {
            return _worldArray[(int)_currentWorld];
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

        // 保存世界数据
        public static void SaveWorldData() {

            PlayerPrefs.SetInt("prevWorld", (int)_prevWorld);
            PlayerPrefs.SetInt("currentWorld", (int)_currentWorld);

        }

        // 装载世界数据
        public static void LoadWorldData() {

            _prevWorld = (WorldName)PlayerPrefs.GetInt("prevWorld");
            _currentWorld = (WorldName)PlayerPrefs.GetInt("currentWorld");

        }

        // 初始化世界数组
        public static void InitWorldArray() {

            Debug.Log("-- Func : WorldManager.InitWorldArray --");
            
            _worldArray = new World[WorldConstants.WORLDS_NUM];

            float offset = WorldConstants.POSITION_OFFSET_BETWEEN_WORLDS;

            _worldArray[0] = new World(0, 0, 0, (WorldName)0);
            _worldArray[0].MapCamPos = _worldArray[0].WorldPos + new Vector3(0, 0, -WorldConstants.MAP_CAMERA_DISTANCE);

            _worldArray[1] = new World(offset, offset, offset, (WorldName)1);
            _worldArray[1].MapCamPos = _worldArray[1].WorldPos + new Vector3(0, 0, -WorldConstants.MAP_CAMERA_DISTANCE);

        }

    }

}
