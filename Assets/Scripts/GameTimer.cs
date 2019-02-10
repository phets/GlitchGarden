using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {

    public float levelDuration = 30;

    private float secondsRemaining;
    private Slider slider;
    private LevelManager levelManager;
    private AudioSource audioSource;
    private GameObject youWinText;
    private bool levelOver;
    
	// Use this for initialization
	void Start () {
        slider = gameObject.GetComponent<Slider>();
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        audioSource = GameObject.FindObjectOfType<AudioSource>();

        youWinText = GameObject.Find("YouWinText");
        if (!youWinText) {
            Debug.LogError("GameTimer.cs - GameObject.Find(\"YouWinText\") - no GameObject found.");
        } else {
            youWinText.SetActive(false);
        }
        
        secondsRemaining = levelDuration;
        levelOver = false;
    }
	
	// Update is called once per frame
	void Update () {
        secondsRemaining = levelDuration - Time.timeSinceLevelLoad;
        if(secondsRemaining < 0 && !levelOver) {
            levelOver = true;
            audioSource.Play();
            youWinText.SetActive(true);
            Debug.Log("GameTimer.cs - You win.");
            Invoke("LoadNextLevel", audioSource.clip.length);
        }
        slider.value = 1 - (secondsRemaining / levelDuration);
	}

    private void LoadNextLevel() {
        levelManager.LoadNextLevel();
    }
}
