using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerSpeaker : Singleton<ComputerSpeaker> {
    public enum Sound {
        NewGroupchatMessage,
        ButtonClick
    }

    [SerializeField] AudioClip newGroupchatMessage;
    [SerializeField] AudioClip buttonClick;

    Dictionary<Sound, AudioClip> _sounds = new();

    AudioSource _audioSource;

    void Awake() {
        _audioSource = GetComponent<AudioSource>();    
    }

    void Start() {
        _sounds.Add(Sound.NewGroupchatMessage, newGroupchatMessage);    
        _sounds.Add(Sound.ButtonClick, buttonClick);    
    }

    public void PlaySound(Sound sound) {
        _audioSource.PlayOneShot(_sounds[sound]);
    }
}
