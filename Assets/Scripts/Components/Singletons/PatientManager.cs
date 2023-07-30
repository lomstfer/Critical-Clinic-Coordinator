using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

public class PatientManager : Singleton<PatientManager> {
    [SerializeField] float spawnNewPatientTime;
    [SerializeField] float spawnNewPatientRandomnessTime;
    [SerializeField] float spawnMorePatientsAmountByTime;
    [SerializeField] float spawnMorePatientsMaximumTimeScale;

    public List<Patient> Patients = new();

    public event Action<Patient> NewPatient;
    public event Action<Patient> RemovePatient;
    public event Action<Patient> PatientDied;
    public event Action<Patient> PatientRecovered;

    List<Patient> _patientsToRemove = new();

    public async void AssignEmployeeToPatient(Patient patient, Employee employee) {
        // check if already has a patient
        //if (employee.AssignedPatient != null) {
        //    if (patient == employee.AssignedPatient) {
        //        GroupchatManager.Instance.AddMessage(new GroupchatMessage
        //        {
        //            Sender = employee,
        //            Message = "I'm already helping " + patient.FirstName + " " + patient.LastName + "!"
        //        });
        //        return;
        //    }
        //    GroupchatManager.Instance.AddMessage(new GroupchatMessage
        //    {
        //        Sender = employee,
        //        Message = "I'm busy! I can't help " + patient.FirstName + " " + patient.LastName + " as well as " + employee.AssignedPatient.FirstName + " " + employee.AssignedPatient.LastName + ". You should know that @Player!."
        //    });
        //    return;
        //}

        int waitTime = UnityEngine.Random.Range(200, 600);


        bool canHelp = patient.CanGetHelpBy(employee);

        if (!canHelp) {
            await Task.Delay(waitTime);
            GroupchatManager.Instance.AddMessage(new GroupchatMessage
            {
                Sender = employee,
                Message = "I don't know how to help the patient named " + patient.FirstName + " " + patient.LastName + ". I'm sorry."
            });
            return;
        }

        // switch patient
        if (employee.AssignedPatient != null) {
            if (patient == employee.AssignedPatient) {
                await Task.Delay(waitTime);
                GroupchatManager.Instance.AddMessage(new GroupchatMessage
                {
                    Sender = employee,
                    Message = "I'm already helping " + patient.FirstName + " " + patient.LastName + "!"
                });
                return;
            }
            employee.AssignedPatient.ResponsibleEmployees.Remove(employee);
            patient.ResponsibleEmployees.Add(employee);
            employee.AssignedPatient = patient;
            await Task.Delay(waitTime);
            GroupchatManager.Instance.AddMessage(new GroupchatMessage
            {
                Sender = employee,
                Message = "I guess I won't be helping " + employee.AssignedPatient.FirstName + " " + employee.AssignedPatient.LastName + " anymore... " + "Here I come " + patient.FirstName + " " + patient.LastName + "!"
            });
            return;
        }


        employee.AssignedPatient = patient;

        patient.ResponsibleEmployees.Add(employee);

        await Task.Delay(waitTime);
        GroupchatManager.Instance.AddMessage(new GroupchatMessage
        {
            Sender = employee,
            Message = "I'll be right there, " + patient.FirstName + " " + patient.LastName + "!"
        });


        await Task.Delay(waitTime);
        Skill[] syndromesLeft = patient.GetSyndromesLeftToHeal();
        if (syndromesLeft.Length > 0) {
            GroupchatManager.Instance.AddMessage(new GroupchatMessage
            {
                Sender = employee,
                Message = "To heal " + patient.FirstName + " " + patient.LastName + " I'll need some help with " + Utils.GetSkillsAsString(syndromesLeft)
        });
        }

    }

    public void RemoveEmployeeFromPatient(Patient patient, Employee employee) {
        patient.ResponsibleEmployees.Remove(employee);
        employee.AssignedPatient = null;
    }

    void Start() {
        TimeManager.Instance.MinuteTickEvent += OnMinuteTick;
        StartCoroutine(SpawnPatients());
        PatientUIManager.Instance.SubscribeToEvents();
    }

    IEnumerator SpawnPatients() {
        while (true) {
            float random = UnityEngine.Random.Range(spawnNewPatientTime - spawnNewPatientRandomnessTime, spawnNewPatientTime + spawnNewPatientRandomnessTime);
            float timeScale = Mathf.Clamp(TimeManager.ElapsedTime * spawnMorePatientsAmountByTime, 0, spawnMorePatientsMaximumTimeScale);

            yield return new WaitForSeconds(random - timeScale);
            SpawnPatient();
        }
    }

    void SpawnPatient() {
        Patient p = PatientGenerator.GenerateNewPatient();
        Patients.Add(p);
        NewPatient?.Invoke(p);
        GroupchatManager.Instance.AddMessage(new GroupchatMessage
        {
            Sender = new Employee { FirstName = "Ambulance", LastName = "", FaceId = null, Skills = null, ColorId=ColorGenerator.Instance.AmbulanceColor },
            Message = "New patient!\nName: " + p.FirstName + " " + p.LastName + "\nSyndrome" + (p.Syndromes.Length > 1 ? "s" : "") + ": " + Utils.GetSkillsAsString(p.Syndromes) + "\nHealth: " + Utils.TextFromHealthyness(p.Healthyness) + "."
        }) ;
    }

    void OnMinuteTick() {
        foreach (Patient patient in Patients) {
            SetPatientTickValue(patient);
        }

        foreach (Patient patient in _patientsToRemove) {
            Patients.Remove(patient);
        }
       _patientsToRemove.Clear();
    }

    void SetPatientTickValue(Patient patient) {
        patient.Healthyness -= 1;

        if (patient.Healthyness < 0) {
            RemovePatient?.Invoke(patient);
            PatientDied?.Invoke(patient);
            GroupchatManager.Instance.AddMessage(new GroupchatMessage
            {
                Sender = new Employee { FirstName = "THE ", LastName = "BOSS", FaceId = null, Skills = null, ColorId = ColorGenerator.Instance.BossColor },
                Message = "I'm sorry to inform you that we were unable to save " + patient.FirstName + " " + patient.LastName + ". That means we lost " + MoneyManager.Instance.PatientDiedCost.ToString() + "!",
            });
            _patientsToRemove.Add(patient);
            return;
        }

        if (patient.GetSyndromesLeftToHeal().Length == 0) {
            patient.Healthyness += 2;
        }

        if (patient.Healthyness >= 100) {
            RemovePatient?.Invoke(patient);
            PatientRecovered?.Invoke(patient);
            GroupchatManager.Instance.AddMessage(new GroupchatMessage
            {
                Sender = new Employee { FirstName = "THE ", LastName = "BOSS", FaceId = null, Skills = null, ColorId = ColorGenerator.Instance.BossColor },
                Message = "I'm happy to announce that " + patient.FirstName + " " + patient.LastName + " has now fully recovered! +" + MoneyManager.Instance.PatientRecoveredPay.ToString(),
            }) ;
            foreach (Employee emp in patient.ResponsibleEmployees) {
                emp.AssignedPatient = null;
            }
            _patientsToRemove.Add(patient);
        }
    }
}