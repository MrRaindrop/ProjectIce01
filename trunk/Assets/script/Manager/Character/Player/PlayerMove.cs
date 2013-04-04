using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

    public float moveSpeed;
    public float runSpeed;
    public float jumpSpeed;
    public float gravity;

    private Vector3 _moveDirection;

    private CharacterController ct;

    private GameObject _camMap;
    private GameObject _camMain;

    private GameObject _obGameObject;
    private Observer _observer;
    private Loop.Player _currentPlayer;

    public bool _isMapFlag = false;     // ��ͼ�л�״̬��־���Ƿ��ڴ��ͼ״̬��
    public bool _playerAvailable = true;      // ��ɫ�Ƿ�����ж�����ɫ��Ĭ״̬��־��
    public bool _inputAvailable = true;      // �Ƿ���Ӧ���루������Ĭ״̬��־��

	// Use this for initialization
	void Awake () {
        
	}

    void Start() {

        _obGameObject = GameObject.FindWithTag("Observer");
        _observer = _obGameObject.GetComponent<Observer>();
        _currentPlayer = _observer.GetCurrentPlayer();

        moveSpeed = _currentPlayer.MoveSpeed;
        runSpeed = _currentPlayer.RunSpeed;
        jumpSpeed = _currentPlayer.JumpSpeed;
        
        gravity = Loop.EnvManager.gravity;
        _moveDirection = Vector3.zero;

        ct = GetComponent<CharacterController>();

        _camMap = GameObject.Find("CameraMap");
        _camMain = GameObject.Find("CameraMain");

        if (_camMain != null)
            _camMain.camera.enabled = true;
        if (_camMap != null)
            _camMap.camera.enabled = false;

        _isMapFlag = false;

        _playerAvailable = true;
        _inputAvailable = true;

        
    }
	
	void Update () {

        if (_inputAvailable) {

            if (_playerAvailable) {
                
                // �����Ծ��ť����
                if (ct.isGrounded)
                {
                    _moveDirection = Vector3.zero;

                    if (Input.GetButton("Jump"))
                        _moveDirection.y = jumpSpeed;
                }

                // horizontal move
                _moveDirection.x = Input.GetAxis("Horizontal") * moveSpeed;
            }

            // ����ͼ�л���ť����
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

    // �鿴��ɫ�Ƿ�����ж�
    public bool IsPlayerAvailable() {
        return _playerAvailable;
    }

    // ��ֹ��ɫ�ж�
    public void DisablePlayerAct() {
        _playerAvailable = false;
    }

    // �ָ���ɫ�ж�
    public void EnablePlayerAct() {
        _playerAvailable = true;
    }

    // �Ƿ���Ӧ�������
    public bool IsInputAvailable() {
        return _inputAvailable;
    }

    // �������������
    public void DisableInput() {
        _inputAvailable = false;
    }

    // �����������
    public void EnableInput() {
        _inputAvailable = true;
    }
}
