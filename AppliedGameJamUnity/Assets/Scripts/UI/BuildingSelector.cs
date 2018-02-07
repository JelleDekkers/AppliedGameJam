using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace UI {
    public class BuildingSelector : MonoBehaviour {

        public GameObject selectedBuilding;

        // Use this for initialization
        private void Start() {

        }

        // Update is called once per frame
        private void Update() {

        }

        public void SetBuilding( BuildingContainer buildingContainer ) {
            selectedBuilding = buildingContainer.building;
        }
    }
}
