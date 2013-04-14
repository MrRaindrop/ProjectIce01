using UnityEngine;
using System.Collections;

namespace Loop
{

    public static class WorldManager {

        // fields

        private static World[] _worldArray;
        private static WorldName _prevWorld;        // ��ɫ�����л�֮ǰ����������
        private static WorldName _currentWorld;    // ��ǰ����������
        

        // methods

        // ��ȡָ�����Ƶ�����
        public static World GetWorld(WorldName name) {
            return _worldArray[(int)name];
        }

        // ��ȡָ�����кŵ�����
        public static World GetWorld(int index) {
            if (index < 0 || index >= WorldConstants.WORLDS_NUM) {
                throw new System.IndexOutOfRangeException(
                    "IndexOutOfRangeException @ WorldManager.GetWorld Func.");
            }

            return _worldArray[index];
        }

        // ��ȡ������ָ�����������������
        public static Vector3 GetWorldPos(WorldName name) {
            return _worldArray[(int)name].WorldPos;
        }

        // ��ȡ�����ָ�����������������
        public static Vector3 GetWorldPos(int index)
        {
            if (index < 0 || index >= WorldConstants.WORLDS_NUM) {
                throw new System.IndexOutOfRangeException(
                    "IndexOutOfRangeException @ WorldManager.GetWorldPos Func.");
            }

            return _worldArray[index].WorldPos; 
        }

        // �л�����
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

        // ��ȡǰһ����������
        public static int GetPrevWorldIndex() {
            return (int)_prevWorld;
        }

        // ��ȡǰһ�����������
        public static WorldName GetPrevWorldName() {
            return _prevWorld;
        }

        // ��ȡǰһ���������
        public static World GetPrevWorld() {
            return _worldArray[(int)_prevWorld];
        }

        // ��ȡ��ǰ��������
        public static int GetCurrentWorldIndex() {
            return (int)_currentWorld;
        }

        // get current world name
        public static WorldName GetCurrentWorldName() {
            return _currentWorld;
        }

        // ��ȡ��ǰ�������
        public static World GetCurrentWorld() {
            return _worldArray[(int)_currentWorld];
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

        // ������������
        public static void SaveWorldData() {

            PlayerPrefs.SetInt("prevWorld", (int)_prevWorld);
            PlayerPrefs.SetInt("currentWorld", (int)_currentWorld);

        }

        // װ����������
        public static void LoadWorldData() {

            _prevWorld = (WorldName)PlayerPrefs.GetInt("prevWorld");
            _currentWorld = (WorldName)PlayerPrefs.GetInt("currentWorld");

        }

        // ��ʼ����������
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
