using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EmployeeContract : MonoBehaviour {
    public void GetName(string text) {
        Settings.playerName = text;
    }

    public void GetCursorSensitivity(string text) {
        string parsed = text;
        parsed = parsed.Replace('.', ',');
        float sens;
        bool canFloat = float.TryParse(parsed, out sens);
        if (canFloat && sens != 0) {
            Settings.CursorSensititvity = sens;
        }
    }

    public void GetFullscreen(string text) {
        if (text.ToLower() == "yes") {
            Screen.fullScreen = true;
        } else if (text.ToLower() == "no") {
            Screen.fullScreen = false;
        }
    }

    public void QuitGame() {
        Application.Quit();
    }
}
