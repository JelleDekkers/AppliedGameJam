using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CompanyView {

    public class BuildGrid : MonoBehaviour {
        
        [SerializeField]
        private int xSize, zSize;
        [SerializeField]
        private Tile tilePrefab;

        public Tile[,] Grid { get; private set; }

        private void Start() {
            Fill();
            BoxCollider col = GetComponent<BoxCollider>();
            col.size = new Vector3(xSize, col.size.y, zSize);
            col.center = new Vector3(xSize / 2 - Tile.SIZE.x / 2, col.center.y, zSize / 2 - Tile.SIZE.z / 2);
        }

        public bool IsInsideGrid(int x, int z) {
            return (x >= 0 && x < xSize && z >= 0 && z < zSize);
        }

        private void Fill() {
            Grid = new Tile[xSize, zSize];
            for (int x = 0; x < xSize; x++) {
                for (int z = 0; z < zSize; z++) {
                    Tile t = Instantiate(tilePrefab, new Vector3(x, 0, z), Quaternion.identity, transform);
                    t.name += "(" + x + "," + z + ")";
                    Grid[x, z] = t;
                    //if ((x + z) % 2 == 0)
                    //    t.SetColor();
                }
            }
        }
    }
}