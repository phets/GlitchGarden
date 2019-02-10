using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour {

    private Camera camera;
    private GameObject defendersContainer;
    private StarDisplay starDisplay;

	// Use this for initialization
	void Start () {
        camera = FindObjectOfType<Camera>();

        starDisplay = FindObjectOfType<StarDisplay>();

        defendersContainer = GameObject.Find("Defenders");
        if (!defendersContainer) {
            defendersContainer = new GameObject("Defenders");
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private Vector3 SnapToGrid(Vector3 unsnapped) {
        Vector3 roundedClick = new Vector3(Mathf.Round(unsnapped.x), Mathf.Round(unsnapped.y), 0);
        return roundedClick;
    }

    private Vector3 GetWorldPointOfMouse() {
        float mouseX = Input.mousePosition.x;
        float mouseY = Input.mousePosition.y;
        float distanceToCamera = 10f;
        Vector3 screenClick = new Vector3(mouseX, mouseY, distanceToCamera);
        Vector3 worldClick = camera.ScreenToWorldPoint(screenClick);
        return worldClick;
    }

    private void SpawnDefender(GameObject defenderPrefab, Vector3 position) {
        GameObject defender = Instantiate(defenderPrefab, position, Quaternion.identity);
        defender.transform.parent = defendersContainer.transform;
    }

    private void OnMouseDown() {

        Vector3 worldClick = GetWorldPointOfMouse();
        Vector3 snapped = SnapToGrid(worldClick);

        Defender selectedDefender = Button.selectedDefender.GetComponent<Defender>();
        if (selectedDefender) {
            if(starDisplay.UseStars(selectedDefender.starCost) == StarDisplay.Status.SUCCESS) { 
                SpawnDefender(Button.selectedDefender, snapped);
            }
        }
    }
}
