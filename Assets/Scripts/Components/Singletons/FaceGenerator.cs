using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceGenerator : Singleton<FaceGenerator> {
    [SerializeField] Sprite[] maleHeads;
    [SerializeField] Sprite[] maleHairs;
    [SerializeField] Sprite[] maleBrows;
    [SerializeField] Sprite[] maleEyes;
    [SerializeField] Sprite[] maleMouths;

    [SerializeField] Sprite[] femaleHeads;
    [SerializeField] Sprite[] femaleHairs;
    [SerializeField] Sprite[] femaleBrows;
    [SerializeField] Sprite[] femaleEyes;
    [SerializeField] Sprite[] femaleMouths;

    public int[] GenerateFaceId() {
        int[] id = new int[6];
        id[0] = Random.Range(0, 1);
        id[1] = Random.Range(0, id[0] == 0 ? maleHeads.Length : femaleHeads.Length);
        id[2] = Random.Range(0, id[0] == 0 ? maleHairs.Length : femaleHairs.Length);
        id[3] = Random.Range(0, id[0] == 0 ? maleBrows.Length : femaleBrows.Length);
        id[4] = Random.Range(0, id[0] == 0 ? maleEyes.Length : femaleEyes.Length);
        id[5] = Random.Range(0, id[0] == 0 ? maleMouths.Length : femaleMouths.Length);
        return id;
    }
}