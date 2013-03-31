using UnityEngine;
using System.Collections;

public class TriggerEvent : MonoBehaviour {

    void OnTriggerEnter(Collider other){
        if (other.gameObject.CompareTag("Player")) {
            // test key
            // do something
        }
    }
}
