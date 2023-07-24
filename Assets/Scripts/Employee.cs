using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Employee {
    public string FirstName;
    public string LastName;
    public Profession Profession;
    public Skill[] Skills;
}