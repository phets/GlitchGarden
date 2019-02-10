using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour {

    public GameObject[] attackerPrefabArray;
    private GameObject attackersContainer;
    private int lanes = 5;

	// Use this for initialization
	void Start () {
        attackersContainer = GameObject.Find("Attackers");
        if (!attackersContainer) {
            attackersContainer = new GameObject("Attackers");
        }
	}
	
	// Update is called once per frame
	void Update () {
		foreach(GameObject thisAttacker in attackerPrefabArray) {
            if (IsTimeToSpawn(thisAttacker)) {
                Spawn(thisAttacker);
            }
        }
	}

    private bool IsTimeToSpawn (GameObject attackerPrefab) {
        Attacker attacker = attackerPrefab.GetComponent<Attacker>();
        float threshold = Time.deltaTime / (attacker.spawnPeriodSeconds*5);
        if(Random.value < threshold) {
            return true;
        } else {
            return false;
        }
    }

    private void Spawn(GameObject attackerPrefab) {
        Instantiate(attackerPrefab, gameObject.transform.position, Quaternion.identity, gameObject.transform);
    }
}
