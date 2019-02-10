using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPrefsManager : MonoBehaviour {

    const string MASTER_VOLUME_KEY = "master_volume";
    const string DIFFICULTY_KEY = "difficulty";
    const string LEVEL_UNLOCK_KEY = "level_unlock_";

    // Volume
    public static void SetMasterVolume(float volume) {
        if (volume >= 0f && volume <= 1f) {
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
            Debug.Log("PlayerPrefsManager.SetMasterVolume(" + volume + ")");
        } else {
            Debug.LogError("master_volume out of bounds in PlayerPrefsManager.SetMasterVolume(" + volume + ")");
        }
    }
    public static float GetMasterVolume() {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }

    // Level unlocks
    public static void UnlockLevel(int level) {
        if (level < SceneManager.sceneCountInBuildSettings && level >= 0) {
            // Use 1 for true since PlayerPrefs has no bools
            PlayerPrefs.SetInt(LEVEL_UNLOCK_KEY + level.ToString(), 1);
            Debug.Log("PlayerPrefsManager.UnlockLevel(" + level + ")");
        } else {
            Debug.LogError("level index not in build settings in PlayerPrefsManager.UnlockLevel(" + level + ")");
        }
    }
    public static bool IsLevelUnlocked(int level) {
        if (level < SceneManager.sceneCountInBuildSettings && level >= 0) {
            int storedData = PlayerPrefs.GetInt(LEVEL_UNLOCK_KEY + level.ToString());
            if (storedData == 1) {
                return true;
            } else if (storedData == 0) {
                return false;
            } else {
                Debug.LogError("corrupted value in PlayerPrefsManager.IsLevelUnlocked(" + level + ") = " + storedData);
                return false;
            }
        } else {
            Debug.LogError("level index not in build settings in PlayerPrefsManager.IsLevelUnlocked(" + level + ")");
            return false;
        }
    }

    // Difficulty
    public static void SetDifficulty(int difficulty) {
        if(difficulty >= 1 && difficulty <= 3) {
            PlayerPrefs.SetInt(DIFFICULTY_KEY, difficulty);
            Debug.Log("PlayerPrefsManager.SetDifficulty(" + difficulty + ")");
        } else {
            Debug.LogError("difficulty out of bounds in PlayerPrefsManager.SetMasterVolume(" + difficulty + ")");
        }
    }
    public static int GetDifficulty() {
        return PlayerPrefs.GetInt(DIFFICULTY_KEY);
    }
}
