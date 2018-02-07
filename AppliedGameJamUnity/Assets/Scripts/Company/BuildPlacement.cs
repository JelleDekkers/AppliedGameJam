using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CompanyView {

    public class BuildPlacement : MonoBehaviour {

        private Tile[,] tilesHoveringOver;

        private void Update() {
            if(BuildingSelector.SelectedBuilding != null)
                PlaceMode();
        }

        private void PlaceMode() {
            if(tilesHoveringOver != null)
                RevertTileColorsToBase();
            tilesHoveringOver = GetTilesAtMousePoint();

            if (tilesHoveringOver == null)
                return;

            AdjustTileColors();
            if (Input.GetMouseButtonDown(0) && CanBePlaced())
                PlaceBuilding(tilesHoveringOver);
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

        private void PlaceBuilding(Tile[,] tiles) {
            Building building = Instantiate(BuildingSelector.SelectedBuilding, tiles[0, 0].transform.position, Quaternion.identity);

            foreach (Tile t in tiles)
                t.occupant = building;

            Vector3 halfSize = Vector3.zero;
            if (BuildingSelector.SelectedBuilding.xSize > 1)
                halfSize.x = (int)(BuildingSelector.SelectedBuilding.xSize / 2) - Tile.SIZE.x / 2;
            if(BuildingSelector.SelectedBuilding.zSize > 1)
                halfSize.z = (int)(BuildingSelector.SelectedBuilding.zSize / 2) - Tile.SIZE.z / 2;
            building.transform.position += halfSize;
        }

        private Tile[,] GetTilesAtMousePoint() {
            Vector3 mousePoint = RaycastHelper.GetMousePositionInScene();
            IntVector2 mouseCoordinate = new IntVector2((int)RoundDownToGridCoordinate(mousePoint).x, (int)RoundDownToGridCoordinate(mousePoint).y);
            Tile[,] tiles = new Tile[BuildingSelector.SelectedBuilding.xSize, BuildingSelector.SelectedBuilding.zSize];

            // get all tiles necessary for building:
            IntVector2 coordinate = mouseCoordinate;
            for (int x = 0; x < BuildingSelector.SelectedBuilding.xSize; x++) {
                for (int z = 0; z < BuildingSelector.SelectedBuilding.zSize; z++) {
                    if (Company.Instance.grid.IsInsideGrid(coordinate.x + x, coordinate.z + z)) {
                        Tile t = Company.Instance.grid.Grid[coordinate.x + x, coordinate.z + z];
                        tiles[x, z] = t;
                    } 
                }
            }
             
            return tiles;
        }

        private bool CanBePlaced() {
            if (tilesHoveringOver == null)
                return false;

            for (int x = 0; x < tilesHoveringOver.GetLength(0); x++) {
                for (int z = 0; z < tilesHoveringOver.GetLength(1); z++) {
                    if (tilesHoveringOver[x, z] == null || tilesHoveringOver[x, z].occupant != null)
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