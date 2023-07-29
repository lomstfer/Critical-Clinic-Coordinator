using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using MessagePack;

public static class SavedData {
    public static DataStruct Data;

    static string _fileName = "data";

    public static void LoadData() {
        string path = Application.persistentDataPath + "/" + _fileName;
        if (!File.Exists(path)) {
            File.Create(path);
            SetDefaultData();
            return;
        }
        if (new FileInfo(path).Length == 0) {
            SetDefaultData();
            return;
        }

        byte[] bytes = File.ReadAllBytes(path);
        Data = MessagePackSerializer.Deserialize<DataStruct>(bytes);
    }

    static void SetDefaultData() {
        Data = new DataStruct
        {
            PlayerName = "John Doe",
            CursorSensititvity = 6f,
            Fullscreen = true,
            MusicVolume = 50,
            EffectsVolume = 50,
            Highscore = 0,
        };
    }

    public static void SaveData() {
        string path = Application.persistentDataPath + "/" + _fileName;
        if (!File.Exists(path)) {
            File.Create(path);
        }

        byte[] bytes = MessagePackSerializer.Serialize(Data);
        File.WriteAllBytes(path, bytes);
    }
}

[MessagePackObject]
public struct DataStruct {
    [Key(0)]
    public string PlayerName;
    [Key(1)]
    public float CursorSensititvity;
    [Key(2)]
    public bool Fullscreen;
    [Key(3)]
    public float MusicVolume;
    [Key(4)]
    public float EffectsVolume;

    // not player changeable
    [Key(5)]
    public float Highscore;
}