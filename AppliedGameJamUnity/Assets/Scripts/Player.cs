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

    public float pollutionProduced;

    public GameResource[] inventory;

    [HideInInspector]
    public List<Building> Buildings = new List<Building>();

    private void Start() {
        DontDestroyOnLoad(gameObject);
    }

    public void AddBuilding(Building b) {
        Buildings.Add(b);
    }

    public bool HasResources(GameResource resource) {
        foreach(GameResource inventoryItem in inventory) {
            if (inventoryItem.resourceType == resource.resourceType)
                return inventoryItem.amount >= resource.amount;
        }

        Debug.LogError("No resource found in inventory");
        return false;
    }

    public void RemoveResources(GameResource resource) {
        foreach (GameResource inventoryItem in inventory) {
            if (inventoryItem.resourceType == resource.resourceType)
                inventoryItem.amount -= resource.amount;
        }
    }

    public void AddResource(GameResource resource) {
        foreach (GameResource inventoryItem in inventory) {
            if (inventoryItem.resourceType == resource.resourceType)
                inventoryItem.amount += resource.amount;
        }
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
        GUI.Label(new Rect(10, 20, 1000, 20), "Pollution Produced: " + pollutionProduced);
        GUI.Label(new Rect(10, 35, 1000, 20), "World Pollution: " + WorldStats.Instance.WorldPollution);
        GUI.Label(new Rect(10, 50, 1000, 20), "Avg World Temperature " + WorldStats.Instance.AverageWorldTemperature + " / " + WorldStats.Instance.TemperatureMaxGameOverRate);

        int spaceBetween = 15;
        for (int i = 0; i < inventory.Length; i++)
            GUI.Label(new Rect(10, 75 + (i * spaceBetween), 1000, 20), inventory[i].resourceType.ToString() + ": " + inventory[i].amount.ToString()); 
    }
}
