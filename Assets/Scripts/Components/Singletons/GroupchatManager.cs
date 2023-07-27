using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GroupchatManager : Singleton<GroupchatManager> {
    [SerializeField] GameObject groupchatMessagePrefab;
    [SerializeField] Transform groupchatListContent;

    Dictionary<GameObject, GroupchatMessage> _groupchatMessages = new();

    public event Action AddedGroupchatMessage;

    public void AddMessage(GroupchatMessage messageData) {
        GameObject message = Instantiate(groupchatMessagePrefab, groupchatListContent);
        message.GetComponent<GorupchatMessageScript>().SetMessageData(messageData);
        _groupchatMessages.Add(message, messageData);

        AddedGroupchatMessage?.Invoke();
    }
}
