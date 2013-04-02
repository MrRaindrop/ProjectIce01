using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

    public float moveSpeed;
    public float runSpeed;
    public float jumpSpeed;
    public float gravity;

    private Vector3 _moveDirection;

    private CharacterController ct;

    private GameObject camMap;
    private GameObject camMain;


    public bool _isMapFlag = false;     // 地图切换状态标志（是否处于大地图状态）
    public bool _playerAvailable = true;      // 角色是否可以行动（角色静默状态标志）
    public bool _inputAvailable = true;      // 是否响应输入（按键静默状态标志）

	// Use this for initialization
	void Awake () {
        
	}

    void Start() {

        moveSpeed = Loop.EnvManager.player_moveSpeed;
        runSpeed = Loop.EnvManager.player_runSpeed;
        jumpSpeed = Loop.EnvManager.player_jumpSpeed;
        gravity = Loop.EnvManager.gravity;
        _moveDirection = Vector3.zero;

        ct = GetComponent<CharacterController>();

        camMap = GameObject.Find("CameraMap");
        camMain = GameObject.Find("CameraMain");

        if (camMain != null)
            camMain.camera.enabled = true;
        if (camMap != null)
            camMap.camera.enabled = false;

        _isMapFlag = false;

        _playerAvailable = true;
        _inputAvailable = true;

        
    }
	
	void Update () {

        if (_inputAvailable) {

            if (_playerAvailable) {
                
                // 侦测跳跃按钮输入
                if (ct.isGrounded)
                {
                    _moveDirection = Vector3.zero;

                    if (Input.GetButton("Jump"))
                        _moveDirection.y = jumpSpeed;
                }

                // horizontal move
                _moveDirection.x = Input.GetAxis("Horizontal") * moveSpeed;
            }

            // 侦测地图切换按钮输入
            if (Input.GetKeyDown(KeyCode.M))
            {
                Debug.Log("M!");

                if (_isMapFlag == false)
                {
                    if (camMain != null)
                        camMain.camera.enabled = false;
                    if (camMap != null)
                        camMap.camera.enabled = true;
                    _isMapFlag = true;

                }
                else if (_isMapFlag == true)
                {
                    if (camMain != null)
                        camMain.camera.enabled = true;
                    if (camMap != null)
                        camMap.camera.enabled = false;
                    _isMapFlag = false;

                }
            }

            // gravity
            _moveDirection.y -= gravity * Time.deltaTime;

            

            ct.Move(_moveDirection * Time.deltaTime);

        } // end if(_inputAvailable)
	}

    // 查看角色是否可以行动
    public bool IsPlayerAvailable() {
        return _playerAvailable;
    }

    // 禁止角色行动
    public void DisablePlayerAct() {
        _playerAvailable = false;
    }

    // 恢复角色行动
    public void EnablePlayerAct() {
        _playerAvailable = true;
    }

    // 是否响应玩家输入
    public bool IsInputAvailable() {
        return _inputAvailable;
    }

    // 不接受玩家输入
    public void DisableInput() {
        _inputAvailable = false;
    }

    // 接受玩家输入
    public void EnableInput() {
        _inputAvailable = true;
    }
}
