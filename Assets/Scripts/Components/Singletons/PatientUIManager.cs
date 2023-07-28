using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PatientUIManager : Singleton<PatientUIManager> {
    [SerializeField] GameObject patientPrefab;
    [SerializeField] Transform patientList;
    [SerializeField] EmployeeUIScript selectedEmployeeUIScript;

    [SerializeField] Image background;
    [SerializeField] Image border;
    [SerializeField] Image scrollBG;
    [SerializeField] Image scrollHandle;

    Employee _selectedEmployee = null;

    Dictionary<Patient, GameObject> _patients = new();

    public void Show(Employee selectedEmployee) {
        selectedEmployeeUIScript.SetData(selectedEmployee);

        background.color = selectedEmployee.ColorId;
        border.color = new(background.color.r * 0.6f, background.color.g * 0.6f, background.color.b * 0.6f, 1f);
        scrollHandle.color = background.color;
        scrollBG.color = border.color;

        _selectedEmployee = selectedEmployee;
        gameObject.SetActive(true);
    }

    public void Hide() {
        _selectedEmployee = null;
        gameObject.SetActive(false);
    }

    public void SubscribeToEvents() {
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
