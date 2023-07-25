using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FaceGenerator : Singleton<FaceGenerator> {
    [Header("Male Parts")]
    public Sprite[] MaleHeads;
    public Sprite[] MaleHairs;
    public Sprite[] MaleHairs2;
    public Sprite[] MaleBrows;
    public Sprite[] MaleEyes;
    public Sprite[] MaleMouths;

    [Header("Female Parts")]
    public Sprite[] FemaleHeads;
    public Sprite[] FemaleHairs;
    public Sprite[] FemaleHairs2;
    public Sprite[] FemaleBrows;
    public Sprite[] FemaleEyes;
    public Sprite[] FemaleMouths;

    [Header("Color")]
    public ColorProfile[] ColorProfiles;

    public int[] GenerateNewFaceId() {
        int[] id = new int[7];
        id[0] = Random.Range(0, 2);
        bool isMale = id[0] == 0 ? true : false;
        id[1] = Random.Range(0, isMale ? MaleHeads.Length : FemaleHeads.Length);
        id[2] = Random.Range(0, isMale ? MaleHairs.Length : FemaleHairs.Length);
        id[3] = Random.Range(0, isMale ? MaleBrows.Length : FemaleBrows.Length);
        id[4] = Random.Range(0, isMale ? MaleEyes.Length : FemaleEyes.Length);
        id[5] = Random.Range(0, isMale ? MaleMouths.Length : FemaleMouths.Length);
        id[6] = Random.Range(0, ColorProfiles.Length);
        return id;
    }

    // public void ApplyFaceId(int[] id) {
    //     bool isMale = id[0] == 0 ? true : false;
    //     head.sprite = isMale ? maleHeads[id[1]] : femaleHeads[id[1]];
    //     hair.sprite = isMale ? maleHairs[id[2]] : femaleHairs[id[2]];
    //     hair2.sprite = isMale ? maleHairs2[0] : femaleHairs2[id[2]];
    //     brows.sprite = isMale ? maleBrows[id[3]] : femaleBrows[id[3]];
    //     eyes.sprite = isMale ? maleEyes[id[4]] : femaleEyes[id[4]];
    //     mouth.sprite = isMale ? maleMouths[id[5]] : femaleMouths[id[5]];
        
    //     ColorProfile colors = colorProfiles[id[6]];
    //     hair.color = colors.Hair;
    //     hair2.color = colors.Hair;
    //     head.color = colors.Skin;
    //     mouth.color = colors.Lips;
    // }
}

[System.Serializable]
public struct ColorProfile {
    public string Name;
    public Color Hair;
    public Color Skin;
    public Color Lips;
}