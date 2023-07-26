using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patient {
    public string FirstName;
    public string LastName;

    public Skill[] Syndromes;

    // The amount of ResponsibleEmployees that are necessary to heal;
    public int SyndromeExtremeness;
    
    public List<Employee> ResponsibleEmployees = new();

    // 100 is healthy, 0 is dead.
    // Ticking down by the minute by 1 and up by 2 if ResponsibleEmployees.Count is >= SyndromeExtremeness;
    public int Healthyness; 
}
