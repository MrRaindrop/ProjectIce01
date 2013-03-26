using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

    public float moveSpeed;
    public float runSpeed;

	// Use this for initialization
	void Awake () {
        
	}

    void Start() {
        moveSpeed = 10.0f;
        runSpeed = 20.0f;
    }
	
	// Update is called once per frame
	void Update () {
        
        // 水平方向移动
        float move = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        transform.Translate(move, 0, 0);
	}
}
