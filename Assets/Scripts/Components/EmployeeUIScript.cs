using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EmployeeUIScript : MonoBehaviour {
    [SerializeField] Face face;
    [SerializeField] TextMeshProUGUI name;
    [SerializeField] TextMeshProUGUI skills;

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
}
