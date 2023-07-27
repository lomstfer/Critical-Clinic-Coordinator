using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyProgramUI : MonoBehaviour {
    [SerializeField] TextMeshProUGUI moneyText;

    RectTransform _rt;

    void Awake() {
        _rt = GetComponent<RectTransform>();    
    }

    void Update() {
        moneyText.text = MoneyManager.Instance.Money.ToString("0");
         _rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Mathf.Clamp(moneyText.textBounds.size.x + 30, 100, moneyText.textBounds.size.x + 30));
    }
}
