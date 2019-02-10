using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour {

    public AudioClip[] audioClipAutoChange;
    private AudioSource audioSource;

    private void Awake() {
        DontDestroyOnLoad(gameObject);
        audioSource = transform.GetComponent<AudioSource>();
        audioSource.volume = PlayerPrefsManager.GetMasterVolume();
    }

    private void OnEnable() {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene,LoadSceneMode mode) {
        int sceneIndex = scene.buildIndex;
        if(audioClipAutoChange[sceneIndex] && audioSource.clip != audioClipAutoChange[sceneIndex]) { 
            audioSource.clip = audioClipAutoChange[sceneIndex];
            audioSource.loop = true;
            audioSource.Play();
        }
    }
    // Use this for initialization
    private void Start () {
		
	}
	
	// Update is called once per frame
	private void Update () {
		
	}

    private void OnDisable() {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
