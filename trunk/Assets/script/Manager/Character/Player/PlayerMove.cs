using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

    public float moveSpeed;
    public float runSpeed;
    public float jumpSpeed;
    public float gravity;

    private Vector3 _moveDirection;

    private CharacterController ct;     // ��ɫ������

    private GameObject _camMap;     // ��ͼ�����
    private GameObject _camMain;    // �������

    private GameObject _obGameObject;   // observer�����
    private Observer _observer;         // observer����ű�
    private Loop.Player _currentPlayer;     // Player��ĵ�ǰʵ��������

    public bool _isMapFlag = false;     // ��ͼ�л�״̬��־���Ƿ��ڴ��ͼ״̬��
    public bool _inputAvailable = false;      // �Ƿ���Ӧ���루������Ĭ״̬��־��

	// Use this for initialization
	void Awake () {
        
	}

    void Start() {

        _obGameObject = GameObject.FindWithTag("Observer");
        _observer = _obGameObject.GetComponent<Observer>();
        _currentPlayer = _observer.GetCurrentPlayer();

        // ��ȡ��ǰʵ����player������ƶ�������ֵ
        moveSpeed = _currentPlayer.MoveSpeed;
        runSpeed = _currentPlayer.RunSpeed;
        jumpSpeed = _currentPlayer.JumpSpeed;

        // ��ɫ��ʼ�ж�
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
        return _currentPlayer.IsAvailable();
    }

    // ��ֹ��ɫ�ж�
    public void DisablePlayerAct() {
        _currentPlayer.DisableAct();
    }

    // �ָ���ɫ�ж�
    public void EnablePlayerAct() {
        _currentPlayer.EnableAct();
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

    // ��ɫת�Ƶ��ض����ֵ�����
    public void MoveToWorld(Loop.WorldName name) {

        Loop.World sourceWorld = Loop.WorldManager.GetPrevWorld();
        Debug.Log("Source WorldPos : " + sourceWorld.WorldPos);
        Loop.World targetWorld = Loop.WorldManager.GetWorld(name);
        Debug.Log("Target WorldPos: " + targetWorld.WorldPos);
        
        transform.Translate(targetWorld.WorldPos - sourceWorld.WorldPos, Space.World);
    }
}
