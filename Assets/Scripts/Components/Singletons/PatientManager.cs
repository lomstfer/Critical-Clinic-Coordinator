using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientManager : Singleton<PatientManager> {
    public List<Patient> Patients = new();

    public event Action<Patient> PatientDied;

    public void AssignPatientToEmployee(Patient patient, Employee employee) {
        patient.ResponsibleEmployees.Add(employee);
    }

    void Start() {
        TimeManager.Instance.MinuteTickEvent += OnMinuteTick;
    }

    void OnMinuteTick() {
        foreach (Patient patient in Patients) {
            SetPatientTickValue(patient);
        }
    }

    void SetPatientTickValue(Patient patient) {
        patient.Healthyness -= 1;

        if (patient.Healthyness < 0) {
            PatientDied?.Invoke(patient);
            return;
        }

        if (patient.SyndromeExtremeness >= patient.ResponsibleEmployees.Count) {
            patient.Healthyness += 2;
        }
    }
}