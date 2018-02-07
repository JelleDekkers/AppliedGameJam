using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Testing {
    public class TestShowBuilding : MonoBehaviour {
        private Text text;
        public BuildingSelector selector;

        public void Start() {
            text = gameObject.GetComponent<Text>();
        }

        public void Update() {
            if (selector.selectedBuilding != null) {

                text.text = selector.selectedBuilding.name;
            }
            else {
                text.text = "No building selected";
            }
        }
    }
}
