using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Clock : MonoBehaviour {
    [SerializeField] TMP_Text text;

    void Update() {
        string t = "";
        for (int i = 0; i < 4; i++) {
            t += TimeManager.DigitalTime[i];
            if (i == 1) {
                t += ":";
            }
        }
        text.text = t;
    }
}