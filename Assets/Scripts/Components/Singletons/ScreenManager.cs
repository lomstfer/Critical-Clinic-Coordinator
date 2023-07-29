using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ScreenManager : Singleton<ScreenManager> {
    [SerializeField] CursorState startState;
    bool freeMove;

    void Start() {
        SetCursorState(startState);
    }

    void Update() {
        if (!freeMove) {
            Mouse.current.WarpCursorPosition(CursorInfo.ScreenPosition);
        }
    }

    public void SetCursorState(CursorState state) {
        if (state == CursorState.Screen) {
            freeMove = false;
            Cursor.visible = false;
            CursorInfo.CanMove = true;
            Time.timeScale = 1;
        }
        else {
            freeMove = true;
            Cursor.visible = true;
            Vector3 middle = new Vector3(Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2);
            Mouse.current.WarpCursorPosition(middle);
            CursorInfo.CanMove = false;
            Time.timeScale = 0;
        }
    }
}

public enum CursorState {
    Screen,
    Free
}