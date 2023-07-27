using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class JobapplicationCurrentMailScript : MonoBehaviour {
    [SerializeField] Face face;
    [SerializeField] new TextMeshProUGUI name;
    [SerializeField] TextMeshProUGUI skills;
    [SerializeField] TextMeshProUGUI salary;

    void Start() {
        JobapplicationsManager.Instance.SelectJobApplicationEvent += OnSelectJobApplicationEvent;    
    }

    public void OnSelectJobApplicationEvent(Jobapplication jobapplication) {
        name.text = jobapplication.EmployeeData.FirstName + " " + jobapplication.EmployeeData.LastName;

        skills.text = Utils.GetSkillsAsString(jobapplication.EmployeeData.Skills);

        salary.text = jobapplication.EmployeeData.Salary.ToString("0");

        face.ApplyFaceId(jobapplication.EmployeeData.FaceId);
    }

    public void AcceptJobApplication() {
        JobapplicationsManager.Instance.AcceptSelectedJobApplication();
    }
}
