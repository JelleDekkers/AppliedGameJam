using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CompanyView {

    public class BuildGrid : MonoBehaviour {

        public Tile[,] Grid { get; private set; }

        [SerializeField]
        private int xSize, zSize;
        [SerializeField]
        private Tile tilePrefab;
        [SerializeField]
        private Material lineMaterial;

        public bool showGridLines;

        private void Start() {
            Fill();
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

        public void ToggleGridLines() {
            showGridLines = !showGridLines;
        }

        private void OnRenderObject() {
            if (!showGridLines)
                return;

            // horizontal:
            Vector3 start;
            Vector3 end;
            for (int x = 0; x < xSize + 1; x++) {
                start = new Vector3(x * Tile.SIZE.x - Tile.SIZE.x / 2, 0, -Tile.SIZE.z / 2);
                end = new Vector3(x * Tile.SIZE.x - Tile.SIZE.x / 2, 0, zSize * Tile.SIZE.z - Tile.SIZE.z / 2);
                GL.PushMatrix();
                lineMaterial.SetPass(0);
                GL.Begin(GL.LINES);
                GL.Vertex3(start.x, start.y, start.z);
                GL.Vertex3(end.x, end.y, end.z);
                GL.End();
                GL.PopMatrix();
            }

            // vertical:
            for (int z = 0; z < zSize + 1; z++) {
                start = new Vector3(-Tile.SIZE.x / 2, 0, z * Tile.SIZE.z - Tile.SIZE.z / 2);
                end = new Vector3(xSize * Tile.SIZE.x - Tile.SIZE.x / 2, 0, z * Tile.SIZE.z - Tile.SIZE.z / 2);
                GL.PushMatrix();
                lineMaterial.SetPass(0);
                GL.Begin(GL.LINES);
                GL.Vertex3(start.x, start.y, start.z);
                GL.Vertex3(end.x, end.y, end.z);
                GL.End();
                GL.PopMatrix();
            }
        }
    }
}