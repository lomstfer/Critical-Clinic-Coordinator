using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EmployeeUIScript : MonoBehaviour {
    [SerializeField] Face face;
    [SerializeField] new TextMeshProUGUI name;
    [SerializeField] TextMeshProUGUI skills;

    [SerializeField] EmployeePatientsUI patientsUI;

    Employee _employeeData;

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

    public void ShowMore() {
        patientsUI.gameObject.SetActive(true);
        patientsUI.SpawnCurrentPatients(_employeeData);
    }

    public void HideMore() {
        patientsUI.gameObject.SetActive(false);
    }
}
