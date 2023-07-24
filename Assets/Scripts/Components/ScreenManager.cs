using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ScreenManager : MonoBehaviour {
    bool freeMove;

    void Start() {
        Cursor.visible = false;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Cursor.visible = !Cursor.visible;
            freeMove = !freeMove;
        }
        if (!freeMove) {
            Mouse.current.WarpCursorPosition(CursorInfo.ScreenPosition);
        }
    }
}