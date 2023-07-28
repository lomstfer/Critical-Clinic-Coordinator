using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ComputerSpeakerButtonShortcut : ScriptableObject {
    public void PlaySound() {
        if (ComputerSpeaker.Instance != null)
            ComputerSpeaker.Instance.PlaySound(ComputerSpeaker.Sound.ButtonClick);
    }
}
