using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicAudio : MonoBehaviour {
    AudioSource _audioSource;

    void Awake() {
        _audioSource = GetComponent<AudioSource>();
    }

    void Start() {
    }

    void Update() {
        _audioSource.volume = SavedData.Data.MusicVolume / 100f;
    }
}
