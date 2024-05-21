using UnityEngine;

public class ShowHidePrefabOnCollision : MonoBehaviour
{
    public GameObject Object; // Reference to the prefab
    public GameObject mainCamera; // Reference to the main camera object
    private bool hasPlayedSound = false; // Flag to track if the sound has been played

    private void Update()
    {
        if (IsCameraInsideCollider())
        {
            if (!Object.activeSelf)
            {
                Object.SetActive(true);
                PlaySoundOnce();
            }
        }
        else
        {
            if (Object.activeSelf)
            {
                Object.SetActive(false);
            }
        }
    }

    private bool IsCameraInsideCollider()
    {
        Collider collider = GetComponent<Collider>();
        if (collider != null && mainCamera != null)
        {
            return collider.bounds.Contains(mainCamera.transform.position);
        }
        return false;
    }

    private void PlaySoundOnce()
    {
        if (!hasPlayedSound)
        {
            FindObjectOfType<AudioManager>().PlaySound("Pumpkin_Bum");
            hasPlayedSound = true; // Set the flag to true after playing the sound
        }
    }

    // Remove the OnEnable method since we handle playing the sound in PlaySoundOnce method.
}
