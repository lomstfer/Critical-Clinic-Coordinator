using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

public class EmployeeContractManager : MonoBehaviour {
    [SerializeField] Transform contract;
    [SerializeField] EmployeeContract contractForm;

    bool contractVisible = false;

    Vector3 lerpTo;

    void Start() {
        contract.transform.localPosition = new(contract.transform.localPosition.x, -1, contract.transform.localPosition.z);
        lerpTo = contract.transform.localPosition;
    }

    void Update() {
        contract.transform.localPosition = Vector3.Lerp(contract.transform.localPosition, lerpTo, Time.unscaledDeltaTime * 10f);

        if (Input.GetKeyDown(KeyCode.Escape)) {
            contractVisible = !contractVisible;

            if (contractVisible) {
                contractForm.SetData();
                lerpTo = new Vector3(contract.transform.localPosition.x, 0, contract.transform.localPosition.z);
                ScreenManager.Instance.SetCursorState(CursorState.Free);
            } 
            else {
                lerpTo = new(contract.transform.localPosition.x, -1, contract.transform.localPosition.z);
                ScreenManager.Instance.SetCursorState(CursorState.Screen);
            }
        }
    }

    void OnApplicationQuit() {
        SavedData.SaveData();
    }
}
