using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class PatientUIScript : MonoBehaviour {
    [SerializeField] TextMeshProUGUI nameT;
    [SerializeField] TextMeshProUGUI syndromes;
    [SerializeField] TextMeshProUGUI health;
    [SerializeField] Image statusIcon;
    [SerializeField] Sprite arrowUp;
    [SerializeField] Sprite doubleUp;
    [SerializeField] Sprite arrowDown;
    [SerializeField] Sprite doubleDown;
    [SerializeField] Sprite line;
    //[SerializeField] TextMeshProUGUI assignedEmployees;

    Patient _patient;
    Employee _employee;

    public void SetData(Patient patientData, Employee employeeData) {
        nameT.text = patientData.FirstName + " " + patientData.LastName;

        //syndromes.text = Utils.GetSkillsAsString(patientData.Syndromes);

        Skill[] syndromesLeft = patientData.GetSyndromesLeftToHeal();

        syndromes.text = "";

        for (int i = 0; i < patientData.Syndromes.Length; i++) {
            if (i > 0 && i < patientData.Syndromes.Length) {
                syndromes.text += ", ";
            }

            Skill s = patientData.Syndromes[i];
            bool stillToHeal = syndromesLeft.Contains(s);
            if (stillToHeal) {
                syndromes.text += $"{s.ToString().AddColor(new(1, 0.35f, 0.35f))}";
            } else {
                syndromes.text += $"{s.ToString().AddColor(Color.green)}";
            }
        }

        health.text = Utils.TextFromHealthyness(patientData.Healthyness);
        health.color = Utils.ColorFromHealthyness(patientData.Healthyness);

        _patient = patientData;
        _employee = employeeData;
    }

    public void Assign() {
        PatientManager.Instance.AssignEmployeeToPatient(_patient, _employee);
    }

    public void Remove() {
        PatientManager.Instance.RemoveEmployeeFromPatient(_patient, _employee);
    }

    public void ChangeStatus(PatientHealthChangeStatus status) {
        switch (status) {
            case (PatientHealthChangeStatus.Positive):
                statusIcon.sprite = arrowUp;
                break;
            case (PatientHealthChangeStatus.DoublePositive):
                statusIcon.sprite = doubleUp;
                break;
            case (PatientHealthChangeStatus.Negative):
                statusIcon.sprite = arrowDown;
                break;
            case (PatientHealthChangeStatus.DoubleNegative):
                statusIcon.sprite = doubleDown;
                break;
            case (PatientHealthChangeStatus.NoChange):
                statusIcon.sprite = line;
                break;
        }
    }
}

public enum PatientHealthChangeStatus {
    Positive,
    DoublePositive,
    Negative,
    DoubleNegative,
    NoChange
}