using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour {

    public Slider volumeSlider;
    public Slider difficultySlider;
    public LevelManager levelManager;
    private MusicManager musicManager;
    private AudioSource musicManagerSource;
    public float defaultVolume = 0.1f;
    public float defaultDifficulty = 0.1f;

	// Use this for initialization
	void Start () {
        musicManager = FindObjectOfType<MusicManager>();
        musicManagerSource = musicManager.GetComponent<AudioSource>();

        volumeSlider.value = PlayerPrefsManager.GetMasterVolume();
        volumeSlider.onValueChanged.AddListener( delegate {
            updateMusicVolume();
        });
        difficultySlider.value = PlayerPrefsManager.GetDifficulty();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void updateMusicVolume() {
        musicManagerSource.volume = volumeSlider.value;
    }

    public void SaveAndExit() {
        PlayerPrefsManager.SetMasterVolume(volumeSlider.value);
        PlayerPrefsManager.SetDifficulty((int)difficultySlider.value);
        levelManager.LoadPreviousLevel();
    }
    public void SetDefaults() {
        volumeSlider.value = defaultVolume;
        difficultySlider.value = defaultDifficulty;
    }
}
