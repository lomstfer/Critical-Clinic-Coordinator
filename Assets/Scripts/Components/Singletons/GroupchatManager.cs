using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GroupchatManager : Singleton<GroupchatManager> {
    [SerializeField] GameObject groupchatMessagePrefab;
    [SerializeField] Transform groupchatListContent;
    [SerializeField, TextArea(7, 20)] string BossStartMessage;
    [SerializeField] float BossStartMessageDelay;

    Dictionary<GameObject, GroupchatMessage> _groupchatMessages = new();

    public event Action AddedGroupchatMessage;

    void Start() {
        StartCoroutine(SendBossStartMessage());
    }

    IEnumerator SendBossStartMessage() {
        yield return new WaitForSeconds(BossStartMessageDelay);
        AddMessage(new GroupchatMessage
        {
            Sender = new Employee { FirstName = "THE ", LastName = "BOSS", FaceId = null, Skills = null, ColorId = ColorGenerator.Instance.BossColor },
            Message = BossStartMessage,
        });

    }

    public void AddMessage(GroupchatMessage messageData) {
        GameObject message = Instantiate(groupchatMessagePrefab, groupchatListContent);
        message.GetComponent<GorupchatMessageScript>().SetMessageData(messageData);
        _groupchatMessages.Add(message, messageData);

        AddedGroupchatMessage?.Invoke();

        ComputerSpeaker.Instance.PlaySound(ComputerSpeaker.Sound.NewGroupchatMessage);
    }
}
