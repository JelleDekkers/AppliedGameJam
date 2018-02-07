using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace UI {
    class Building : ScriptableObject {
        public GameObject prefab;
        public Sprite mask;

        [MenuItem("Assets/Create/Building")]
        public static void CreateMyAsset() {
            Building asset = ScriptableObject.CreateInstance<Building>();

            AssetDatabase.CreateAsset(asset, "Assets/ScriptableObjects/NewBuilding.asset");
            AssetDatabase.SaveAssets();

            EditorUtility.FocusProjectWindow();

            Selection.activeObject = asset;
        }
    }
}