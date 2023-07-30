using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeManager : MonoBehaviour {
    public static SceneChangeManager Instance;

    [HideInInspector] public string SceneToLoad;
    
    void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }

    }

    public void LoadScene(string sceneName) {
        SceneToLoad = sceneName;
        SceneManager.LoadScene("Loading");
    }
}
