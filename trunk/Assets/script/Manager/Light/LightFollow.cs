using UnityEngine;
using System.Collections;

public class LightFollow : MonoBehaviour {

    private Observer _ob;
    private Loop.Player _player;
    private Vector3 _plPos;

    private float _time;

	// Use this for initialization
	void Start () {

        light.range = Loop.LightConstants.PLAYER_LIGHT_RANGE;
        light.intensity = Loop.LightConstants.PLAYER_LIGHT_INTENSITY;

        _ob = GameObject.FindWithTag("Observer").GetComponent<Observer>();
        _player = _ob.GetCurrentPlayer();

        //_time = 3.0f;

	}
	
	// Update is called once per frame
	void Update () {

        //Loop.LightManager.PlayerLightUp();

        _plPos = _player.AttachedGameObject.transform.position;
        transform.position = _plPos + new Vector3(
            0f, Loop.LightConstants.PLAYER_LIGHT_HEIGHT, -Loop.LightConstants.PLAYER_LIGHT_DIS);
	
	}
}
