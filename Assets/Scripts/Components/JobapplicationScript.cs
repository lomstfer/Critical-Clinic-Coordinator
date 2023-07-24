using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class JobapplicationScript : MonoBehaviour {
    [Header("References")]
    [SerializeField] TextMeshProUGUI mailName;

    Jobapplication jobapplicationData;

    public void SetJobapplicationData(Jobapplication jobapplicationData) {
        this.jobapplicationData = jobapplicationData;
        mailName.text = jobapplicationData.EmployeeData.FirstName + " " + jobapplicationData.EmployeeData.LastName;
    }

    public void ShowJobApplication() {
        JobapplicationsManager.Instance.SelectJobApplication(jobapplicationData);
    }
}
