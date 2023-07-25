using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmployeeManager : Singleton<EmployeeManager> {
    [HideInInspector] public List<Employee> Employees = new();

    public void AddEmployee(Employee employee) {
        Employees.Add(employee);
    }

    public void RemoveEmployee(Employee employee) {
        Employees.Remove(employee);
    }
}