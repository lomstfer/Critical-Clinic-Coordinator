using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Face : MonoBehaviour {
    [SerializeField] Image head;
    [SerializeField] Image hair;
    [SerializeField] Image hair2;
    [SerializeField] Image brows;
    [SerializeField] Image eyes;
    [SerializeField] Image mouth;

    public void ApplyFaceId(int[] id) {
        bool isMale = id[0] == 0 ? true : false;
        head.sprite = isMale ? FaceGenerator.Instance.MaleHeads[id[1]] : FaceGenerator.Instance.FemaleHeads[id[1]];
        hair.sprite = isMale ? FaceGenerator.Instance.MaleHairs[id[2]] : FaceGenerator.Instance.FemaleHairs[id[2]];
        hair2.sprite = isMale ? FaceGenerator.Instance.MaleHairs2[0] : FaceGenerator.Instance.FemaleHairs2[id[2]];
        brows.sprite = isMale ? FaceGenerator.Instance.MaleBrows[id[3]] : FaceGenerator.Instance.FemaleBrows[id[3]];
        eyes.sprite = isMale ? FaceGenerator.Instance.MaleEyes[id[4]] : FaceGenerator.Instance.FemaleEyes[id[4]];
        mouth.sprite = isMale ? FaceGenerator.Instance.MaleMouths[id[5]] : FaceGenerator.Instance.FemaleMouths[id[5]];
        
        ColorProfile colors = FaceGenerator.Instance.ColorProfiles[id[6]];
        hair.color = colors.Hair;
        hair2.color = colors.Hair;
        head.color = colors.Skin;
        mouth.color = colors.Lips;
    }   
}