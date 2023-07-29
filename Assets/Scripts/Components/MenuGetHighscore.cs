using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuGetHighscore : MonoBehaviour {
    [SerializeField] TextMeshProUGUI title;
    [SerializeField] TextMeshProUGUI text;

    void Start() {
    }

    void Update() {
        float highscore = SavedData.Data.Highscore;
        if (highscore > 0) {
            title.gameObject.SetActive(true);

            int minutes = Mathf.RoundToInt(highscore) % 60;
            int hours = (Mathf.RoundToInt(highscore) - minutes) / 60;

            text.text = hours.ToString() + "h " + minutes.ToString() + "min";
        } else {
            title.gameObject.SetActive(false);
            text.text = "";
        }
    }
}
