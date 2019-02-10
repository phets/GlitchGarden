using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTester : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D collision) {
        Debug.Log("OnCollisionEnter2D gameObject=" + gameObject + " collision=" + collision);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        Debug.Log("OnTriggerEnter2D gameObject=" + gameObject + " collision=" + collision);
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
