using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorMovement : MonoBehaviour {
    [SerializeField] ScreenPosition screenPosition;
    [SerializeField] RectTransform cursor;

    RectTransform screenRect;

    void Awake() {
        screenRect = GetComponent<RectTransform>();
    }

    void Update() {
        if (!CursorInfo.CanMove) {
            return;
        }
        float h = Input.GetAxis("Mouse X");
        float v = Input.GetAxis("Mouse Y");
        Vector2 delta = new Vector2(h, v) * SavedData.Data.CursorSensititvity;

        cursor.localPosition += (Vector3)delta;
        cursor.localPosition = new Vector3(
            Mathf.Clamp(cursor.localPosition.x, -screenRect.rect.width / 2, screenRect.rect.width / 2),
            Mathf.Clamp(cursor.localPosition.y, -screenRect.rect.height / 2, screenRect.rect.height / 2)
        );

        Vector2 screenPos = Camera.main.WorldToScreenPoint(cursor.position);
        if (screenPosition == ScreenPosition.Left && cursor.localPosition.x <= 0) {
            CursorInfo.WorldPosition = cursor.position;
            CursorInfo.ScreenPosition = screenPos;
            CursorInfo.Monitor = 0;
        } 
        else if (screenPosition == ScreenPosition.Right && cursor.localPosition.x > 0) {
            CursorInfo.WorldPosition = cursor.position;
            CursorInfo.ScreenPosition = screenPos;
            CursorInfo.Monitor = 1;
        }
    }

    enum ScreenPosition {
        Left,
        Right
    }
}