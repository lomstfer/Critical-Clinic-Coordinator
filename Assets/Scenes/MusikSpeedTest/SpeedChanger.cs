using System.Collections;
using System.Collections.Generic;
using UnityEditor.Audio;
using UnityEngine;
using UnityEngine.Audio;

public class speedchanged : MonoBehaviour {
    [SerializeField] AudioSource aSource;
    [SerializeField] AudioMixer mixer;
    AudioMixerEffectPlugin pitchShifter;

    void Start() {
        //pitchShifter = mixer.
    }

    void Update() {
        if (Input.GetKey(KeyCode.UpArrow)) {
            aSource.pitch += Time.deltaTime * 0.1f;
            
        }

        if (Input.GetKey(KeyCode.DownArrow)) {

        }
    }
}
