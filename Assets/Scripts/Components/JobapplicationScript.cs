using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class JobapplicationScript : MonoBehaviour {
    [Header("References")]
    [SerializeField] TextMeshProUGUI mailName;
    [SerializeField] TextMeshProUGUI time;

    Jobapplication jobapplicationData;

    public void SetJobapplicationData(Jobapplication jobapplicationData) {
        this.jobapplicationData = jobapplicationData;
        mailName.text = jobapplicationData.EmployeeData.FirstName + " " + jobapplicationData.EmployeeData.LastName;

        string t = "";
        for (int i = 0; i < 4; i++) {
            t += TimeManager.DigitalTime[i];
            if (i == 1) {
                t += ":";
            }
        }
        time.text = "Time Recieved: " + t;
    }

    public void ShowJobApplication() {
        JobapplicationsManager.Instance.SelectJobApplication(jobapplicationData, gameObject);
    }
}
