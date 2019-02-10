using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager : MonoBehaviour {

    public float autoLoadNextLevelAfter;
    private static int previousSceneIndex;

    private void Awake() {
        DontDestroyOnLoad(gameObject);
    }

    private void Start() {
        if (autoLoadNextLevelAfter <= 0) {
            Debug.Log("AutoLoadNextLevelDisabled in LevelManager.cs, use a positive value for seconds.");
        } else {
            Invoke("LoadNextLevel", autoLoadNextLevelAfter);
        }
    }

    public void LoadLevel(string name){
        previousSceneIndex = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("LoadLevel(" + name + ") from sceneIndex " + previousSceneIndex);
        SceneManager.LoadScene(name);
	}

	public void QuitRequest(){
		Debug.Log ("Quit requested");
		Application.Quit ();
	}

    public void LoadNextLevel() {
        previousSceneIndex = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("LoadNextLevel() from sceneIndex " + previousSceneIndex);
        SceneManager.LoadScene(previousSceneIndex + 1);
    }

    public void LoadPreviousLevel() {
        int tempIndex = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("LoadPreviousLevel() requested from sceneIndex " + tempIndex + " to go to sceneIndex " + previousSceneIndex);
        SceneManager.LoadScene(previousSceneIndex);
        previousSceneIndex = tempIndex;
    }
}
