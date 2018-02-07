using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSelector : MonoBehaviour {
    private GameObject selectedBuilding;

    public GameObject SelectedBuilding {
        get {
            return selectedBuilding;
        }

        set {
            selectedBuilding = value;
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
