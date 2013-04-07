using UnityEngine;
using System;
using System.Collections;

namespace Loop
{
    public static class CameraManager
    {
        public delegate void LoadCameraDataHandler(Vector3 camMainPos, Vector3 camMapPos);
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

        // 在摄像机管理器CameraManager中初始化登记摄像机
        public static void InitAllCameras(){

            Debug.Log("-- Func : WorldManager.InitAllCameras --");

            _camMain = Camera.main;
            _camMap = GameObject.Find("CameraMap").camera;
        }

        // 推主摄像机
        public static void PushMainCamera() {
            _camMain.GetComponent<MainCamera>().PushCamera();
        }
        
        // 拉主摄像机
        public static void PullMainCamera() {
            _camMain.GetComponent<MainCamera>().PullCamera();
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

        // 保存摄像机数据
        public static void SaveCameraData() {

            PlayerPrefsX.SetVector3("camMainPos", _camMain.transform.position);
            PlayerPrefsX.SetVector3("camMapPos", _camMap.transform.position);
        }

        // 恢复摄像机状态
        public static void RecoverCamera(){

            LoadCameraData(RecoverCameraPositionTo);

        }

        // 装载摄像机位置信息并进行处理
        public static void LoadCameraData(LoadCameraDataHandler handler) {
            
            Vector3 camMainPos = PlayerPrefsX.GetVector3("camMainPos");
            Vector3 camMapPos = PlayerPrefsX.GetVector3("camMapPos");
            handler(camMainPos, camMapPos);

        }

        // 恢复主摄像机和地图摄像机到特定位置
        private static void RecoverCameraPositionTo(Vector3 camMainPos, Vector3 camMapPos) {
            TranslateMainCamera(camMainPos - _camMain.transform.position, Space.World);
            TranslateMapCamera(camMapPos - _camMap.transform.position, Space.World);
        }

        //public static void 

        // 世界切换
        public static void SwitchWorldCamera(WorldName targetWorld) {
            Debug.Log("-- Func : CameraManager.SwitchWorldCamera --");

            Vector3 dis = WorldManager.GetWorldPos(targetWorld) - WorldManager.GetPrevWorld().WorldPos;

            TranslateMainCamera(dis, Space.World);
        }

    }

}
