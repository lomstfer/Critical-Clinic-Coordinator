using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmployeeManager : Singleton<EmployeeManager> {
    [HideInInspector] public List<Employee> Employees = new();

    [SerializeField] EmployeeManagerUIScript ui;

    public void AddEmployee(Employee employee) {
        if (Employees.Contains(employee)) {
            return;
        }

        Employees.Add(employee);
        ui.AddEmployee(employee);

        GroupchatManager.Instance.AddMessage(new GroupchatMessage {
            Message = "Yo yo yo, the name's " + employee.FirstName + ". " + "I will work here now.",
            Sender = employee
        });
    }

    public void RemoveEmployee(Employee employee) {
        GroupchatManager.Instance.AddMessage(new GroupchatMessage
        {
            Message = "Apperently I got fired. Bye bye.",
            Sender = employee
        });

        Employees.Remove(employee);
    }
}