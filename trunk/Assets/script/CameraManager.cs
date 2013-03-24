using UnityEngine;
using System;
using System.Collections;

namespace Managers
{

    public class CameraManager
    {
        public static Camera GetMainCamera()
        {

            return Camera.main;
        }

        // 获取特定名称的摄像机
        public static Camera GetCamera(string cameraName)
        {

            foreach (Camera c in Camera.allCameras)
            {
                if (c.gameObject.name == "cameraName")
                    return c;
            }
            return null;
        }

        // 获取所有摄像机
        public static System.Array GetAllCameras()
        {

            Debug.Log(Camera.allCameras);
            return Camera.allCameras;
        }

        // 水平或垂直方向围绕某物体旋转
        public static void CameraOrbit(Transform camTrans, Vector3 axisPos,
            float distance, float xSpeed = 0, float ySpeed = 0)
        {
            float x = camTrans.eulerAngles.x;
            float y = camTrans.eulerAngles.y;
            Debug.Log(xSpeed);
            Debug.Log(ySpeed);
            x += xSpeed;
            y += ySpeed;
            if (x < -360) x += 360;
            if (x > 360) x -= 360;
            if (y < -360) y += 360;
            if (y > 360) y -= 360;
            Debug.Log(x);
            Debug.Log(y);
            Quaternion rotation = Quaternion.Euler(y, x, 0);
            Vector3 pos = rotation * (new Vector3(0.0f, 0.0f, -distance)) + axisPos;
            camTrans.Translate(pos - camTrans.position, Space.World);
        }

    }

}   // namespace Managers
