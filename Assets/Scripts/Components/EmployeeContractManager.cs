using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

public class EmployeeContractManager : MonoBehaviour {
    [SerializeField] EmployeeContract contract;

    bool contractVisible = false;

    void Start() {
        //lerpTo = contract.transform.position;
    }

    void Update() {
        //contract.transform.position = Vector2.Lerp(contract.transform.position, lerpTo, Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Escape)) {
            contractVisible = !contractVisible;

            if (contractVisible) {
                contract.SetData();
                contract.transform.position = new(contract.transform.position.x, 0, contract.transform.position.z);
            } else {
                contract.transform.position = new(contract.transform.position.x, -100, contract.transform.position.z);
            }
        }
    }

    void OnApplicationQuit() {
        SavedData.SaveData();
    }
}
