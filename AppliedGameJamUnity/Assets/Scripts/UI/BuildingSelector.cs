using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace UI {
    public static class BuildingSelector {

        private static Building selectedBuilding;

        public static Building SelectedBuilding {
            get {
                return selectedBuilding;
            }

            private set {
                selectedBuilding = value;
            }
        }

        public static void SetBuilding( BuildingContainer buildingContainer ) {
            
            if (SelectedBuilding == buildingContainer.building) {
                SelectedBuilding = null;
            }
            else {
                SelectedBuilding = buildingContainer.building;
            }
        }
    }
}
