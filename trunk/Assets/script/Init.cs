using UnityEngine;
using System.Collections;

public class Init : MonoBehaviour {

	// Use this for initialization
	void Start () {

        InitEventArray();
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void InitEventArray() {

        Loop.EventManager.EventArray[(int)Loop.EventType.AfterGettingKey] = new Loop.Event((int)Loop.EventType.AfterGettingKey);
     
    }
}
