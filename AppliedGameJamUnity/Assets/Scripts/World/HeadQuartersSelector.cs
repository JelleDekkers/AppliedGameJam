using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadQuartersSelector : MonoBehaviour {

    private void Update() {
        if(Input.GetMouseButtonDown(0))
            OnClick();
    }

    private void OnClick() {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit)) {
            if (hit.transform.GetComponent<PlayerHeadQuarters>())
                hit.transform.GetComponent<PlayerHeadQuarters>().OnSelected();
        }
    }
}
