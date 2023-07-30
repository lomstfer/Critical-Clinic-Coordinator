using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataLoader : MonoBehaviour {
    void Start() {
        SavedData.LoadData();
        SceneChangeManager.Instance.LoadScene("Menu");
    }
}
