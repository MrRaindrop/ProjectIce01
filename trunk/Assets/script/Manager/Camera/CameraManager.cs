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

        private static float _effectGap = 3.0f;
        private static float _effectFps = 60.0f;
        private static float _shakeDelta = 0.005f;

        // properties

        public static float EffectGap {
            get { return CameraManager._effectGap; }
            set { CameraManager._effectGap = value; }
        }

        public static float EffectFps {
            get { return CameraManager._effectFps; }
            set { CameraManager._effectFps = value; }
        }

        public static float ShakeDelta {
            get { return CameraManager._shakeDelta; }
            set { CameraManager._shakeDelta = value; }
        }

        public static Camera CamMain {
            get { return CameraManager._camMain; }
            set { CameraManager._camMain = value; }
        }

        public static Camera CamMap {
            get { return CameraManager._camMap; }
            set { CameraManager._camMap = value; }
        }

        // methods

        // �������������CameraManager�г�ʼ���Ǽ������
        public static void InitAllCameras(){

            Debug.Log("-- Func : WorldManager.InitAllCameras --");

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

        // �������������
        public static void SaveCameraData() {

            PlayerPrefsX.SetVector3("camMainPos", _camMain.transform.position);
            PlayerPrefsX.SetVector3("camMapPos", _camMap.transform.position);
        }

        // �ָ������״̬
        public static void RecoverCamera(){

            LoadCameraData(RecoverCameraPositionTo);

        }

        // װ�������λ����Ϣ�����д���
        public static void LoadCameraData(LoadCameraDataHandler handler) {
            
            Vector3 camMainPos = PlayerPrefsX.GetVector3("camMainPos");
            Vector3 camMapPos = PlayerPrefsX.GetVector3("camMapPos");
            handler(camMainPos, camMapPos);

        }

        // �ָ���������͵�ͼ��������ض�λ��
        private static void RecoverCameraPositionTo(Vector3 camMainPos, Vector3 camMapPos) {
            TranslateMainCamera(camMainPos - _camMain.transform.position, Space.World);
            TranslateMapCamera(camMapPos - _camMap.transform.position, Space.World);
        }

        //public static void 

        // �����л�
        public static void SwitchWorldCamera(WorldName targetWorld) {
            Debug.Log("-- Func : CameraManager.SwitchWorldCamera --");

            Vector3 dis = WorldManager.GetWorldPos(targetWorld) - WorldManager.GetPrevWorld().WorldPos;

            TranslateMainCamera(dis, Space.World);
        }

        // ���������
        public static void PushMainCamera() {
            _camMain.gameObject.GetComponent<MainCamera>().PushCamera();
        }

        // ���������
        public static void PullMainCamera() {
            _camMain.gameObject.GetComponent<MainCamera>().PullCamera();
        }

        // �������ִ����Ч��1
        public static void VibrateMainCamera1(float gap) {

            _effectGap = gap;
            _camMain.gameObject.AddComponent<CameraVibrate1>();

        }

        // �������ִ����Ч��2
        public static void VibrateMainCamera2(float gap, float shakeDelta = 0.005f, float fps = 60f) {

            _effectGap = gap;
            _shakeDelta = shakeDelta;
            _effectFps = fps;
            _camMain.gameObject.AddComponent<CameraVibrate2>();
        }
    }

}
