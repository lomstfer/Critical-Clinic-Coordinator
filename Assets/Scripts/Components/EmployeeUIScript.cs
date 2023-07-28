using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EmployeeUIScript : MonoBehaviour {
    [SerializeField] Face face;
    [SerializeField] TextMeshProUGUI nameT;
    [SerializeField] Image background;
    [SerializeField] TextMeshProUGUI skills;
    [SerializeField] TextMeshProUGUI assignPatientText;
    [SerializeField] TextMeshProUGUI patientInfo;
    [SerializeField] float nameMaxWidth;

    Employee _employeeData = null;

    void Update() {
        if (_employeeData != null) {
            if (_employeeData.AssignedPatient != null) {
                assignPatientText.text = "Switch Patient";
                patientInfo.text = "Currently Treating:\n  * " + _employeeData.AssignedPatient.FirstName + " " + _employeeData.AssignedPatient.LastName;
            } else {
                assignPatientText.text = "Assign Patient";
                patientInfo.text = "";
            }
        }    
    }

    public void SetData(Employee employeeData) {
        _employeeData = employeeData;

        background.color = employeeData.ColorId;

        face.ApplyFaceId(employeeData.FaceId);

        nameT.text = employeeData.FirstName + " " + employeeData.LastName;
        nameT.ForceMeshUpdate();
        while (nameT.textBounds.size.x > nameMaxWidth) {
            nameT.fontSize -= 0.5f;
            nameT.ForceMeshUpdate();
        }

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
