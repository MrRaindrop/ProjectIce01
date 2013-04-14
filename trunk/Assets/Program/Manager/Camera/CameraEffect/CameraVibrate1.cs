using UnityEngine;
using System.Collections;

public class CameraVibrate1 : MonoBehaviour {

    public Matrix4x4 originalProjection;
    private float _gap;
    private float _timer;

	// Use this for initialization
	void Start () {

        originalProjection = camera.projectionMatrix;
        _gap = Loop.CameraManager.EffectGap;

	}
	
	// Update is called once per frame
    void Update() {

        StartCoroutine(ShakeEffect1(_gap));

    }

    // 摄像机震动效果1
    public IEnumerator ShakeEffect1(float gap) {

        while (gap > 0)
        {
            gap -= Time.deltaTime;
            Matrix4x4 p = originalProjection;
            p.m01 += Mathf.Sin(Time.time * 120f) * 0.04f;
            p.m10 += Mathf.Sin(Time.time * 150f) * 0.04f;
            camera.projectionMatrix = p;
            yield return 0;
        }
        camera.ResetProjectionMatrix();

        // remove this vibrate effect component.
        Destroy(this);
    }

}
