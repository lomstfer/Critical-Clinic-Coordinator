using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EmployeeContractManager : MonoBehaviour {
    [SerializeField] Transform contract;
    [SerializeField] EmployeeContract contractForm;

    bool contractVisible = false;

    Vector3 lerpTo;

    bool ok;

    void Start() {
        contract.transform.localPosition = new(contract.transform.localPosition.x, -1, contract.transform.localPosition.z);
        lerpTo = contract.transform.localPosition;
    }

    void Update() {
        if (contractVisible)
            contract.transform.localPosition = Vector3.Lerp(contract.transform.localPosition, lerpTo, Time.unscaledDeltaTime * 10f);
        else
            contract.transform.localPosition = Vector3.Lerp(contract.transform.localPosition, lerpTo, Time.unscaledDeltaTime * 4f);

        if (Input.GetKeyDown(KeyCode.Escape) || ok) {
            contractVisible = !contractVisible;
            ok = false;

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

    public void Ok() {
        ok = true;
    }

    public void Resign() {
        SceneManager.LoadScene("Menu");
    }

    void OnApplicationQuit() {
        SavedData.SaveData();
    }
}
