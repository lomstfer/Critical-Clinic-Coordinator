using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ScreenRenderer : MonoBehaviour {
    [SerializeField] RenderTexture rt;

    [SerializeField] Material scrn1Mat;
    [SerializeField] Material scrn2Mat; 

    void Update() {
        RenderTexture.active = rt;
        Texture2D left = new Texture2D(rt.width / 2, rt.height);
        Rect rect = new Rect(0, 0, rt.width / 2, rt.height);
        left.ReadPixels(rect, 0, 0);
        left.Apply();
        scrn1Mat.mainTexture = left;

        Texture2D right = new Texture2D(rt.width / 2, rt.height);
        rect = new Rect(rt.width / 2, 0, rt.width, rt.height);
        right.ReadPixels(rect, 0, 0);
        right.Apply();
        scrn2Mat.mainTexture = right;
    }
}