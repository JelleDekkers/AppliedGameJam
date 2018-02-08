using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BuildingContainer : MonoBehaviour, IPointerEnterHandler,IPointerExitHandler {

    public GameObject selectedPrefab;
    private GameObject statPrefab;
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
        statPrefab = transform.GetChild(1).gameObject;
        button = GetComponent<Button>();
        GetComponent<Image>().sprite = sprite;

        Text text = statPrefab.GetComponentInChildren<Text>();
        text.text = "Cost : $" + building.cost + ".-";
        SpriteState spriteState;
        spriteState.pressedSprite = clickedSprite;
        button.spriteState = spriteState;

        audioSource = GetComponent<AudioSource>();
        clipSelect = Resources.Load<AudioClip>("Audio/Button_Press_19");
        clipDeselect = Resources.Load<AudioClip>("Audio/Button_Press_5");
    }
	
	// Update is called once per frame
	void Update () {
        if (selected && !selectedPrefab.activeSelf) {
            audioSource.PlayOneShot(clipSelect);
            selectedPrefab.SetActive(true);
        }
        else if (!selected && selectedPrefab.activeSelf) {
            selectedPrefab.SetActive(false);
            audioSource.PlayOneShot(clipDeselect);
        }
    }

    public void OnPointerEnter( PointerEventData eventData ) {
        statPrefab.SetActive(true);
    }

    public void OnPointerExit( PointerEventData eventData ) {
        statPrefab.SetActive(false);
    }
}
