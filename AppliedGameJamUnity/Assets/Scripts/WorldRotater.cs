using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldRotater : MonoBehaviour {

    Ray r;
    RaycastHit hit;

    public float speed = 2;

    private void Update() {
        r = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Input.GetMouseButton(0)) {
            transform.Rotate(Input.GetAxis("Mouse Y") * speed * Time.deltaTime, (Input.GetAxis("Mouse X") * speed * -Time.deltaTime), 0, Space.World);
        }
    }
}