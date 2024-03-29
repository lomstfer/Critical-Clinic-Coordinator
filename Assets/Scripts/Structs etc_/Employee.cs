using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Employee {
    public string FirstName;
    public string LastName;
    public int[] FaceId;
    public Color ColorId;
    public Skill[] Skills;
    public Patient AssignedPatient = null;
    public float Salary;
}