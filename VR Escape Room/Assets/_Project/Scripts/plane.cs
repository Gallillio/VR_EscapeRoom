using UnityEngine;

public class VoicePlane : MonoBehaviour
{
    // Reference to the audio clip for the voiceover
    public AudioClip voiceoverClip;

    // AudioSource to play the voiceover
    private AudioSource audioSource;

    // Flag to check if the audio has been played
    private bool hasPlayed = false;

    // Start is called before the first frame update
    void Start()
    {
        // Add an AudioSource component to the GameObject if it doesn't have one
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = voiceoverClip;
        audioSource.playOnAwake = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the main camera is colliding with this plane
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hit, Mathf.Infinity))
        {
            // Check if the hit object is the GameObject of this plane
            if (hit.collider.gameObject == gameObject)
            {
                // Calculate the distance between the camera and the plane
                float distance = Vector3.Distance(Camera.main.transform.position, hit.point);

                // Check if the distance is less than or equal to 4 units
                if (distance <= 4f && !hasPlayed)
                {
                    // Play the voiceover clip
                    PlayVoiceover();
                }
            }
        }
    }

    // Method to play the voiceover
    void PlayVoiceover()
    {
        if (voiceoverClip != null && !audioSource.isPlaying)
        {
            Debug.Log("Playing voiceover clip.");
            audioSource.Play();
            hasPlayed = true;  // Ensure the audio plays only once
        }
        else if (voiceoverClip == null)
        {
            Debug.LogWarning("Voiceover clip reference is null.");
        }
    }
}
