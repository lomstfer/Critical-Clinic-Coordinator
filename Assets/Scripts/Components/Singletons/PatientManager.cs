using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientManager : Singleton<PatientManager> {
    public List<Patient> Patients = new();

    void Awake() {
        TimeManager.Instance.MinuteTickEvent += OnMinuteTick;
    }

    void OnMinuteTick() {
        foreach (Patient patient in Patients) {
            SetPatientTickValue(patient);
        }
    }

    void SetPatientTickValue(Patient patient) {

    }
}