using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class JobapplicationGenerator {
    static float salaryRandomness = 100f;

    public static Jobapplication GenerateNewJobapplication() {
        Jobapplication jobapplication = new Jobapplication();
        Employee jobapplicationEmployee = new Employee();

        jobapplicationEmployee.FaceId = FaceGenerator.Instance.GenerateNewFaceId();
        jobapplicationEmployee.FirstName = jobapplicationEmployee.FaceId[0] == 0 ? NameGenerator.GetRandomMaleName() : NameGenerator.GetRandomFemaleName();
        jobapplicationEmployee.LastName = NameGenerator.GetRandomLastName();
        jobapplicationEmployee.ColorId = ColorGenerator.Instance.GetColor();

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

        jobapplicationEmployee.Skills = tempSkills.ToArray();

        jobapplicationEmployee.Salary = 300f + jobapplicationEmployee.Skills.Length * 10f + UnityEngine.Random.Range(-salaryRandomness, salaryRandomness);
        

        jobapplication.EmployeeData = jobapplicationEmployee;

        jobapplication.Subject = "Please hire me";
        jobapplication.Introduction = "Hello! My name is " + jobapplicationEmployee.FirstName + "!";

        return jobapplication;
    }

}

