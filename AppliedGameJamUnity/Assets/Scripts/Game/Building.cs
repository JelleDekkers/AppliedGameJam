using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour {
    public Sprite thumbnail;
    public Sprite thumbnailClicked;
    public float cost;
    public float emissionPerProduction;
    public int xSize, zSize;
    public float revenuePerProduction;
    public float revenueTimeInSeconds;

    private float revenueTimer;

    private void Start() {
        revenueTimer = revenueTimeInSeconds;
    }

    private void Update() {
        if(revenueTimer > 0) {
            revenueTimer -= Time.deltaTime;
        } else {
            Production();
            revenueTimer = revenueTimeInSeconds;
        }
    }

    public bool CanBeBought() {
        return Player.money >= cost;
    }

    private void Production() {
        WorldStats.Instance.WorldPollution += emissionPerProduction;
        Player.money += revenuePerProduction;
        Player.pollutionProduced += emissionPerProduction;
    }
}
