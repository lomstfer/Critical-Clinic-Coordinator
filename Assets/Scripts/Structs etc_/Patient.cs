using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Patient {
    public string FirstName;
    public string LastName;

    public Skill[] Syndromes;

    // The amount of ResponsibleEmployees that are necessary to heal;
    //public int SyndromeExtremeness;
    
    public List<Employee> ResponsibleEmployees = new();

    // 100 is healthy, 0 is dead.
    // Ticking down by the minute by 1 and up by 2 if ResponsibleEmployees.Count is >= SyndromeExtremeness;
    public int Healthyness;

    public Skill[] GetSyndromesLeftToHeal() {
        List<Skill> syndromesLeft = Syndromes.ToList();

        foreach (Employee emp in ResponsibleEmployees) {
            for (int i = 0; i < syndromesLeft.Count; i++) {
                for (int j = 0; j < emp.Skills.Length; j++) {
                    if (syndromesLeft[i] == emp.Skills[j]) {
                        syndromesLeft.Remove(syndromesLeft[i]);
                        i--;
                        break;
                    }
                }
            }
        }

        return syndromesLeft.ToArray();
    }

    public bool CanGetHelpBy(Employee employee) {
        for (int i = 0; i < Syndromes.Length; i++) {
            for (int j = 0; j < employee.Skills.Length; j++) {
                if (Syndromes[i] == employee.Skills[j]) {
                    return true;
                }
            }
        }
        return false;
    }
}
