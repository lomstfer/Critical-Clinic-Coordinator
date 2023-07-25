using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FaceGenerator : Singleton<FaceGenerator> {
    [Header("Male Parts")]
    [SerializeField] Sprite[] maleHeads;
    [SerializeField] Sprite[] maleHairs;
    [SerializeField] Sprite[] maleBrows;
    [SerializeField] Sprite[] maleEyes;
    [SerializeField] Sprite[] maleMouths;

    [Header("Female Parts")]
    [SerializeField] Sprite[] femaleHeads;
    [SerializeField] Sprite[] femaleHairs;
    [SerializeField] Sprite[] femaleBrows;
    [SerializeField] Sprite[] femaleEyes;
    [SerializeField] Sprite[] femaleMouths;

    [Header("Images")]
    [SerializeField] Image head;
    [SerializeField] Image hair;
    [SerializeField] Image brows;
    [SerializeField] Image eyes;
    [SerializeField] Image mouth;

    public int[] GenerateNewFaceId() {
        int[] id = new int[6];
        id[0] = Random.Range(0, 1);
        bool isMale = id[0] == 0 ? true : false;
        id[1] = Random.Range(0, isMale ? maleHeads.Length : femaleHeads.Length);
        id[2] = Random.Range(0, isMale ? maleHairs.Length : femaleHairs.Length);
        id[3] = Random.Range(0, isMale ? maleBrows.Length : femaleBrows.Length);
        id[4] = Random.Range(0, isMale ? maleEyes.Length : femaleEyes.Length);
        id[5] = Random.Range(0, isMale ? maleMouths.Length : femaleMouths.Length);
        return id;
    }

    public void ApplyFaceId(int[] id) {
        print("Id Applied");
        bool isMale = id[0] == 0 ? true : false;
        head.sprite = isMale ? maleHeads[id[1]] : femaleHeads[id[1]];
        hair.sprite = isMale ? maleHairs[id[2]] : femaleHairs[id[2]];
        brows.sprite = isMale ? maleBrows[id[3]] : femaleBrows[id[3]];
        eyes.sprite = isMale ? maleEyes[id[4]] : femaleEyes[id[4]];
        mouth.sprite = isMale ? maleMouths[id[5]] : femaleMouths[id[5]];
    }
}