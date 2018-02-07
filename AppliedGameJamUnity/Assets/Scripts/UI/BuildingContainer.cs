using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingContainer : MonoBehaviour {
    public GameObject selectedPrefab;
    public bool selected = false;
    public Building building;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(selected && !selectedPrefab.activeSelf) {
            selectedPrefab.SetActive(true);
        }
        else if(!selected && selectedPrefab.activeSelf) {
            selectedPrefab.SetActive(false);
        }
	}
}
