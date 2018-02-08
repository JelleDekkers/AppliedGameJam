using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour {
    public Sprite thumbnail;
    public Sprite thumbnailClicked;
    public float cost;
    public float emission;
    public int xSize, zSize;
    public float revenuePerProduction;
    public float revenueTimeInSeconds;
    public float revenueTimer;

    private void Start() {
        revenueTimer = revenueTimeInSeconds;
    }

    private void Update() {
        if(revenueTimer > 0) {
            revenueTimer -= Time.deltaTime;
        } else {
            Productie();
            revenueTimer = revenueTimeInSeconds;
        }
    }

    public bool CanBeBought() {
        return Player.money >= cost;
    }

    private void Productie() {
        WorldStats.Pollution += emission;
        Player.money += revenuePerProduction;
        Player.pollutionProduced += emission;
    }
}
