using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientManager : Singleton<PatientManager> {
    IEnumerator PatientCountdown(Employee employee, Skill[] requiredSkills) {
        // Send messages to game manager about patient health;
        yield return null;
    }
}