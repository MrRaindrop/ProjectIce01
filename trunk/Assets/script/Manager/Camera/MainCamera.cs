using UnityEngine;
using System.Collections;

public class MainCamera : MonoBehaviour {

    public Transform target;

    public float heightDamping;
    public float moveDamping;
    public float distanceDamping;

    private float _height;    // 摄像机与target相对高度
    private float _distance;     // 摄像机与target在z轴上的距离

	// Use this for initialization
    void Start() {

        _height = Loop.CameraConstants.CAM_HEIGHT_MID;
        _distance = Loop.CameraConstants.CAM_DIS_MID;

        heightDamping = Loop.CameraConstants.CAM_HEIGHT_DAMP;
        moveDamping = Loop.CameraConstants.CAM_MOVE_DAMP;
        distanceDamping = Loop.CameraConstants.CAM_DIS_DAMP;

        target = GameObject.FindWithTag("Player").transform;
        transform.position = target.position + new Vector3(0, _height, -_distance);
        transform.LookAt(target);

    }

    // Update is called once per frame
    void LateUpdate() {

        // 摄像机跟随
        CameraFollow(target);

        // 侦测推进摄像机按键输入
        if (Input.GetKeyDown(KeyCode.Plus) || Input.GetKeyDown(KeyCode.KeypadPlus)) {
            Debug.Log("Key \"+\"!");
            PushCamera();
        }

        // 侦测拉远摄像机按键输入
        if (Input.GetKeyDown(KeyCode.Minus) || Input.GetKeyDown(KeyCode.KeypadMinus)) {
            Debug.Log("Key \"-\"!");
            PullCamera();
        }

        // 测试摄像机震动
        if (Input.GetKeyDown(KeyCode.V)) {
            Debug.Log("Key \"V\"!");
            Loop.CameraManager.VibrateMainCamera2(0.5f);
        }
	}

    public void CameraFollow(Transform target)
    {

        if (!target) {
            return;
        }

        // Calculate the current rotation angles
        float wantedMove = target.position.x;
        float wantedHeight = target.position.y + _height;
        float wantedDepth = target.position.z - _distance;

        float currentMove = transform.position.x;
        float currentHeight = transform.position.y;
        float currentDepth = transform.position.z;

        currentMove = Mathf.Lerp(currentMove, wantedMove, moveDamping * Time.deltaTime);
        currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);
        currentDepth = Mathf.Lerp(currentDepth, wantedDepth, distanceDamping * Time.deltaTime);

        transform.position = new Vector3(currentMove, currentHeight, currentDepth);

        // Always look at the target
        transform.LookAt(target);

    }

    // 推摄像机
    public void PushCamera(){

        if (_distance == Loop.CameraConstants.CAM_DIS_MAX) {
            _distance = Loop.CameraConstants.CAM_DIS_MID;
            _height = Loop.CameraConstants.CAM_HEIGHT_MID;
        } else {
            _distance = Loop.CameraConstants.CAM_DIS_MIN;
            _height = Loop.CameraConstants.CAM_HEIGHT_MIN;
        }

        Debug.Log(_distance);
    }

    // 拉摄像机
    public void PullCamera() {

        if (_distance == Loop.CameraConstants.CAM_DIS_MIN) {
            _distance = Loop.CameraConstants.CAM_DIS_MID;
            _height = Loop.CameraConstants.CAM_HEIGHT_MID;
        } else {
            _distance = Loop.CameraConstants.CAM_DIS_MAX;
            _height = Loop.CameraConstants.CAM_HEIGHT_MAX;
        }

        Debug.Log(_distance);
    }

}




