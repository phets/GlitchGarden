using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour {

    public static GameObject selectedDefender;
    public GameObject defenderPrefab;
    private Button[] buttonArray;
	// Use this for initialization
	void Start () {
        buttonArray = FindObjectsOfType<Button>();
        SetCostUIText();
    }

    private void SetCostUIText() {
        Defender defender = defenderPrefab.GetComponent<Defender>();
        int cost = defender.starCost;
        Text costText = this.GetComponentInChildren<Text>();
        if (!costText) {
            Debug.LogWarning("Button.cs - cannot find cost text component for" + name);
        }
        costText.text = cost.ToString();
    }

    // Update is called once per frame
    void Update () {
		
	}

    private void OnMouseDown() {
        Debug.Log("Button.cs - OnMouseDown() - "+name);

        SpriteRenderer tempRenderer;

        foreach(Button thisButton in buttonArray) {
            tempRenderer = thisButton.GetComponentInChildren<SpriteRenderer>();
            if(thisButton == this) {
                selectedDefender = defenderPrefab;
                tempRenderer.color = Color.white;
            } else {
                tempRenderer.color = Color.black;
            }
        }
    }
}
