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

        // 在摄像机管理器CameraManager中登记摄像机
        public static void initAllCameras(){
            _camMain = Camera.main;
            _camMap = GameObject.Find("CameraMap").camera; 
        }

        // 移动主摄像机
        public static void TranslateMainCamera(Vector3 dis, Space relativeTo) {
            _camMain.transform.Translate(dis, relativeTo);
        }

        // 移动大地图摄像机
        public static void TranslateMapCamera(Vector3 dis, Space relativeTo){
            _camMap.transform.Translate(dis, relativeTo);
        }

        // 移动特定摄像机
        public static void TranslateCamera(Camera cam, Vector3 dis, Space relativeTo) {
            cam.transform.Translate(dis, relativeTo);
        }

        // 世界切换
        public static void SwitchWorldCamera(WorldName targetWorld) {
            Debug.Log("-- Func : CameraManager.SwitchWorldCamera --");

            Vector3 dis = WorldManager.GetWorldPos(targetWorld) - WorldManager.GetPrevWorld().WorldPos;

            TranslateMainCamera(dis, Space.World);
        }

    }

}
