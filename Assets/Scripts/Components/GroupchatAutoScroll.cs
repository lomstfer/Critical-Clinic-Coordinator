using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GroupchatAutoScroll : MonoBehaviour {
    [SerializeField] ScrollRect scrollRect;
    [SerializeField] RectTransform content;

    void Start () {
        GroupchatManager.Instance.AddedGroupchatMessage += ScrollDown;
    }

    void Update() {
        
    }

    void ScrollDown() {
        StartCoroutine(ScrollDownS());
    }

    IEnumerator ScrollDownS() {
        float d = content.rect.height - ((1f - scrollRect.verticalNormalizedPosition) * content.rect.height);
        bool autoScroll = d < 10f;

        yield return null;

        if (autoScroll)
            scrollRect.verticalNormalizedPosition = 0;
    }
}
