using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils {
    public static string GetSkillsAsString(Skill[] skills) {
        string output = "";
        for (int i = 0; i < skills.Length; i++) {
            if (i > 0 && i < skills.Length) {
                output += ", ";
            }
            output += skills[i].ToString();
        }
        return output;
    }

    public static string TextFromHealthyness(float healthyness) {
        string t = "";
        if (healthyness > 0) {
            t = "AWFUL";
            if (healthyness > 20) {
                t = "BAD";
                if (healthyness > 40) {
                    t = "PRETTY BAD";
                    if (healthyness > 60) {
                        t = "NOT GOOD";
                        if (healthyness > 80) {
                            t = "OK";
                        }
                    }
                }
            }
        }
        return t;
    }

    public static Color ColorFromHealthyness(float healthyness) {
        Color c = Color.yellow;
        if (healthyness > 0) {
            c = new(1, 0.35f, 0.35f);
            if (healthyness > 20) {
                c = Color.yellow;
                if (healthyness > 40) {
                    c = Color.yellow;
                    if (healthyness > 60) {
                        c = Color.yellow;
                        if (healthyness > 80) {
                            c = Color.green;
                        }
                    }
                }
            }
        }
        return c;
    }

    public static string AddColor(this string text, Color col) => $"<color={ColorHexFromUnityColor(col)}>{text}</color>";
    public static string ColorHexFromUnityColor(this Color unityColor) => $"#{ColorUtility.ToHtmlStringRGBA(unityColor)}";

}
