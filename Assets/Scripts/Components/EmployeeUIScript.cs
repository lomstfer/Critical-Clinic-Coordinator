using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EmployeeUIScript : MonoBehaviour {
    [SerializeField] Face face;
    [SerializeField] new TextMeshProUGUI name;
    [SerializeField] TextMeshProUGUI skills;
    [SerializeField] TextMeshProUGUI assignPatientText;
    [SerializeField] TextMeshProUGUI patientInfo;

    Employee _employeeData = null;

    void Update() {
        if (_employeeData != null) {
            if (_employeeData.AssignedPatient != null) {
                assignPatientText.text = "Switch Patient";
                patientInfo.text = "Currently Treating:\n" + _employeeData.AssignedPatient.FirstName + " " + _employeeData.AssignedPatient.LastName;
            } else {
                assignPatientText.text = "Assign Patient";
                patientInfo.text = "";
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
