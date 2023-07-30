using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadTheLoadScene : MonoBehaviour {
    [SerializeField] float minimalLoadTime = 0.5f;

    void Start() {
        Loade();
    }

    async void Loade() {
        AsyncOperation a = SceneManager.LoadSceneAsync(SceneChangeManager.Instance.SceneToLoad);
        a.allowSceneActivation = false;
        
        await Task.Delay((int)(minimalLoadTime * 1000));

        a.allowSceneActivation = true;

        //a.allowSceneActivation = true;

    }
}
