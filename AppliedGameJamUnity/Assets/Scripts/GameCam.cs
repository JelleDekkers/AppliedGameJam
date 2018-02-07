using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCam : MonoBehaviour {

    private WHCameraShake shaker;

    private void Start() {
        shaker = GetComponent<WHCameraShake>();
    }

    public void Shake() {
        shaker.doShake();
    }
}
