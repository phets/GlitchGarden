using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    public GameObject projectile, gun;
    private GameObject projectileParent;
    private Animator animator;
    private AttackerSpawner myLaneSpawner;

    private void Start() {

        animator = gameObject.GetComponent<Animator>();

        AttackerSpawner[] spawnerArray = FindObjectsOfType<AttackerSpawner>();
        foreach(AttackerSpawner spawner in spawnerArray) {
            Vector3 spawnerPosition = spawner.transform.position;
            Vector3 myPosition = gameObject.transform.position;
            if(spawnerPosition.y == myPosition.y) {
                myLaneSpawner = spawner;
                break;
            }
        }

        projectileParent = GameObject.Find("Projectiles");

        if (!projectileParent) {
            projectileParent = new GameObject("Projectiles");
        }
    }

    private void Update() {
        if (IsAttackerAheadInLane()) {
            animator.SetBool("isAttacking", true);
        } else {
            animator.SetBool("isAttacking", false);
        }
    }

    private bool LaneHasAttackers() {
        int numberOfAttackers = myLaneSpawner.transform.childCount;
        if (numberOfAttackers > 0) {
            return true;
        } else {
            return false;
        }
    }

    private bool IsAttackerAheadInLane() {
        if (LaneHasAttackers()) {
            foreach(Transform child in myLaneSpawner.transform) {
                if(child.position.x > gameObject.transform.position.x) {
                    return true;
                }
            }
        }
        return false;
    }

    private void Fire() {
        GameObject newProjectile = Instantiate(projectile);
        newProjectile.transform.parent = projectileParent.transform;
        newProjectile.transform.position = gun.transform.position;
    }
}
