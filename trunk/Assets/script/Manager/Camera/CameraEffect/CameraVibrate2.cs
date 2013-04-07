using UnityEngine;
using System.Collections;

public class CameraVibrate2 : MonoBehaviour
{
    private float _gap;
    private float _frameTime;
    private float _shakeDelta;
    private float _fps;

    // Use this for initialization
    void Start()
    {
        _frameTime = 0f;
        _gap = Loop.CameraManager.EffectGap;
        _shakeDelta = Loop.CameraManager.ShakeDelta;
        _fps = Loop.CameraManager.EffectFps;
    }

    // Update is called once per frame
    void Update() {

        StartCoroutine(ShakeEffect2(_gap, _shakeDelta, _fps));

    }

    // 摄像机震动效果2
    public IEnumerator ShakeEffect2(float gap, float shakeDelta, float fps)
    {

        while (gap > 0)
        {
            gap -= Time.deltaTime;
            _frameTime += Time.deltaTime;
            if (_frameTime > 1f / fps)
            {
                _frameTime = 0;
                camera.rect = new Rect(shakeDelta * (-1.0f + 2.0f * Random.value),
                shakeDelta * (-1.0f + 2.0f * Random.value), 1.0f, 1.0f);
                Debug.Log(camera.rect.center.x + ", " + camera.rect.center.y);
            }
            yield return 0;
        }

        // recover camera rect.
        camera.rect = new Rect(0, 0, 1, 1);

        // remove this vibrate effect component.
        Destroy(this);
    }

}
