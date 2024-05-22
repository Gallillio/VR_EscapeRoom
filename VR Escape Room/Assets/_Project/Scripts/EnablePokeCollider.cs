using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnablePokeCollider : MonoBehaviour
{
    public SphereCollider leftPokeCollider;
    public SphereCollider rightPokeCollider;

    void Start()
    {
        leftPokeCollider = leftPokeCollider.GetComponent<SphereCollider>();
        rightPokeCollider = rightPokeCollider.GetComponent<SphereCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            leftPokeCollider.enabled = true;
            rightPokeCollider.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            leftPokeCollider.enabled = false;
            rightPokeCollider.enabled = false;
        }
    }

    void Update()
    {
        
    }
}
