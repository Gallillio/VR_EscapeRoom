using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushDoor : MonoBehaviour
{
    private Vector3 pushDirection = new Vector3(-1, 0, 0);
    public float pushForce = 10f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void PushDoorFunc()
    {
        // Debug.Log("push door");

        if (rb != null)
        {
            // Apply the force
            rb.constraints &= ~RigidbodyConstraints.FreezeRotationX;
            rb.AddForce(pushDirection.normalized * pushForce, ForceMode.Impulse);

            //play audio from AUDIOMANAGER
            FindObjectOfType<AudioManager>().PlaySound("doorSlam");
        }
        else
        {
            Debug.LogError("No Rigidbody component found on this GameObject.");
        }
    }


}
