using UnityEngine;
using System.Collections;

namespace Loop
{
    public class World {

        // fields

        private Vector3 _worldPos;  // ������������
        private Vector3 _mapCamPos; // ���ͼ���������

        private WorldName _name;  // ��������
        private int _worldIndex;     // �������
        private bool _isCurrentWorld;   // �Ƿ��ǵ�ǰ��ɫ���ڵ�����

        private GravityLevel _gravityLevel;     // �������ٶȵȼ�

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

        // ���캯��

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
