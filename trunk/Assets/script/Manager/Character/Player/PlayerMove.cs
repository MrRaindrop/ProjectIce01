using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

    public float moveSpeed;
    public float runSpeed;
    public float jumpSpeed;
    public float gravity;

    private Vector3 _moveDirection;

    private CharacterController ct;     // 角色控制器

    private GameObject _camMap;     // 地图摄像机
    private GameObject _camMain;    // 主摄像机

    private GameObject _obGameObject;   // observer的物件
    private Observer _observer;         // observer的类脚本
    private Loop.Player _currentPlayer;     // Player类的当前实例化对象

    public bool _isMapFlag;     // 地图切换状态标志（是否处于大地图状态）
    public bool _inputAvailable;      // 是否响应输入（按键静默状态标志）

	// Use this for initialization
	void Awake () {

        _isMapFlag = false;
        _inputAvailable = false;

	}

    void Start() {

        _obGameObject = GameObject.FindWithTag("Observer");
        _observer = _obGameObject.GetComponent<Observer>();
        _currentPlayer = _observer.GetCurrentPlayer();

        // 获取当前实例化player对象的移动能力数值
        moveSpeed = _currentPlayer.MoveSpeed;
        runSpeed = _currentPlayer.RunSpeed;
        jumpSpeed = _currentPlayer.JumpSpeed;

        // 角色开始行动
        _currentPlayer.EnableAct();
        _currentPlayer.EnableInput();
        
        gravity = Loop.EnvManager.gravity;
        _moveDirection = Vector3.zero;

        ct = GetComponent<CharacterController>();

        _camMap = GameObject.Find("CameraMap");
        _camMain = GameObject.Find("Main Camera");

        if (_camMain != null)
            _camMain.camera.enabled = true;
        if (_camMap != null)
            _camMap.camera.enabled = false;

        _isMapFlag = false;

        _inputAvailable = true;
        
    }
	
	void Update () {

        if (_inputAvailable) {

            if (_currentPlayer.IsAvailable()) {
                
                // test world switch
                if (Input.GetKeyDown(KeyCode.Alpha1)) {
                    Debug.Log("1 input!");
                    if(0 != Loop.WorldManager.GetCurrentWorldIndex())
                        _observer.SwitchWorld((Loop.WorldName)0);
                }

                if (Input.GetKeyDown(KeyCode.Alpha2)) {
                    if (1 != Loop.WorldManager.GetCurrentWorldIndex())
                        _observer.SwitchWorld((Loop.WorldName)1);
                }

                if (Input.GetKeyDown(KeyCode.Q)) {
                    _observer.SwitchWorld(Loop.WorldManager.GetPrevWorldName());
                }

                if (Input.GetKeyDown(KeyCode.Tab)) {
                    _observer.SwitchWorld((Loop.WorldName)(
                        (1 + Loop.WorldManager.GetCurrentWorldIndex()) % Loop.WorldConstants.WORLDS_NUM));
                }

                // 侦测跳跃按钮输入
                if (ct.isGrounded)
                {
                    _moveDirection = Vector3.zero;

                    if (Input.GetButton("Jump"))
                        _moveDirection.y = jumpSpeed;
                }

                float x = 0;

                // 转向
                if ((x = Input.GetAxis("Horizontal")) < 0) {
                    transform.rotation = Quaternion.Euler(new Vector3(0, -90, 0));
                } else if (x > 0) {
                    transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
                }
                    
                // horizontal move
                _moveDirection.x = x * moveSpeed;
            }

            // 侦测地图切换按钮输入
            if (Input.GetKeyDown(KeyCode.M))
            {
                Debug.Log("M!");

                if (_isMapFlag == false)
                {
                    if (_camMain != null)
                        _camMain.camera.enabled = false;
                    if (_camMap != null)
                        _camMap.camera.enabled = true;
                    _isMapFlag = true;

                }
                else if (_isMapFlag == true)
                {
                    if (_camMain != null)
                        _camMain.camera.enabled = true;
                    if (_camMap != null)
                        _camMap.camera.enabled = false;
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
        return _currentPlayer.IsAvailable();
    }

    // 禁止角色行动
    public void DisablePlayerAct() {
        _currentPlayer.DisableAct();
    }

    // 恢复角色行动
    public void EnablePlayerAct() {
        _currentPlayer.EnableAct();
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

    // 角色转移到特定名字的世界
    public void MoveToWorld(Loop.WorldName name) {

        Loop.World sourceWorld = Loop.WorldManager.GetPrevWorld();
        Debug.Log("Source WorldPos : " + sourceWorld.WorldPos);
        Loop.World targetWorld = Loop.WorldManager.GetWorld(name);
        Debug.Log("Target WorldPos: " + targetWorld.WorldPos);
        
        transform.Translate(targetWorld.WorldPos - sourceWorld.WorldPos, Space.World);
    }
}
