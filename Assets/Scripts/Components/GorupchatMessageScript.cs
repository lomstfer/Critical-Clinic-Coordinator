using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GorupchatMessageScript : MonoBehaviour {
    [SerializeField] TextMeshProUGUI message;
    [SerializeField] TextMeshProUGUI nameT;

    public void SetMessageData(GroupchatMessage messageData) {
        message.text = messageData.Message;
        nameT.text = messageData.Sender.FirstName + " " + messageData.Sender.LastName;
    }
}
