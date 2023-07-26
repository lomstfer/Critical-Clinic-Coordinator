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
        skills.text = "";
        for (int i = 0; i < employeeData.Skills.Length; i++) {
            if (i > 0 && i < employeeData.Skills.Length) {
                skills.text += ", ";
            }
            skills.text += employeeData.Skills[i].ToString();
        }
    }

    public void RemoveSelf() {
        EmployeeManager.Instance.RemoveEmployee(_employeeData);
        Destroy(gameObject);
    }

    public void ShowMore() {
        patientsUI.gameObject.SetActive(true);
        patientsUI.UpdateData(_employeeData);
    }

    public void HideMore() {
        patientsUI.gameObject.SetActive(false);
    }
}
