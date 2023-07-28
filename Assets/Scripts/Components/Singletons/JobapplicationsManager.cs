using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JobapplicationsManager : Singleton<JobapplicationsManager> {
    [Header("References")]
    [SerializeField] GameObject mailPrefab;
    [SerializeField] Transform mailListContent;
    [SerializeField] GameObject blockingTempContent;

    [Header("Data")]
    [SerializeField] float newJobapplicationTime = 10;
    [SerializeField] float timeRandomness = 0f;

    public event Action<Jobapplication> SelectJobApplicationEvent;
    public event Action<Jobapplication> NewJobApplication;

    Dictionary<Jobapplication, GameObject> _jobapplications = new();

    Jobapplication _selectedJobapplication = null;

    void Start() {
        StartCoroutine(AddJobapplicationTimer());
    }

    void Update() {    
        blockingTempContent.SetActive(_selectedJobapplication == null);
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
        _selectedJobapplication = jobapplication;
    }

    public void AcceptSelectedJobApplication() {
        if (_selectedJobapplication != null) {
            EmployeeManager.Instance.AddEmployee(_selectedJobapplication.EmployeeData);
            Destroy(_jobapplications[_selectedJobapplication]);
            _selectedJobapplication = null;
        }
    }
}
