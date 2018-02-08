using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsDisplayer : MonoBehaviour {

    private void OnGUI() {
        GUI.color = Color.black;
        GUI.Label(new Rect(10, 10, 1000, 20), "Money: " + Player.money);
        GUI.Label(new Rect(10, 30, 1000, 20), "Poluttion Produced: " + Player.pollutionProduced);
        GUI.Label(new Rect(10, 50, 1000, 20), "World Pollution: " + WorldStats.Instance.WorldPollution);
        GUI.Label(new Rect(10, 70, 1000, 20), "Avg World Temperature " + WorldStats.Instance.AverageWorldTemperature);
    }
}
