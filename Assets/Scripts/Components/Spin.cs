using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour {
    float speed = -300;
    void Update() {
        transform.Rotate(new(0, 0, speed * Time.deltaTime));
    }
}
