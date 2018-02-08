using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private static Player instance;
    public static Player Instance {
        get {
            if (instance == null)
                instance = FindObjectOfType<Player>();
            return instance;
        }
    }

    public float money;
    public float pollutionProduced;

    
    public List<Building> Buildings = new List<Building>();

    private void Start() {
        DontDestroyOnLoad(gameObject);
    }

    public void AddBuilding(Building b) {
        Buildings.Add(b);
    }

    public void RemoveBuilding(Building b) {
        Buildings.Remove(b);
        int unsustainableBuildingsCount = 0;
        foreach(Building building in Buildings) {
            if (building.emissionPerProduction > 0)
                unsustainableBuildingsCount++;
        }

        if (unsustainableBuildingsCount == 0)
            GameManager.GameWon();
    }

    private void OnGUI() {
        GUI.color = Color.black;
        GUI.Label(new Rect(10, 10, 1000, 20), "Money: " + money);
        GUI.Label(new Rect(10, 30, 1000, 20), "Poluttion Produced: " + pollutionProduced);
        GUI.Label(new Rect(10, 50, 1000, 20), "World Pollution: " + WorldStats.Instance.WorldPollution);
        GUI.Label(new Rect(10, 70, 1000, 20), "Avg World Temperature " + WorldStats.Instance.AverageWorldTemperature);
    }
}
