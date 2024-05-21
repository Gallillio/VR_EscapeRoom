using UnityEngine;

public class ShowHidePrefabOnCollision : MonoBehaviour
{
    public GameObject Object; // Reference to the pumpkin_king prefab
    public GameObject mainCamera; // Reference to the main camera object


    private void Update()
    {
        if (IsCameraInsideCollider())
        {
            Object.SetActive(true); // Show the pumpkin_king game object
        }
        else
        {
            Object.SetActive(false); // Hide the pumpkin_king game object
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
}
