using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class JobapplicationsManager : Singleton<JobapplicationsManager> {
    [Header("References")]
    [SerializeField] GameObject mailPrefab;
    [SerializeField] Transform mailListContent;
    [SerializeField] GameObject blockingTempContent;

    public Color SelectedJobApplicationColor;

    [Header("Data")]
    [SerializeField] float newJobapplicationTime = 10;
    [SerializeField] float timeRandomness = 0f;

    public event Action<Jobapplication> SelectJobApplicationEvent;
    public event Action<Jobapplication> NewJobApplication;

    [NonSerialized] public Jobapplication SelectedJobapplication = null;

    Dictionary<Jobapplication, GameObject> _jobapplications = new();

    void Start() {
        StartCoroutine(AddJobapplicationTimer());
    }

    void Update() {
        bool hasSelectedApplication = SelectedJobapplication != null;
        blockingTempContent.SetActive(!hasSelectedApplication);
    }

    IEnumerator AddJobapplicationTimer() {
        while (true) {
            float time = UnityEngine.Random.Range(newJobapplicationTime - timeRandomness, newJobapplicationTime + timeRandomness);
            yield return new WaitForSeconds(time);
            AddNewJobapplication();
        }
    }

    void AddNewJobapplication() {
        Jobapplication jobapplicationData = JobapplicationGenerator.GenerateNewJobapplication();
        GameObject mail = Instantiate(mailPrefab, mailListContent);
        mail.GetComponent<JobapplicationScript>().SetJobapplicationData(jobapplicationData);
        _jobapplications.Add(jobapplicationData, mail);
        NewJobApplication?.Invoke(jobapplicationData);
    }

    public void SelectJobApplication(Jobapplication jobapplication, GameObject gameObject) {
        SelectJobApplicationEvent?.Invoke(jobapplication);
        SelectedJobapplication = jobapplication;
    }

    public void AcceptSelectedJobApplication() {
        if (SelectedJobapplication != null) {
            EmployeeManager.Instance.AddEmployee(SelectedJobapplication.EmployeeData);
            Destroy(_jobapplications[SelectedJobapplication]);
            SelectedJobapplication = null;
        }
    }
}
