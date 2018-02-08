using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCam : MonoBehaviour {

    private static GameCam instance;
    public static GameCam Instance {
        get {
            if (instance == null)
                instance = FindObjectOfType<GameCam>();
            return instance;
        }
    }

    public float movementSpeed = 2;

    private WHCameraShake shaker;
    private Ray r;
    private RaycastHit hit;

    private void Start() {
        shaker = GetComponent<WHCameraShake>();
    }

    public void Shake() {
        shaker.doShake();
    }

    private void Update() {
        r = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Input.GetMouseButton(0)) {
            float horizontal = Input.GetAxis("Mouse X") / 2 + Input.GetAxis("Mouse Y") / 2;
            float vertical = Input.GetAxis("Mouse X") / 2 - Input.GetAxis("Mouse Y") / 2;
            transform.Translate(-horizontal * movementSpeed * Time.deltaTime, 
                                0, 
                                -vertical * movementSpeed * -Time.deltaTime, 
                                Space.World);
        }
    }
}
