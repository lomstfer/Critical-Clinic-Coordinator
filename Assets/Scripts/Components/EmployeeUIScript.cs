using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EmployeeUIScript : MonoBehaviour {
    [SerializeField] Face face;
    [SerializeField] new TextMeshProUGUI name;
    [SerializeField] TextMeshProUGUI skills;
    [SerializeField] GameObject currentPatientText;
    [SerializeField] TextMeshProUGUI currentPatientName;

    Employee _employeeData = null;

    void Update() {
        if (_employeeData != null) {
            if (_employeeData.AssignedPatient != null) {
                currentPatientText.SetActive(true);
                currentPatientName.gameObject.SetActive(true);
                currentPatientName.text = _employeeData.AssignedPatient.FirstName + " " + _employeeData.AssignedPatient.LastName;
            } else {
                currentPatientText.SetActive(false);
                currentPatientName.gameObject.SetActive(false);
                currentPatientName.text = "";
            }
        }    
    }

    public void SetData(Employee employeeData) {
        _employeeData = employeeData;

        face.ApplyFaceId(employeeData.FaceId);

        name.text = employeeData.FirstName + " " + employeeData.LastName;
        skills.text = Utils.GetSkillsAsString(employeeData.Skills);
    }

    public void RemoveSelf() {
        EmployeeManager.Instance.RemoveEmployee(_employeeData);
        Destroy(gameObject);
    }

    public void ShowAllPatients() {
        PatientUIManager.Instance.Show(_employeeData);
    }
}
