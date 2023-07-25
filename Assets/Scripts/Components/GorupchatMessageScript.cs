using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GorupchatMessageScript : MonoBehaviour {
    [SerializeField] TextMeshProUGUI messageText;

    public void SetMessageData(GroupchatMessage messageData) {
        messageText.text = messageData.Message;
    }
}
