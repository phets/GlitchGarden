using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class Defender : MonoBehaviour {

    private StarDisplay starDisplay;
    public int starCost = 100;

    private void Start() {
        starDisplay = GameObject.FindObjectOfType<StarDisplay>();
    }

    public void AddStars(int number) {
        starDisplay.AddStars(number);
    }
}
