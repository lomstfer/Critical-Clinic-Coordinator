using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GorupchatMessageScript : MonoBehaviour {
    [SerializeField] TextMeshProUGUI message;
    [SerializeField] TextMeshProUGUI nameT;

    void Start() {
        StartCoroutine(FixBuggyUI());
    }

    IEnumerator FixBuggyUI() {
        Canvas.ForceUpdateCanvases();

        ContentSizeFitter c = GetComponent<ContentSizeFitter>();
        c.enabled = false;
        c.enabled = true;

        yield return null;
        yield return null;
        yield return null;
        yield return null;

        VerticalLayoutGroup v = GetComponentInParent<VerticalLayoutGroup>();
        v.enabled = false;
        v.enabled = true;

    }

    public void SetMessageData(GroupchatMessage messageData) {
        message.text = messageData.Message;
        nameT.text = messageData.Sender.FirstName + " " + messageData.Sender.LastName;
    }
}
