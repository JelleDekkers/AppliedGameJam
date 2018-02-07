using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingContainer : MonoBehaviour {
    private AudioClip clipSelect;
    private AudioClip clipDeselect;
    public GameObject selectedPrefab;
    public bool selected = false;
    public Building building;
    private AudioSource audioSource;

    // Use this for initialization
    void Start () {
        audioSource = GetComponent<AudioSource>();
        clipSelect = Resources.Load<AudioClip>("Audio/Button_Press_4");
        clipDeselect = Resources.Load<AudioClip>("Audio/Button_Press_5");
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
