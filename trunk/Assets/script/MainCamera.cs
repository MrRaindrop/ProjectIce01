using UnityEngine;
using System.Collections;

public class MainCamera : MonoBehaviour {

    public Transform target;
    private float height = 3.0f;    // 摄像机与target相对高度
    private float distance = 10.0f;     // 摄像机与target在z轴上的距离

    public float heightDamping = 10.0f;
    public float moveDamping = 10.0f;

	// Use this for initialization
    void Start() {
        target = GameObject.FindWithTag("Player").transform;
        transform.position = target.position + new Vector3(0, height, -distance);
        transform.LookAt(target);
    }

    // Update is called once per frame
    void LateUpdate() {

        CameraFollow(target);

	}

    public void CameraFollow(Transform target)
    {

        if (!target)
            return;

        // Calculate the current rotation angles
        float wantedMove = target.position.x;
        float wantedHeight = target.position.y + height;

        float currentMove = transform.position.x;
        float currentHeight = transform.position.y;

        // Damp the height
        currentMove = Mathf.Lerp(currentMove, wantedMove, moveDamping * Time.deltaTime);
        currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);

        transform.position = new Vector3(currentMove, currentHeight, transform.position.z);

        // Set the height of the camera
        //transform.Translate(transform.position.x, currentHeight, transform.position.y);
        //transform.position.y = currentHeight;

        // Always look at the target
        transform.LookAt(target);

    }
}




