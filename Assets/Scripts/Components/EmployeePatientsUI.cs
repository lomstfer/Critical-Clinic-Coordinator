using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmployeePatientsUI : MonoBehaviour {
    [SerializeField] GameObject patientUIPrefab;
    [SerializeField] Transform content;

    Dictionary<Patient, GameObject> patients = new();

    Employee _employee;

    void Start() {
        PatientManager.Instance.NewPatient += AddPatient;  
        PatientManager.Instance.PatientDied += RemovePatient;
    }

    public void UpdateData(Employee employee) {
        _employee = employee;

        foreach (Transform child in content) {
            Destroy(child.gameObject);
        }

        foreach (Patient patient in PatientManager.Instance.Patients) {
            AddPatient(patient);
        }
    }

    void AddPatient(Patient patient) {
        GameObject patientUI = Instantiate(patientUIPrefab, content);
        patientUI.GetComponent<PatientUIScript>().SetData(patient, _employee);
        patients.Add(patient, patientUI);
    }

    void RemovePatient(Patient patient) {
        Destroy(patients[patient]);
        patients.Remove(patient);
    }
}
