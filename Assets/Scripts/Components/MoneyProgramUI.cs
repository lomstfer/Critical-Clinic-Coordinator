using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class MoneyProgramUI : MonoBehaviour {
    [SerializeField] TextMeshProUGUI moneyText;
    [SerializeField] Transform screen;
    [SerializeField] Transform cursor;

    RectTransform _rt;

    void Awake() {
        _rt = GetComponent<RectTransform>();   
    }

    void Start() {
        CursorInfo.PickedUpMoneyEvent += PickUp;
        CursorInfo.DroppedMoneyEvent += Drop;
    }

    void Update() {
        string s = Mathf.Clamp(Mathf.Abs(MoneyManager.Instance.Money), 0, 999999999).ToString();
        for (int i = s.Length; i < 9; i++) {
            s = s.Insert(0, "0");
        }
        s = s.Insert(3, ",");
        s = s.Insert(7, ",");
        if (MoneyManager.Instance.Money < 0) {
            s = s.Insert(0, "-");
        }
        else {
            s = s.Insert(0, "+");
        }
        moneyText.text = s;
    }

    void PickUp() {
        transform.parent = cursor;
        transform.SetAsFirstSibling();
    }
    void Drop() {
        transform.parent = screen;
        transform.SetAsFirstSibling();
    }

    public void StartDrag() {
        CursorInfo.MoneyDragStart();
    }
    
    public void EndDrag() {
        CursorInfo.MoneyDragEnd();
    }
}
