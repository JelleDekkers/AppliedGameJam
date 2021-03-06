﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CompanyView {

    public enum BuildMode {
        Create,
        Destroy
    }

    public class BuildPlacement : MonoBehaviour {

        private Tile[,] tilesHoveringOver;

        [SerializeField]
        private bool placeRandomBuildingsAtStart = true;
        [SerializeField]
        private PlacementEffect effectHandler;

        public Building[] starterBuildings;
        public BuildMode buildMode;

        private void Start() {
            if(placeRandomBuildingsAtStart)
                PlaceRandomBuildings();

            BuildingSelector.OnBuildingSelected += () => { buildMode = BuildMode.Create; };
        }

        private void PlaceRandomBuildings() {
            IntVector2 gridSize = new IntVector2(Company.Instance.grid.Grid.GetLength(0), Company.Instance.grid.Grid.GetLength(1));
            for(int i = 0; i < starterBuildings.Length; i++) {

                Vector3 rndPos = new Vector3(Random.Range(0, gridSize.x - 1), 0, Random.Range(0, gridSize.z - 1));

                Tile[,] tilesNeeded = GetTilesAt(rndPos, new IntVector2(starterBuildings[i].xSize, starterBuildings[i].zSize));
                if (CanBePlaced(tilesNeeded))
                    PlaceBuilding(starterBuildings[i], tilesNeeded, true);
                else
                    i--;
            }
        }

        private void Update() {
            switch(buildMode) {
                case BuildMode.Create:
                    PlaceMode();
                    break;
                case BuildMode.Destroy:
                    DestroyMode();
                    break;
            }
        }

        public void ToggleMode() {
            if (buildMode == BuildMode.Create)
                buildMode = BuildMode.Destroy;
            else
                buildMode = BuildMode.Create;
        }

        private void PlaceMode() {
            if (BuildingSelector.SelectedBuilding == null)
                return;

            if (tilesHoveringOver != null)
                RevertTileColorsToBase();
            bool isHitting = false;
            tilesHoveringOver = GetTilesAt(RaycastHelper.GetMousePositionInScene(out isHitting), new IntVector2(BuildingSelector.SelectedBuilding.xSize, BuildingSelector.SelectedBuilding.zSize));

            if (tilesHoveringOver == null)
                return;

            AdjustTileColors();
            if (Input.GetMouseButtonDown(0) && CanBePlaced(tilesHoveringOver) && BuildingSelector.SelectedBuilding.CanBeBought())
                PlaceBuilding(BuildingSelector.SelectedBuilding, tilesHoveringOver, false);
        }

        private void DestroyMode() {
            BuildingSelector.SetToNull();
            bool isHitting = true;
            RaycastHelper.GetMousePositionInScene(out isHitting);
            if (tilesHoveringOver != null)
                RevertTileColorsToBase();

            if (isHitting == false)
                return;
            try {
                tilesHoveringOver = GetTilesAt(RaycastHelper.GetMousePositionInScene(out isHitting), new IntVector2(1, 1));
                AdjustTileColors();
                if (Input.GetMouseButtonDown(0) && tilesHoveringOver != null && tilesHoveringOver[0, 0].occupant != null)
                    DestroyBuilding(tilesHoveringOver[0, 0]);
            }
            catch {

            }
        }

        private void DestroyBuilding(Tile hoveringOver) {
            Building b = tilesHoveringOver[0, 0].occupant;
            Player.Instance.RemoveBuilding(b);
            Destroy(b.gameObject);
        }

        private void AdjustTileColors() {
            foreach (Tile t in tilesHoveringOver) {
                if (t == null)
                    continue;
                if (t.occupant != null)
                    t.SetColorToOccupied();
                else
                    t.SetColorToOpen();
            }
        }

        private void RevertTileColorsToBase() {
            foreach (Tile t in tilesHoveringOver) {
                if (t == null)
                    continue;
                t.SetColorToBase();
            }
        }

        private void PlaceBuilding(Building buildingPrefab, Tile[,] tiles, bool fromStart) {
            Building building = Instantiate(buildingPrefab, tiles[0, 0].transform.position, Quaternion.identity);
            building.transform.SetParent(transform);

            foreach (Tile t in tiles)
                t.occupant = building;

            Vector3 halfSize = Vector3.zero;
            if (building.xSize > 1)
                halfSize.x = (int)(building.xSize / 2) - Tile.SIZE.x / 2;
            if (building.zSize > 1)
                halfSize.z = (int)(building.zSize / 2) - Tile.SIZE.z / 2;
            building.transform.position += halfSize;

            Player.Instance.AddBuilding(building);

            if (!fromStart) {
                Player.Instance.RemoveResources(building.cost);
                effectHandler.Activate(building.transform.position);
                GameCam.Instance.Shake();
            }
        }

        private Tile[,] GetTilesAt(Vector3 position, IntVector2 buildingSize) {
            IntVector2 coordinate = new IntVector2((int)RoundDownToGridCoordinate(position).x, (int)RoundDownToGridCoordinate(position).y);
            Tile[,] tiles = new Tile[buildingSize.x, buildingSize.z];
            // get all tiles necessary for building:
            for (int x = 0; x < buildingSize.x; x++) {
                for (int z = 0; z < buildingSize.z; z++) {
                    if (Company.Instance.grid.IsInsideGrid(coordinate.x + x, coordinate.z + z)) {
                        Tile t = Company.Instance.grid.Grid[coordinate.x + x, coordinate.z + z];
                        tiles[x, z] = t;
                    } 
                }
            }
             
            return tiles;
        }

        private bool CanBePlaced(Tile[,] tilesNeeded) {
            if (tilesNeeded == null)
                return false;

            for (int x = 0; x < tilesNeeded.GetLength(0); x++) {
                for (int z = 0; z < tilesNeeded.GetLength(1); z++) {
                    if (tilesNeeded[x, z] == null || tilesNeeded[x, z].occupant != null)
                        return false;
                }
            }
            return true;
        }

        private Vector2 RoundDownToGridCoordinate(Vector3 point) {
            return new Vector2(Mathf.Round(point.x), Mathf.Round(point.z));
        }
    }
}