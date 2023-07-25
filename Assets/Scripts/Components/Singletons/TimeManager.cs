using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : Singleton<TimeManager> {
    public static int ElapsedTime { get; private set; }
    public static int[] DigitalTime { get; private set; }

    public event Action MinuteTickEvent;

    void Start() {
        DigitalTime = new int[4];
        StartCoroutine(TimeCounter());
    }

    IEnumerator TimeCounter() {
        while (true) {
            yield return new WaitForSeconds(60 / Settings.timeSpeed);
            ElapsedTime++;
            UpdateDigitalTime();
            print(ElapsedTime);
            MinuteTickEvent?.Invoke();
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