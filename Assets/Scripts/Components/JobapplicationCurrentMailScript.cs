using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class JobapplicationCurrentMailScript : MonoBehaviour {
    [SerializeField] TextMeshProUGUI subject;
    [SerializeField] TextMeshProUGUI introduction;
    [SerializeField] TextMeshProUGUI employeeInfo;

    [SerializeField] TextMeshProUGUI employeeInfoHeader;

    void Start() {
        JobapplicationsManager.Instance.SelectJobApplicationEvent += OnSelectJobApplicationEvent;    
    }

    public void OnSelectJobApplicationEvent(Jobapplication jobapplication) {
        employeeInfoHeader.text = "Employee info";

        subject.text = jobapplication.Subject;
        introduction.text = jobapplication.Introduction;

        employeeInfo.text = "";
        employeeInfo.text += "\t* ";
        for (int i = 0; i < jobapplication.EmployeeData.Skills.Length; i++) {
            if (i > 0 && i < jobapplication.EmployeeData.Skills.Length) {
                employeeInfo.text += ", ";
            }
            employeeInfo.text += jobapplication.EmployeeData.Skills[i].ToString();
        }

        FaceGenerator.Instance.ApplyFaceId(jobapplication.EmployeeData.FaceId);
    }

    public void AcceptJobApplication() {
        JobapplicationsManager.Instance.AcceptSelectedJobApplication();
    }
}
