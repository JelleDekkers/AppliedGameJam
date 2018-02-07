using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI {
    public class BuildingList : MonoBehaviour {
        public GameObject buttonPrefab;
        public ScriptableObject[] buildingPrefabs;

        // Use this for initialization
        private void Start() {
            for(int i = 0 ; i < buildingPrefabs.Length ; i++) {
                // CREATE BUTTON WITH SCRIPTABLE OBJECT PROPERTIES
                GameObject obj = Instantiate<GameObject>(buttonPrefab);
                obj.transform.parent = gameObject.transform;
                obj.GetComponent<RectTransform>().position = new Vector2(48 + (i * 100), 48);
            }
        }

        // Update is called once per frame
        private void Update() {

        }
    }
}
