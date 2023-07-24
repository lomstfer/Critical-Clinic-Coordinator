using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ScreenManager : MonoBehaviour {
    void Start() {
        Cursor.visible = false;
    }

    void Update() {
        Mouse.current.WarpCursorPosition(CursorInfo.Position);
    }
}