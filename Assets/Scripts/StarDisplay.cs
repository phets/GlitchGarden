using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class StarDisplay : MonoBehaviour {

    private int stars = 500;
    private Text starDisplayText;
    public enum Status {SUCCESS,FAILURE};

	// Use this for initialization
	void Start () {
        starDisplayText = gameObject.GetComponent<Text>();
        UpdateStarDisplay();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddStars(int numberOfStars) {
        stars += numberOfStars;
        UpdateStarDisplay();
    }

    public Status UseStars(int numberOfStars) {
        if(stars - numberOfStars < 0) {
            return Status.FAILURE;
        } else {
            stars -= numberOfStars;
            UpdateStarDisplay();
            return Status.SUCCESS;
        }
    }

    private void UpdateStarDisplay() {
        starDisplayText.text = stars.ToString();
    }
}
