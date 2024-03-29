using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : Singleton<TimeManager> {
    public int ElapsedTime = 0;
    public int[] DigitalTime = new int[4];

    public float TimeSpeed = 60;

    public event Action MinuteTickEvent;
    public event Action HourTickEvent;

    void Start() {
        StartCoroutine(TimeCounter());
    }

    IEnumerator TimeCounter() {
        while (true) {
            yield return new WaitForSeconds(60 / TimeSpeed);
            ElapsedTime++;

            if (ElapsedTime > SavedData.Data.Highscore) {
                SavedData.Data.Highscore = ElapsedTime;
            }

            UpdateDigitalTime();
            MinuteTickEvent?.Invoke();
            if (ElapsedTime % 60 == 0) {
                HourTickEvent?.Invoke();
            }
        }
    }

    void UpdateDigitalTime() {
        DigitalTime[3]++;
        if (DigitalTime[3] >= 10) {
            DigitalTime[2]++;
            DigitalTime[3] = 0;
        }
        if (DigitalTime[2] >= 6) {
            DigitalTime[1]++;
            DigitalTime[2] = 0;
        }
        if (DigitalTime[1] >= 10) {
            DigitalTime[0]++;
            DigitalTime[1] = 0;
        }
        if (DigitalTime[1] >= 4 && DigitalTime[0] >= 2) {
            DigitalTime[1] = 0;
            DigitalTime[0] = 0;
        }
    }
}