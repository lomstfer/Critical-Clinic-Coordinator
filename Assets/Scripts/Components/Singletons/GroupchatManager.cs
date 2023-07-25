using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupchatManager : Singleton<GroupchatManager> {
    [SerializeField] GameObject groupchatMessagePrefab;
    [SerializeField] Transform groupchatListContent;

    Dictionary<GameObject, GroupchatMessage> _groupchatMessages = new();

    public void AddMessage(GroupchatMessage messageData) {
        GameObject message = Instantiate(groupchatMessagePrefab, groupchatListContent);
        message.GetComponent<GorupchatMessageScript>().SetMessageData(messageData);
        _groupchatMessages.Add(message, messageData);
    }
}
