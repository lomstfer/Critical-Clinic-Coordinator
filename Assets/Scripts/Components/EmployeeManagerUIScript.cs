using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmployeeManagerUIScript : MonoBehaviour {
    [SerializeField] GameObject employeeUIPrefab;
    [SerializeField] Transform employeeUIContent;

    public void AddEmployee(Employee employee) { 
        GameObject employeeUI = Instantiate(employeeUIPrefab, employeeUIContent);
        employeeUI.GetComponent<EmployeeUIScript>().SetData(employee);
    }

}
