using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
    [SerializeField] Transform[] Monitors;

    [SerializeField] Vector3 offset;
    [SerializeField] float speed;
    [SerializeField] float cursorWeight;
    [SerializeField] float headMovement;

    Vector3 centerPosition;

    void Start() {
        centerPosition = Vector3.Lerp(Monitors[0].position, Monitors[1].position, .5f) + offset;
        transform.position = centerPosition;
    }

    void Update() {
        Transform focusedMonitor = Monitors[CursorInfo.Monitor];

        Vector3 targetPos = Vector3.Lerp(centerPosition, focusedMonitor.position, headMovement);
        transform.position = Vector3.Lerp(transform.position, targetPos, Mathf.Clamp01(speed * Time.deltaTime));

        Quaternion targetRot = Quaternion.LookRotation(Vector3.Lerp(focusedMonitor.position, CursorInfo.WorldPosition, cursorWeight) - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, Mathf.Clamp01(speed * Time.deltaTime));
    }
}