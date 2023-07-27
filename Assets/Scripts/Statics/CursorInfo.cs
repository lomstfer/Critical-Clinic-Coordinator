using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CursorInfo {
    public static Vector3 WorldPosition;
    public static Vector2 ScreenPosition;
    public static int Monitor;
    public static event Action PickedUpMoneyEvent;
    public static event Action DroppedMoneyEvent;
    
    public static void MoneyDragStart() {
        PickedUpMoneyEvent?.Invoke();
    }
    
    public static void MoneyDragEnd() {
        DroppedMoneyEvent?.Invoke();
    }
}