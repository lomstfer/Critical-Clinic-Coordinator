using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicAudio : MonoBehaviour {
    AudioSource _audioSource;

    void Awake() {
        _audioSource = GetComponent<AudioSource>();
    }

    void Start() {
        MoneyManager.Instance.GameOverEvent += OnGameOver;
    }

    void Update() {
        if (!MoneyManager.Instance.GameOver) {
            _audioSource.volume = SavedData.Data.MusicVolume / 100f;
        }
    }

    void OnGameOver() {
        StartCoroutine(GameOverTicking());
    }

    IEnumerator GameOverTicking() {

        int times = Mathf.RoundToInt(MoneyManager.Instance.GameOverTotalTickTime / MoneyManager.Instance.GameOverTickTime);

        float decreasePerTick = _audioSource.volume / (float)times;

        for (int i = times; i > 0; i--) {
            _audioSource.volume -= decreasePerTick;
            _audioSource.pitch -= decreasePerTick;
            yield return new WaitForSeconds(MoneyManager.Instance.GameOverTickTime);
        }
    }
}
