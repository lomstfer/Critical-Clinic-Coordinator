using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : Singleton<MoneyManager> {
    [SerializeField] float patientDiedCost;
    [SerializeField] float patientRecoveredPay;

    public float Money = 0;

    void Start() {
        PatientManager.Instance.PatientDied += PatientDied;
        PatientManager.Instance.PatientRecovered += PatientRecovered;
        TimeManager.Instance.HourTickEvent += OnHourTick;
    }

    void Update() {
            
    }

    void OnHourTick() {
        foreach (Employee emp in EmployeeManager.Instance.Employees) {
            Money -= emp.Salary;
        }

        if (Money < 0) {
            Debug.Log("GAME OVER!!!!!!!!!!!!!!!!!!!");
        }
    }

    void PatientDied(Patient patient) {
        Money -= patientDiedCost;
    }

    void PatientRecovered(Patient patient) {
        Money += patientRecoveredPay;
    }
}
