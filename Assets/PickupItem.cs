using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    public AudioClip pickupSound; // Sound to play when picked up
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>(); // Add an AudioSource to the item
        audioSource.clip = pickupSound;
        audioSource.playOnAwake = false; // Do not play the sound immediately
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            audioSource.Play(); // Play the pickup sound
            gameObject.SetActive(false); // Deactivate the item (simulating it being picked up)
        }
    }
}
