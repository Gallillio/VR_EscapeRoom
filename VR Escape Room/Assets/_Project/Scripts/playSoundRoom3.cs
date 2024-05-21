using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playSoundRoom3 : MonoBehaviour
{
    public AudioSource audioSource;  // Reference to the AudioSource component

    void Start()
    {
        // Ensure the AudioSource component is assigned
        if (audioSource == null)
        {
            Debug.LogError("AudioSource is not assigned!");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("AAAAAAAAAAA");

        // Check if the entering object is the player
        if (other.CompareTag("MainCamera"))
        {
            // Play the audio clip
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
    }
}
