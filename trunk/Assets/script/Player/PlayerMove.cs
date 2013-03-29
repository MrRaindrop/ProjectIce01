using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

    public float moveSpeed;
    public float runSpeed;
    public float jumpSpeed;
    public float gravity;

    private Vector3 _moveDirection;

    private CharacterController ct;

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
    }
	
	// Update is called once per frame
	void Update () {

        if (ct.isGrounded)
        {
            _moveDirection = Vector3.zero;

            if (Input.GetButton("Jump"))
                _moveDirection.y = jumpSpeed;
        }
        
        // gravity
        _moveDirection.y -= gravity * Time.deltaTime;
        
        // horizontal move
        _moveDirection.x = Input.GetAxis("Horizontal") * moveSpeed;

        ct.Move(_moveDirection * Time.deltaTime);
        
	}
}
