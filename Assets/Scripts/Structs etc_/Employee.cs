using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Employee {
    public string FirstName;
    public string LastName;
    public int[] FaceId;
    public Profession Profession;
    public Skill[] Skills;
}