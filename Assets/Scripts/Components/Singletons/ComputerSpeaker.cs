using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerSpeaker : Singleton<ComputerSpeaker> {
    public enum Sound {
        NewGroupchatMessage,

    }

    [SerializeField] AudioClip newGroupchatMessage;

    Dictionary<Sound, AudioClip> _sounds = new();

    AudioSource _audioSource;

    void Awake() {
        _audioSource = GetComponent<AudioSource>();    
    }

    void Start() {
        _sounds.Add(Sound.NewGroupchatMessage, newGroupchatMessage);    
    }

    public void PlaySound(Sound sound) {
        _audioSource.clip = _sounds[sound];
        _audioSource.Play();
    }
}
