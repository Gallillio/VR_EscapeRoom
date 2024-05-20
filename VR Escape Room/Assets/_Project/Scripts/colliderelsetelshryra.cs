using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colliderelsetelshryra : MonoBehaviour
{
    private bool soundPlayed = false; // Flag to ensure the sound is played only once

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !soundPlayed)
        {
            // Play audio from AudioManager
            FindObjectOfType<AudioManager>().PlaySound("elsetelsheryra");
            soundPlayed = true; // Set the flag to true to prevent replaying the sound
        }
    }
}
