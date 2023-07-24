using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CursorClick : MonoBehaviour {
    Image image;

    [SerializeField] Sprite defaultSprite;
    [SerializeField] Sprite clickSprite;
    [SerializeField] float clickDuration;

    void Awake() {
        image = GetComponent<Image>();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            StartCoroutine(Click());
        }
    }

    IEnumerator Click() {
        image.sprite = clickSprite;
        yield return new WaitForSeconds(clickDuration);
        image.sprite = defaultSprite;
    }
}
