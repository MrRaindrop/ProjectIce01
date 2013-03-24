using UnityEngine;
using System.Collections;
using Managers;

public class testCamera : MonoBehaviour {

    public Transform axisTrans;
    public float xspeed;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        CameraManager.CameraOrbit(transform, axisTrans.position, 100.0f, xspeed);
	}
}
