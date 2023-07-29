using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : Singleton<MoneyManager> {
    [SerializeField] float patientDiedCost;
    [SerializeField] float patientRecoveredPay;

    public float GameOverTickTime = 0.5f;
    public float GameOverTotalTickTime = 2f;

    public event Action GameOverEvent;

    public float Money = 0;

    public bool GameOver = false;

    void Start() {
        PatientManager.Instance.PatientDied += PatientDied;
        PatientManager.Instance.PatientRecovered += PatientRecovered;
        TimeManager.Instance.HourTickEvent += OnHourTick;
    }

    void Update() {
        if (Money < 0 && !GameOver) {
            GameOverEvent?.Invoke();
            GameOver = true;
        }    
    }

    void OnHourTick() {
        foreach (Employee emp in EmployeeManager.Instance.Employees) {
            Money -= emp.Salary;
        }
    }

    void PatientDied(Patient patient) {
        Money -= patientDiedCost;
    }

    void PatientRecovered(Patient patient) {
        Money += patientRecoveredPay;
    }
}
