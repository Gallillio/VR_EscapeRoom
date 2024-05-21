using UnityEngine;

public class ShowHidePrefabOnCollision : MonoBehaviour
{
    public GameObject Object; // Reference to the prefab
    public GameObject mainCamera; // Reference to the main camera object


    private void Update()
    {
        if (IsCameraInsideCollider())
        {
            Object.SetActive(true); 
        }
        else
        {
            Object.SetActive(false); 
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

    public void OnEnable()
    {
        FindObjectOfType<AudioManager>().PlaySound("Pumpkin_Bum");
    }
}

