using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ColorGenerator : Singleton<ColorGenerator> {
    [SerializeField] Color[] colors;

    public Color GetColor() {
        List<Color> remainingColors = colors.ToList();
        foreach (Employee emp in EmployeeManager.Instance.Employees) {
            remainingColors.Remove(emp.ColorId);
        }
        if (remainingColors.Count == 0) {
            return colors[Random.Range(0, colors.Length)];
        }
        else {
            return remainingColors[Random.Range(0, colors.Length)];
        }
    }
}