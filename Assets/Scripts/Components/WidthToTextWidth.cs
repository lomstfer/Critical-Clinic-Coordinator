using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WidthToTextWidth : MonoBehaviour {
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] float margin = 10f;

    RectTransform rectTransform;

    void Awake() {
        rectTransform = GetComponent<RectTransform>();
    }

    void Update() {
        rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, text.textBounds.size.x + margin);
    }
}
