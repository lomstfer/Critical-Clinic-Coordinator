using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientManager : Singleton<PatientManager> {
    [SerializeField] float spawnNewPatientTime;
    [SerializeField] float spawnNewPatientRandomnessTime;

    public List<Patient> Patients = new();

    public event Action<Patient> NewPatient;
    public event Action<Patient> PatientDied;

    public List<Patient> _patientsToRemove = new();

    public void AssignPatientToEmployee(Patient patient, Employee employee) {
        patient.ResponsibleEmployees.Add(employee);
    }

    void Start() {
        TimeManager.Instance.MinuteTickEvent += OnMinuteTick;
        StartCoroutine(SpawnPatients());
    }

    IEnumerator SpawnPatients() {
        while (true) {
            SpawnPatient();
            yield return new WaitForSeconds(UnityEngine.Random.Range(spawnNewPatientTime -  spawnNewPatientRandomnessTime, spawnNewPatientTime + spawnNewPatientRandomnessTime));
        }
    }

    void SpawnPatient() {
        Patient p = PatientGenerator.GenerateNewPatient();
        Patients.Add(p);
        NewPatient?.Invoke(p);
        //GroupchatManager.Instance.AddMessage(new GroupchatMessage
        //{
            
        //});
    }

    void OnMinuteTick() {
        foreach (Patient patient in Patients) {
            SetPatientTickValue(patient);
        }

        foreach (Patient patient in _patientsToRemove) {
            Patients.Remove(patient);
        }
       _patientsToRemove.Clear();
    }

    void SetPatientTickValue(Patient patient) {
        patient.Healthyness -= 1;

        if (patient.Healthyness < 0) {
            PatientDied?.Invoke(patient);
            GroupchatManager.Instance.AddMessage(new GroupchatMessage
            {
                Sender = new Employee { FirstName = "THE ", LastName = "BOSS", FaceId = null, Skills = null},
                Message = "I'm sorry to inform you that we were unable to save " + patient.FirstName + " " + patient.LastName + ". @Player, you better start hiring more competent people!" ,
            });
            _patientsToRemove.Add(patient);
            return;
        }

        Debug.Log(patient.FirstName + " " + patient.Healthyness.ToString());

        if (patient.ResponsibleEmployees.Count >= patient.SyndromeExtremeness) {
            patient.Healthyness += 2;
        }
    }
}