using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CompanyView {

    public class BuildPlacement : MonoBehaviour {

        public Building buildingPrefabToPlace;

        private void Update() {
            PlaceMode();
        }

        private void PlaceMode() {
            Tile[,] tilesHoveringOver = GetTilesAtMousePoint();

            if (Input.GetMouseButtonDown(0) && CanBePlaced(tilesHoveringOver))
                PlaceBuilding(tilesHoveringOver);
        }

        private void PlaceBuilding(Tile[,] tiles) {
            Building building = Instantiate(buildingPrefabToPlace, tiles[0, 0].transform.position, Quaternion.identity);

            foreach (Tile t in tiles)
                t.occupant = building;

            Vector3 halfSize = Vector3.zero;
            if (buildingPrefabToPlace.xSize > 1)
                halfSize.x = (int)(buildingPrefabToPlace.xSize / 2) - Tile.SIZE.x / 2;
            if(buildingPrefabToPlace.zSize > 1)
                halfSize.z = (int)(buildingPrefabToPlace.zSize / 2) - Tile.SIZE.z / 2;
            building.transform.position += halfSize;
        }

        private Tile[,] GetTilesAtMousePoint() {
            Vector3 mousePoint = RaycastHelper.GetMousePositionInScene();
            IntVector2 mouseCoordinate = new IntVector2((int)RoundDownToGridCoordinate(mousePoint).x, (int)RoundDownToGridCoordinate(mousePoint).y);
            Tile[,] tiles = new Tile[buildingPrefabToPlace.xSize, buildingPrefabToPlace.zSize];

            // get all tiles necessary for building:
            for (int x = 0; x < buildingPrefabToPlace.xSize; x++) {
                for (int z = 0; z < buildingPrefabToPlace.zSize; z++) {
                    IntVector2 coordinate = new IntVector2(mouseCoordinate.x + x, mouseCoordinate.z + z);
                    if (Company.Instance.grid.IsInsideGrid(coordinate.x, coordinate.z)) {
                        Tile t = Company.Instance.grid.Grid[coordinate.x, coordinate.z];
                        if (t.occupant != null)
                            return null;
                        tiles[x, z] = t;
                    }
                }
            }
             
            return tiles;
        }

        private bool CanBePlaced(Tile[,] tiles) {
            if (tiles == null)
                return false;

            for (int x = 0; x < tiles.GetLength(0); x++) {
                for (int z = 0; z < tiles.GetLength(1); z++) {
                    if (tiles[x, z] == null || tiles[x, z].occupant != null)
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