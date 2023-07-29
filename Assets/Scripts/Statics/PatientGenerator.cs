using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PatientGenerator {
    public static Patient GenerateNewPatient() {
        Patient patient = new();

        bool isMale = UnityEngine.Random.Range(0, 2) == 0;
        patient.FirstName = isMale ? NameGenerator.GetRandomMaleName() : NameGenerator.GetRandomFemaleName();
        patient.LastName = NameGenerator.GetRandomLastName();

        patient.Healthyness = UnityEngine.Random.Range(30, 60);
        //patient.SyndromeExtremeness = UnityEngine.Random.Range(1, 3);

        // Syndromes
        Array syndromesValues = Enum.GetValues(typeof(Skill));
        int amountOfSyndromes = UnityEngine.Random.Range(1, syndromesValues.Length);
        List<Skill> tempSyndromes = new();
        for (int i = 0; i < amountOfSyndromes; i++) {
            Skill syndrome = (Skill)syndromesValues.GetValue(UnityEngine.Random.Range(0, syndromesValues.Length));

            bool alreadyHadSyndrome = false;
            for (int j = 0; j < tempSyndromes.Count; j++) {
                if (tempSyndromes[j] == syndrome) {
                    alreadyHadSyndrome = true;
                    break;
                }
            }

            if (!alreadyHadSyndrome) {
                tempSyndromes.Add(syndrome);
            }
        }

        patient.Syndromes = tempSyndromes.ToArray();
        //


        return patient;
    }

}

