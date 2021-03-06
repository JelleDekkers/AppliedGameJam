﻿using System;


namespace CompanyView {

    public static class BuildingSelector {

        private static Building selectedBuilding;

        private static BuildingContainer oldBuilding;

        public static Building SelectedBuilding {
            get {
                return selectedBuilding;
            }

            private set {
                selectedBuilding = value;
            }
        }

        public static Action OnBuildingSelected;

        public static void SetBuilding( BuildingContainer buildingContainer ) {
            if (OnBuildingSelected != null)
                OnBuildingSelected.Invoke();

            if(oldBuilding != null)oldBuilding.selected = false;
            
            if (SelectedBuilding == buildingContainer.building) {
                SelectedBuilding = null;
                buildingContainer.selected = false;
            }
            else {
                SelectedBuilding = buildingContainer.building;
                buildingContainer.selected = true;
            }
            oldBuilding = buildingContainer;
        }

        public static void SetToNull() {
            SelectedBuilding = null;
            oldBuilding = null;
        }
    }
}
