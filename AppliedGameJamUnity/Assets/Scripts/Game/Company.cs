using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CompanyView {

    public class Company : MonoBehaviour {

        private static Company instance;
        public static Company Instance {
            get {
                if (instance == null)
                    instance = FindObjectOfType<Company>();
                return instance;
            }
        }

        [Header("References")]
        public BuildGrid grid;
    }
}