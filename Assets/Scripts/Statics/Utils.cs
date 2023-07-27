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

    public static string AddColor(this string text, Color col) => $"<color={ColorHexFromUnityColor(col)}>{text}</color>";
    public static string ColorHexFromUnityColor(this Color unityColor) => $"#{ColorUtility.ToHtmlStringRGBA(unityColor)}";

}
