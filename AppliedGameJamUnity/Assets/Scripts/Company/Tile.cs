using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {

    [SerializeField]
    private Color openColor, occupiedColor;
    private Color baseColor;

    public Building occupant;

    public static readonly Vector3 SIZE = new Vector3(1, 0.1f, 1);

    public void SetColor() {
        GetComponent<Renderer>().material.color = openColor;
    }
}
