using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementEffect : MonoBehaviour {

    [SerializeField]
    private AudioClip soundOnPlacement;
    [SerializeField]
    private new ParticleSystem particleSystem;
    [SerializeField]
    private AudioSource audioSource;

    public void Activate(Vector3 buildingPosition) {
        audioSource.PlayOneShot(soundOnPlacement);
        transform.position = buildingPosition;
        particleSystem.Play();
    }
}
