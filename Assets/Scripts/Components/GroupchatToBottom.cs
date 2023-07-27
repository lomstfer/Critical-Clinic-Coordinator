using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GroupchatScrollToBottom : MonoBehaviour {
    [SerializeField] ScrollRect scrollRect;

    void Start () {
        GroupchatManager.Instance.AddedGroupchatMessage += ScrollDown;
    }

    void Update() {
        
    }

    void ScrollDown() {
        StartCoroutine(ScrollDownS());
    }

    IEnumerator ScrollDownS() {
        bool free = scrollRect.verticalNormalizedPosition > 0.1;
        yield return null;
        yield return null;
        yield return null;
        if (!free)
            scrollRect.verticalNormalizedPosition = 0;
    }
}
