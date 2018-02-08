using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewSwitcher : MonoBehaviour {

    private static ViewSwitcher instance;
    public static ViewSwitcher Instance {
        get {
            if (instance == null)
                instance = FindObjectOfType<ViewSwitcher>();
            return instance;
        }
    }

    public GameObject worldView, gameView;

    private void Start() {
        worldView.SetActive(false);
        gameView.SetActive(true);
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space))
            Toggle();
    }

    public void Toggle() {
        worldView.SetActive(!worldView.activeInHierarchy);
        gameView.SetActive(!gameView.activeInHierarchy);
    }
}
