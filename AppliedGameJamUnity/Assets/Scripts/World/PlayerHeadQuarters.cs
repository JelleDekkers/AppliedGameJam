using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeadQuarters : MonoBehaviour {

    public bool isPlayerBase;

    public TradePanel tradePanel;

    public void OnSelected() {
        if(isPlayerBase) {
            ViewSwitcher.Instance.Toggle();
        } else {
            tradePanel.gameObject.SetActive(true);
        }   
    }
}
