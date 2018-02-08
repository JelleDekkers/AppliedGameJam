using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour {
    public Sprite thumbnail;
    public Sprite thumbnailClicked;
    public GameResource cost;
    public int xSize, zSize = 1;
    public float emissionPerProduction;
    public GameResource productionPerCycle;
    public float productionTimeInSeconds;

    private float revenueTimer;

    private void Start() {
        revenueTimer = productionTimeInSeconds;
    }

    private void Update() {
        if(revenueTimer > 0) {
            revenueTimer -= Time.deltaTime;
        } else {
            Production();
            revenueTimer = productionTimeInSeconds;
        }
    }

    public bool CanBeBought() {
        return Player.Instance.HasResources(cost);
    }

    private void Production() {
        WorldStats.Instance.WorldPollution += emissionPerProduction;
        Player.Instance.AddResource(productionPerCycle);
        Player.Instance.pollutionProduced += emissionPerProduction;
    }
}
