﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    public float money, pollutionProduced;

    public void Update() {
        money = Player.money;
        pollutionProduced = Player.pollutionProduced;
    }
}
