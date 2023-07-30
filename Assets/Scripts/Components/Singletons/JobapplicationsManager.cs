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
    [SerializeField] int maxStartAmount = 6;
    [SerializeField] float newJobapplicationTime = 10;
    [SerializeField] float timeRandomness = 0f;

    public event Action<Jobapplication> SelectJobApplicationEvent;
    public event Action<Jobapplication> NewJobApplication;

    [NonSerialized] public Jobapplication SelectedJobapplication = null;

    Dictionary<Jobapplication, GameObject> _jobapplications = new();

    void Start() {
        int added = 0;
        List<Skill> usedSkills = new();
        while (usedSkills.Count <= Enum.GetValues(typeof(Skill)).Length && added < maxStartAmount) {
            Jobapplication application = JobapplicationGenerator.GenerateNewJobapplication();
            AddNewJobapplication(application);
            foreach (Skill skill in application.EmployeeData.Skills) {
                if (!usedSkills.Contains(skill)) {
                    usedSkills.Add(skill);
                }
            }
            added++;
        }
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
            AddNewJobapplication(JobapplicationGenerator.GenerateNewJobapplication());
        }
    }

    void AddNewJobapplication(Jobapplication application) {
        GameObject mail = Instantiate(mailPrefab, mailListContent);
        mail.GetComponent<JobapplicationScript>().SetJobapplicationData(application);
        _jobapplications.Add(application, mail);
        NewJobApplication?.Invoke(application);
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

    public void Remove(Jobapplication jobapplication) {
        Destroy(_jobapplications[jobapplication]);
        _jobapplications.Remove(jobapplication);
        SelectedJobapplication = null;
    }
}
