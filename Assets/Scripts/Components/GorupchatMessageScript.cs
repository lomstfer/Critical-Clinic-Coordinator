using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GorupchatMessageScript : MonoBehaviour {
    [SerializeField] TextMeshProUGUI nameT;
    [SerializeField] TextMeshProUGUI message;
    [SerializeField] TextMeshProUGUI time;


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
        nameT.color = messageData.Sender.ColorId;
        string t = "";
        for (int i = 0; i < 4; i++) {
            t += TimeManager.DigitalTime[i].ToString();
            if (i == 1) {
                t += ":";
            }
        }
        time.text = t;
    }
}
