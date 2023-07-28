using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class EmployeeManager : Singleton<EmployeeManager> {
    [HideInInspector] public List<Employee> Employees = new();

    public EmployeeManagerUIScript Ui;

    public async void AddEmployee(Employee employee) {
        if (Employees.Contains(employee)) {
            return;
        }

        Employees.Add(employee);
        Ui.AddEmployee(employee);

        await Task.Delay(UnityEngine.Random.Range(700, 1400));

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