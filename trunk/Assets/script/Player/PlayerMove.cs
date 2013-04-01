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
    public bool _isMapFlag = false;

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

        // µÿÕº«–ªª◊¥Ã¨…Ë ©≥ı ºªØ
        _isMapFlag = false;

        camMap = GameObject.Find("CameraMap");
        camMain = GameObject.Find("CameraMain");

        if (camMain != null)
        {
            camMain.camera.enabled = true;
        }
        if (camMap != null)
        {
            camMap.camera.enabled = false;
        }
    }
	
	void Update () {

        // ’Ï≤‚Ã¯‘æ∞¥≈• ‰»Î
        if (ct.isGrounded)
        {
            _moveDirection = Vector3.zero;

            if (Input.GetButton("Jump"))
                _moveDirection.y = jumpSpeed;
        }
        
        // ’Ï≤‚µÿÕº«–ªª∞¥≈• ‰»Î
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (_isMapFlag == false)
            {
                if (camMain != null)
                    camMain.camera.enabled = true;
                if (camMap != null)
                    camMap.camera.enabled = false;
                _isMapFlag = true;

            }
            else if (_isMapFlag == true)
            {

                if (camMain != null)
                    camMain.camera.enabled = false;
                if (camMap != null)
                    camMap.camera.enabled = true;
                _isMapFlag = false;

            }
        }
        
        // gravity
        _moveDirection.y -= gravity * Time.deltaTime;
        
        // horizontal move
        _moveDirection.x = Input.GetAxis("Horizontal") * moveSpeed;

        ct.Move(_moveDirection * Time.deltaTime);
        
	}
}
