using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PatientManager : Singleton<PatientManager> {
    [SerializeField] float spawnNewPatientTime;
    [SerializeField] float spawnNewPatientRandomnessTime;

    public List<Patient> Patients = new();

    public event Action<Patient> NewPatient;
    public event Action<Patient> RemovePatient;

    List<Patient> _patientsToRemove = new();

    public void AssignEmployeeToPatient(Patient patient, Employee employee) {
        // check if already has a patient
        if (employee.AssignedPatient != null) {
            if (patient == employee.AssignedPatient) {
                GroupchatManager.Instance.AddMessage(new GroupchatMessage
                {
                    Sender = employee,
                    Message = "I'm already helping " + patient.FirstName + " " + patient.LastName + "!"
                });
                return;
            }
            GroupchatManager.Instance.AddMessage(new GroupchatMessage
            {
                Sender = employee,
                Message = "I'm busy! I can't help " + patient.FirstName + " " + patient.LastName + " as well as " + employee.AssignedPatient.FirstName + " " + employee.AssignedPatient.LastName + ". You should know that @Player!."
            });
            return;
        }


        bool canHelp = patient.CanGetHelpBy(employee);

        if (!canHelp) {
            GroupchatManager.Instance.AddMessage(new GroupchatMessage
            {
                Sender = employee,
                Message = "I don't know how to help the patient named " + patient.FirstName + " " + patient.LastName + ". I'm sorry."
            });
            return;
        }


        employee.AssignedPatient = patient;

        patient.ResponsibleEmployees.Add(employee);

        GroupchatManager.Instance.AddMessage(new GroupchatMessage
        {
            Sender = employee,
            Message = "I'll be right there, " + patient.FirstName + " " + patient.LastName + "!"
        });


        string infoMessage = "";

        //if (patient.SyndromeExtremeness > patient.ResponsibleEmployees.Count) {
        //    infoMessage += "More people to " + patient.FirstName + " " + patient.LastName + "!";
        //}

        Skill[] syndromesLeft = patient.GetSyndromesLeftToHeal();
        if (syndromesLeft.Length > 0) {
            infoMessage += "To heal " + patient.FirstName + " " + patient.LastName + " I'll need some help with " + Utils.GetSkillsAsString(syndromesLeft);
        }

        if (infoMessage.Length == 0) 
            return;

        GroupchatManager.Instance.AddMessage(new GroupchatMessage
        {
            Sender = employee,
            Message = infoMessage
        });
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
            yield return new WaitForSeconds(UnityEngine.Random.Range(spawnNewPatientTime -  spawnNewPatientRandomnessTime, spawnNewPatientTime + spawnNewPatientRandomnessTime));
            SpawnPatient();
        }
    }

    void SpawnPatient() {
        Patient p = PatientGenerator.GenerateNewPatient();
        Patients.Add(p);
        NewPatient?.Invoke(p);
        GroupchatManager.Instance.AddMessage(new GroupchatMessage
        {
            Sender = new Employee { FirstName = "Ambulance", LastName = "", FaceId = null, Skills = null },
            Message = "New patient!\nName: " + p.FirstName + " " + p.LastName + "\nSyndrome: " + Utils.GetSkillsAsString(p.Syndromes)
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
            GroupchatManager.Instance.AddMessage(new GroupchatMessage
            {
                Sender = new Employee { FirstName = "THE ", LastName = "BOSS", FaceId = null, Skills = null},
                Message = "I'm sorry to inform you that we were unable to save " + patient.FirstName + " " + patient.LastName + ". @Player, you better start hiring more competent people!" ,
            });
            _patientsToRemove.Add(patient);
            return;
        }

        if (patient.GetSyndromesLeftToHeal().Length == 0) {
            patient.Healthyness += 2;
        }

        if (patient.Healthyness >= 100) {
            RemovePatient?.Invoke(patient);
            GroupchatManager.Instance.AddMessage(new GroupchatMessage
            {
                Sender = new Employee { FirstName = "THE ", LastName = "BOSS", FaceId = null, Skills = null },
                Message = "I'm happy to announce that " + patient.FirstName + " " + patient.LastName + " is now fully healed! Good work team!",
            });
            foreach (Employee emp in patient.ResponsibleEmployees) {
                emp.AssignedPatient = null;
            }
            _patientsToRemove.Add(patient);
        }
    }
}