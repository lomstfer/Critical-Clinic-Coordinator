using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JobapplicationsManager : Singleton<JobapplicationsManager> {
    [Header("References")]
    [SerializeField] GameObject mailPrefab;
    [SerializeField] Transform mailListContent;

    [Header("Data")]
    [SerializeField] float newJobapplicationTime = 10;
    [SerializeField] float timeRandomness = 0f;

    public event Action<Jobapplication> SelectJobApplicationEvent;

    List<Jobapplication> _jobapplications = new();

    void Start() {
        StartCoroutine(AddJobapplicationTimer());
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
        _jobapplications.Add(jobapplicationData);
    }

    public void SelectJobApplication(Jobapplication jobapplication) {
        SelectJobApplicationEvent?.Invoke(jobapplication);
    }
}
