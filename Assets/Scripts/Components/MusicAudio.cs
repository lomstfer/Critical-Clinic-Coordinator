using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicAudio : MonoBehaviour {
    AudioSource _audioSource;

    float volumeWant;
    float pitchWant;

    void Awake() {
        _audioSource = GetComponent<AudioSource>();
    }

    void Start() {
        MoneyManager.Instance.GameOverEvent += OnGameOver;
    }

    void Update() {
        if (!MoneyManager.Instance.GameOver) {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, SavedData.Data.MusicVolume / 100f, 0.2f * Time.unscaledDeltaTime);
            volumeWant = _audioSource.volume;
            pitchWant = _audioSource.pitch;
        } else {
            _audioSource.volume = Mathf.Lerp(_audioSource.volume, volumeWant, Time.deltaTime);
            _audioSource.pitch = Mathf.Lerp(_audioSource.pitch, pitchWant, Time.deltaTime);
        }
    }

    void OnGameOver() {
        StartCoroutine(GameOverTicking());
    }

    IEnumerator GameOverTicking() {

        int times = Mathf.RoundToInt(MoneyManager.Instance.GameOverTotalTickTime / MoneyManager.Instance.GameOverTickTime);

        float decreasePerTick = _audioSource.volume / (float)times;

        for (int i = times; i > 0; i--) {
            volumeWant -= decreasePerTick;
            pitchWant -= decreasePerTick;
            yield return new WaitForSeconds(MoneyManager.Instance.GameOverTickTime);
        }
    }
}
