using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EmployeeContract : MonoBehaviour {
    [SerializeField] TMP_InputField nameInput;
    [SerializeField] TMP_InputField mouseSensitivity;
    [SerializeField] TMP_InputField fullscreen;
    [SerializeField] TMP_InputField musicVolume;
    [SerializeField] TMP_InputField effectsVolume;

    void Start() {
        GetComponent<RectTransform>().eulerAngles += new Vector3(0, 0, UnityEngine.Random.Range(-1.5f, 1.5f));

        SetData();
    }

    public void SetData() {
        nameInput.text = SavedData.Data.PlayerName;
        mouseSensitivity.text = SavedData.Data.CursorSensititvity.ToString();
        fullscreen.text = SavedData.Data.Fullscreen ? "yes" : "no";
        musicVolume.text = SavedData.Data.MusicVolume.ToString();
        effectsVolume.text = SavedData.Data.EffectsVolume.ToString();
    }

    public void GetName(string text) {
        SavedData.Data.PlayerName = text;
    }

    public void GetCursorSensitivity(string text) {
        string parsed = text;
        parsed = parsed.Replace('.', ',');
        float sens;
        bool canFloat = float.TryParse(parsed, out sens);
        if (canFloat && sens != 0) {
            SavedData.Data.CursorSensititvity = sens;
        }
    }

    public void GetFullscreen(string text) {
        if (text.ToLower() == "yes") {
            SavedData.Data.Fullscreen = true;
            Screen.fullScreen = true;
        } else if (text.ToLower() == "no") {
            SavedData.Data.Fullscreen = true;
            Screen.fullScreen = false;
        }
    }

    public void GetMusicVolume(string text) {
        string parsed = text;
        parsed = parsed.Replace('.', ',');
        float vol;
        bool canFloat = float.TryParse(parsed, out vol);
        if (canFloat) {
            SavedData.Data.MusicVolume = vol;
        }
    }

    public void GetEffectsVolume(string text) {
        string parsed = text;
        parsed = parsed.Replace('.', ',');
        float vol;
        bool canFloat = float.TryParse(parsed, out vol);
        if (canFloat) {
            SavedData.Data.EffectsVolume = vol;
        }
    }

    public void Confirm() {
        SceneChangeManager.Instance.LoadScene("Game");
    }

    public void QuitGame() {
        Application.Quit();
    }

    void OnApplicationQuit() {
        SavedData.SaveData();
    }
}
