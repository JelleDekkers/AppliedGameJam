using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GFPlaceBuilding : MonoBehaviour {
    // Use this for initialization
    public ParticleSystem system;
    public AudioSource source;
    public AudioClip clip;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Place() {
        system.Play();
        source.PlayOneShot(clip);
    }
}
