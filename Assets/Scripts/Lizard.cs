using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent( typeof( Attacker ))]
public class Lizard : MonoBehaviour {

    private Animator lizardAnimator;
    private Attacker parentAttacker;
    // Use this for initialization
    void Start() {
        lizardAnimator = GetComponent<Animator>();
        parentAttacker = GetComponentInParent<Attacker>();
    }

    // Update is called once per frame
    void Update() {

    }

    private void OnTriggerEnter2D(Collider2D collision) {

        // get the GameObject we've collided with
        GameObject obj = collision.gameObject;

        // quit the function if the object doesn't have
        // a Defender component i.e. it's not a defender
        if (!obj.GetComponent<Defender>()) {
            return;
        } else {
            lizardAnimator.SetBool("isAttacking", true);
            parentAttacker.Attack(obj);
        }
    }
}
