using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")) {
            other.gameObject.GetComponent<PlayerController>().LifeLost();
        }
        else {
            Destroy(other.gameObject);
        }
    }
}
