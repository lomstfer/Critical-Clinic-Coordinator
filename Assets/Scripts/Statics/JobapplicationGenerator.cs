using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class JobapplicationGenerator {
    public static Jobapplication GenerateNewJobapplication() {
        Jobapplication jobapplication = new Jobapplication();
        Employee jobapplicationEmployee = new Employee();

        jobapplicationEmployee.IsMale = UnityEngine.Random.Range(0, 2) == 0;
        jobapplicationEmployee.FirstName = jobapplicationEmployee.IsMale ? NameGenerator.GetRandomMaleName() : NameGenerator.GetRandomFemaleName();
        jobapplicationEmployee.LastName = NameGenerator.GetRandomLastName();

        // Profession
        Array professionValues = Enum.GetValues(typeof(Profession));
        jobapplicationEmployee.Profession = (Profession)professionValues.GetValue(UnityEngine.Random.Range(0, professionValues.Length));
        //

        // Skills
        Array skillsValues = Enum.GetValues(typeof(Skill));
        int amountOfSkills = UnityEngine.Random.Range(1, skillsValues.Length);
        List<Skill> tempSkills = new();
        for (int i = 0; i < amountOfSkills; i++) {
            Skill skill = (Skill)skillsValues.GetValue(UnityEngine.Random.Range(0, skillsValues.Length));

            bool alreadyHadSkill = false;
            for (int j = 0; j < tempSkills.Count; j++) {
                if (tempSkills[j] == skill) {
                    alreadyHadSkill = true;
                    break;
                }
            }

            if (!alreadyHadSkill) {
                tempSkills.Add(skill);
            }
        }
        //
        
        jobapplicationEmployee.Skills = tempSkills.ToArray();

        jobapplication.EmployeeData = jobapplicationEmployee;

        jobapplication.Subject = "Please hire me";
        jobapplication.Introduction = "Hello! My name is " + jobapplicationEmployee.FirstName + "!";

        return jobapplication;
    }

}

