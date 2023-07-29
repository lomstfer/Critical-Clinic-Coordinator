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
            text.text = highscore.ToString();
        } else {
            title.gameObject.SetActive(false);
            text.text = "";
        }
    }
}
