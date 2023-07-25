using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EmployeeUIScript : MonoBehaviour {
    [SerializeField] TextMeshProUGUI name;
    [SerializeField] TextMeshProUGUI skills;

    public void SetData(Employee employeeData) {
        name.text = employeeData.FirstName + " " + employeeData.LastName;
        skills.text = "";
        skills.text += "\t* ";
        for (int i = 0; i < employeeData.Skills.Length; i++) {
            if (i > 0 && i < employeeData.Skills.Length) {
                skills.text += ", ";
            }
            skills.text += employeeData.Skills[i].ToString();
        }
    }
}
