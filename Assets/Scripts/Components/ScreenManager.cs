using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ScreenManager : Singleton<ScreenManager> {
    bool freeMove;

    void Update() {
        if (!freeMove) {
            Mouse.current.WarpCursorPosition(CursorInfo.ScreenPosition);
        }
    }

    public void SwitchCursorState() {
        Cursor.visible = !Cursor.visible;
        freeMove = !freeMove;
    }
}