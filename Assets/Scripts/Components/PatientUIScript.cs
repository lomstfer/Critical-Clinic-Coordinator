using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class PatientUIScript : MonoBehaviour {
    [SerializeField] TextMeshProUGUI nameT;
    [SerializeField] TextMeshProUGUI syndromes;
    [SerializeField] TextMeshProUGUI health;
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
}
