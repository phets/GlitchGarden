using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour {
    
    // destroy anything that meets the shredder
    void OnTriggerEnter2D(Collider2D collider) {
        Destroy(collider.gameObject);
    }
}
