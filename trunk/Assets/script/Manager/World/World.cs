using UnityEngine;
using System.Collections;

namespace Loop
{
    public class World {

        // fields

        private Vector3 _worldPos;  // 世界中心坐标
        private Vector3 _mapCamPos; // 大地图摄像机坐标

        private WorldName _name;  // 世界名称
        private int _worldIndex;     // 世界序号
        private bool _isCurrentWorld;   // 是否是当前角色所在的世界

        private GravityLevel _gravityLevel;     // 重力加速度等级

        // properties

        public Vector3 MapCamPos
        {
            get { return _mapCamPos; }
            set { _mapCamPos = value; }
        }

        public Vector3 WorldPos
        {
            get { return _worldPos; }
            set { _worldPos = value; }
        }

        public WorldName Name {
            get { return _name; }
            set { _name = value; }
        }

        public int WorldIndex {
            get { return _worldIndex; }
            set { _worldIndex = value; }
        }

        public bool IsCurrentWorld {
            get { return _isCurrentWorld; }
            set { _isCurrentWorld = value; }
        }

        public GravityLevel GravityLevel
        {
            get { return _gravityLevel; }
            set { _gravityLevel = value; }
        }

        // methods

        // 构造函数

        public World(Vector3 pos, WorldName name) {
            _worldPos = pos;

            _name = name;
            _worldIndex = (int)name;
        }

        public World(Vector3 pos, int index) {

            if (index < 0 || index >= WorldConstants.WORLDS_NUM) {
                Debug.Log("Error : index out of range @ World constructor.");
                return;
            }

            _worldPos = pos;

            _name = (WorldName)index;
            _worldIndex = index;
        }

        public World(float x, float y, float z, WorldName name) {
            _worldPos.x = x;
            _worldPos.y = y;
            _worldPos.z = z;

            _name = name;
            _worldIndex = (int)name;
        }

        public World(float x, float y, float z, int index)
        {
            if (index < 0 || index >= WorldConstants.WORLDS_NUM) {
                throw new System.IndexOutOfRangeException("IIndexOutOfRangeException @ World constructor.");
            }

            _worldPos.x = x;
            _worldPos.y = y;
            _worldPos.z = z;

            _name = (WorldName)index;
            _worldIndex = index;
        }

        public void InitMapCameraPosition(Vector3 pos) {
            _mapCamPos = pos;
        }
    }

}
