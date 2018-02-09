using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldStats : MonoBehaviour {

    private static WorldStats instance;
    public static WorldStats Instance {
        get {
            if (instance == null)
                instance = FindObjectOfType<WorldStats>();
            return instance;
        }
    }

    public float WorldPollution;
    public float AverageWorldTemperature;
    public float AverageWorldTemperatureStart = 20f;
    public float TemperatureIncreasePerPollution = 0.01f;
    public float TemperatureMaxGameOverRate = 40f;
    public GameObject gameOverScreen;

    private void Start() {
        DontDestroyOnLoad(gameObject);
        AverageWorldTemperature = AverageWorldTemperatureStart;
    }

    private void Update() {
        AverageWorldTemperature = WorldPollution * TemperatureIncreasePerPollution + AverageWorldTemperatureStart;

        if (AverageWorldTemperature > TemperatureMaxGameOverRate)
            GameManager.GameWon();
        if(AverageWorldTemperature > 40) {
            gameOverScreen.SetActive(true);
        }
    }
}
