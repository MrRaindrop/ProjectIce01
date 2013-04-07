using UnityEngine;
using System.Collections;

public class CameraEffect : MonoBehaviour {

    public Matrix4x4 originalProjection;
    public float gap;
    public float frameTime;
    public float shakeDelta;
    public float fps;
    public float timer;

	// Use this for initialization
	void Start () {

        gap = 3f;
        fps = 30f;
        frameTime = 0f;
        shakeDelta = 0.005f;
        originalProjection = camera.projectionMatrix;

	}
	
	// Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.F)) {

            Debug.Log("F!");
            
            //StartCoroutine(ShakeEffect1(gap));
            
            StartCoroutine(ShakeEffect2(gap, shakeDelta, fps));
        }
    }

    // 摄像机震动效果1
    public IEnumerator ShakeEffect1(float gap)
    {

        timer = Time.time;
        while (Time.time - timer <= gap)
        {
            Matrix4x4 p = originalProjection;
            p.m01 += Mathf.Sin(Time.time * 120f) * 0.04f;
            p.m10 += Mathf.Sin(Time.time * 150f) * 0.04f;
            camera.projectionMatrix = p;
            yield return 0;
        }
        camera.ResetProjectionMatrix();
    }

    // 摄像机震动效果2
    public IEnumerator ShakeEffect2(float gap, float shakeDelta, float fps) {

        while (gap > 0) {
            gap -= Time.deltaTime;
            frameTime += Time.deltaTime;
            if (frameTime > 1f / fps) {
                frameTime = 0;
                camera.rect = new Rect(shakeDelta * (-1.0f + 2.0f * Random.value),
                shakeDelta * (-1.0f + 2.0f * Random.value), 1.0f, 1.0f);
                Debug.Log(camera.rect.center.x + ", " + camera.rect.center.y);
            }
            yield return 0;
        }

        // recover camera rect.
        camera.rect = new Rect(0, 0, 1, 1);

    }

}
