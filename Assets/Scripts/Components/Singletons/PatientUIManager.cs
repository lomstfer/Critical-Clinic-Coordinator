using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientUIManager : Singleton<PatientUIManager> {
    [SerializeField] GameObject patientPrefab;
    [SerializeField] Transform patientList;

    Employee _selectedEmployee = null;

    Dictionary<Patient, GameObject> _patients = new();

    public void Show(Employee selectedEmployee) {
        _selectedEmployee = selectedEmployee;
        gameObject.SetActive(true);
    }

    public void Hide() {
        _selectedEmployee = null;
        gameObject.SetActive(false);
    }

    void Start() {
        PatientManager.Instance.NewPatient += NewPatient;
        PatientManager.Instance.RemovePatient += RemovePatient;
    }

    void Update() {
        if (_selectedEmployee == null) {
            return;
        } 

        foreach (var patient in _patients) {
            patient.Value.GetComponent<PatientUIScript>().SetData(patient.Key, _selectedEmployee);
        }
    }

    void NewPatient(Patient patient) {
        GameObject p = Instantiate(patientPrefab, patientList);
        _patients.Add(patient, p);
    }

    void RemovePatient(Patient patient) {
        Destroy(_patients[patient]);
        _patients.Remove(patient);
    }
}
