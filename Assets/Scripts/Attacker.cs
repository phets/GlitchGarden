using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent( typeof( Health ))]
[RequireComponent( typeof( Rigidbody2D ))]
public class Attacker : MonoBehaviour {

    [Range(-1f, 1.5f)]
    public float currentSpeed;
    public float spawnPeriodSeconds;
    private GameObject currentTarget;
    private Animator animator;
	// Use this for initialization
	void Start () {
        animator = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
        if (!currentTarget) {
            animator.SetBool("isAttacking", false);
        }
	}

    public void SetCurrentSpeed(float speed) {
        currentSpeed = Mathf.Clamp(speed, -1f, 1.5f);
    }

    public void StrikeCurrentTarget(float damage) {
        if (currentTarget) {
            Health health = currentTarget.GetComponent<Health>();
            if (health) {
                health.DealDamage(damage);
                //Debug.Log(name + " - Attacker.cs - StrikeCurrentTarget(" + damage + ")");
            }
        }
    }

    public void Attack(GameObject target) {
        currentTarget = target;
    }
}
