using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class JobapplicationCurrentMailScript : MonoBehaviour {
    [SerializeField] Face face;
    [SerializeField] new TextMeshProUGUI name;
    [SerializeField] TextMeshProUGUI skills;

    void Start() {
        JobapplicationsManager.Instance.SelectJobApplicationEvent += OnSelectJobApplicationEvent;    
    }

    public void OnSelectJobApplicationEvent(Jobapplication jobapplication) {
        name.text = jobapplication.EmployeeData.FirstName + " " + jobapplication.EmployeeData.LastName;

        skills.text = "";
        for (int i = 0; i < jobapplication.EmployeeData.Skills.Length; i++) {
            if (i > 0 && i < jobapplication.EmployeeData.Skills.Length) {
                skills.text += ",\n";
            }
            skills.text += jobapplication.EmployeeData.Skills[i].ToString();
        }

        face.ApplyFaceId(jobapplication.EmployeeData.FaceId);
    }

    public void AcceptJobApplication() {
        JobapplicationsManager.Instance.AcceptSelectedJobApplication();
    }
}
