using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerSpeaker : Singleton<ComputerSpeaker> {
    public enum Sound {
        NewGroupchatMessage,
        ButtonClick
    }

    [SerializeField] AudioSource audioSource1;
    [SerializeField] AudioSource audioSource2;

    [SerializeField] AudioClip newGroupchatMessage;
    [SerializeField] AudioClip buttonClick;

    Dictionary<Sound, AudioClip> _sounds = new();

    void Start() {
        _sounds.Add(Sound.NewGroupchatMessage, newGroupchatMessage);    
        _sounds.Add(Sound.ButtonClick, buttonClick);    
    }

    public void PlaySound(Sound sound) {
        audioSource1.PlayOneShot(_sounds[sound]);
        audioSource2.PlayOneShot(_sounds[sound]);
    }
}
