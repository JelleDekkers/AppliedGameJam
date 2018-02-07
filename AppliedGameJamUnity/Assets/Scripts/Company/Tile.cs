using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {

    public static readonly Vector3 SIZE = new Vector3(1, 0.1f, 1);

    public Building occupant;

    [SerializeField]
    private Color occupiedColor, openColor;

    private Color baseColor;
    private Renderer rend;

    private void Start() {
        rend = GetComponent<Renderer>();
        baseColor = rend.material.color;
    }

    public void SetColorToBase() {
        rend.material.color = baseColor;
    }

    public void SetColorToOccupied() {
        rend.material.color = occupiedColor;
    }

    public void SetColorToOpen() {
        rend.material.color = openColor;
    }
}
