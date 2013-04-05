using UnityEngine;
using System.Collections;

namespace Loop
{

    public static class CameraManager
    {
        // fields

        private static Camera _camMain;
        private static Camera _camMap;

        // properties

        public static Camera CamMain {
            get { return CameraManager._camMain; }
            set { CameraManager._camMain = value; }
        }

        public static Camera CamMap {
            get { return CameraManager._camMap; }
            set { CameraManager._camMap = value; }
        }

        // methods

        // �������������CameraManager�еǼ������
        public static void initAllCameras(){
            _camMain = Camera.main;
            _camMap = GameObject.Find("CameraMap").camera; 
        }

        // �ƶ��������
        public static void TranslateMainCamera(Vector3 dis, Space relativeTo) {
            _camMain.transform.Translate(dis, relativeTo);
        }

        // �ƶ����ͼ�����
        public static void TranslateMapCamera(Vector3 dis, Space relativeTo){
            _camMap.transform.Translate(dis, relativeTo);
        }

        // �ƶ��ض������
        public static void TranslateCamera(Camera cam, Vector3 dis, Space relativeTo) {
            cam.transform.Translate(dis, relativeTo);
        }

        // �����л�
        public static void SwitchWorldCamera(WorldName targetWorld) {
            Debug.Log("-- Func : CameraManager.SwitchWorldCamera --");

            Vector3 dis = WorldManager.GetWorldPos(targetWorld) - WorldManager.GetPrevWorld().WorldPos;

            TranslateMainCamera(dis, Space.World);
        }

    }

}
