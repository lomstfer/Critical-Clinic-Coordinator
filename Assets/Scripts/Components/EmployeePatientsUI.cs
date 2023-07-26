using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmployeePatientsUI : MonoBehaviour {
    [SerializeField] GameObject patientUIPrefab;
    [SerializeField] Transform content;

    public void UpdateData(Employee employee) {
        foreach (Transform child in content) {
            Destroy(child.gameObject);
        }

        foreach (Patient patient in PatientManager.Instance.Patients) {
            AddPatient(patient);
        }
    }

    void AddPatient(Patient patient) {
        GameObject patientUI = Instantiate(patientUIPrefab, content);
        patientUI.GetComponent<PatientUIScript>().SetData(patient);
    }
}
