using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerSpeaker : Singleton<ComputerSpeaker> {
    public enum Sound {
        NewGroupchatMessage,
        ButtonClick,
        MouseClickDown,
        MouseClickUp,
    }

    AudioSource _audioSource;

    [SerializeField] AudioClip newGroupchatMessage;
    [SerializeField] AudioClip buttonClick;

    Dictionary<Sound, AudioClip> _sounds = new();

    void Awake() {
        _audioSource = GetComponent<AudioSource>();
    }

    void Start() {
        MoneyManager.Instance.GameOverEvent += OnGameOver;
        _sounds.Add(Sound.NewGroupchatMessage, newGroupchatMessage);    
        _sounds.Add(Sound.ButtonClick, buttonClick);  
    }

    void Update() {
        if (MoneyManager.Instance != null && !MoneyManager.Instance.GameOver) {
            _audioSource.volume = SavedData.Data.EffectsVolume / 100f;
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
            yield return new WaitForSeconds(MoneyManager.Instance.GameOverTickTime);
        }
    }

    public void PlaySound(Sound sound) {
        _audioSource.PlayOneShot(_sounds[sound]);
    }
}
