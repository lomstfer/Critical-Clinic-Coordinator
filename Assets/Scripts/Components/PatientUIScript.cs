using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PatientUIScript : MonoBehaviour {
    [SerializeField] TextMeshProUGUI nameT;
    [SerializeField] TextMeshProUGUI syndromes;
    [SerializeField] TextMeshProUGUI assignedEmployees;

    Patient _patient;
    Employee _employee;

    public void SetData(Patient patientData, Employee employeeData) {
        nameT.text = patientData.FirstName + " " + patientData.LastName;
        syndromes.text = "";
        for (int i = 0; i < patientData.Syndromes.Length; i++) {
            if (i > 0 && i < patientData.Syndromes.Length) {
                syndromes.text += ", ";
            }
            syndromes.text += patientData.Syndromes[i].ToString();
        }
        assignedEmployees.text = patientData.ResponsibleEmployees.Count.ToString() + "/" + patientData.SyndromeExtremeness.ToString();

        _patient = patientData;
        _employee = employeeData;
    }

    public void Assign() {
        PatientManager.Instance.AssignEmployeeToPatient(_patient, _employee);
    }

    public void Remove() {
        PatientManager.Instance.RemoveEmployeeFromPatient(_patient, _employee);
    }
}
