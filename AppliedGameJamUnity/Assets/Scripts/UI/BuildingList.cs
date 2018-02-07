﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI {
    public class BuildingList : MonoBehaviour {
        public GameObject buttonPrefab;
        public Building[] buildingPrefabs;
        public RectTransform myRect;
        private AudioSource audioSource;

        public float scrollSpeed = 96;


        // Use this for initialization
        private void Start() {
            audioSource = GetComponent<AudioSource>();
            for(int i = 0 ; i < buildingPrefabs.Length ; i++) {
                // CREATE BUTTON WITH SCRIPTABLE OBJECT PROPERTIES
                GameObject obj = Instantiate<GameObject>(buttonPrefab);
                obj.transform.SetParent(gameObject.transform);
                obj.GetComponent<Image>().sprite = buildingPrefabs[i].gameObject.GetComponent<Image>().sprite;
                obj.GetComponent<RectTransform>().position = new Vector2(48 + (i * 100), 48);
                obj.GetComponent<BuildingContainer>().building = buildingPrefabs[i];
                obj.GetComponent<Button>().onClick.AddListener(delegate () { Select(obj.GetComponent<BuildingContainer>()); });
            }
            myRect = GetComponent<RectTransform>();

        }

        // Update is called once per frame
        private void Update() {
            if (Input.GetAxis("Mouse ScrollWheel") > 0) {
                myRect.position += new Vector3(scrollSpeed, 0, 0);
            }
            else if (Input.GetAxis("Mouse ScrollWheel") < 0) {
                myRect.position -= new Vector3(scrollSpeed, 0, 0);
            }
        }
        private void Select(BuildingContainer building) {
            if(BuildingSelector.SelectedBuilding == building) {
            }
            else {
            }
            BuildingSelector.SetBuilding(building);
            
        }
    }
}
