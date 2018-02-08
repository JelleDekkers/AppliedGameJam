using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BuildingContainer : MonoBehaviour {

    public GameObject selectedPrefab;
    public bool selected = false;
    public Building building;

    public Sprite sprite;
    public Sprite clickedSprite;


    private Button button;
    private AudioSource audioSource;

    private AudioClip clipSelect;
    private AudioClip clipDeselect;

    // Use this for initialization
    void Start () {
        button = GetComponent<Button>();
        GetComponent<Image>().sprite = sprite;

        SpriteState spriteState;
        spriteState.pressedSprite = clickedSprite;
        button.spriteState = spriteState;

        audioSource = GetComponent<AudioSource>();
        clipSelect = Resources.Load<AudioClip>("Audio/Button_Press_4");
        clipDeselect = Resources.Load<AudioClip>("Audio/Button_Press_5");
    }
	
	// Update is called once per frame
	void Update () {
        if (selected && !selectedPrefab.activeSelf) {
            selectedPrefab.SetActive(true);
        }
        else if (!selected && selectedPrefab.activeSelf) {
            selectedPrefab.SetActive(false);
        }
    }
}
