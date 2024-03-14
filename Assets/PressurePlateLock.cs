using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateLock : MonoBehaviour
{
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("PressurePlate"))
        {
            if (rb != null)
            {
                rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("PressurePlate"))
        {
            rb.constraints = RigidbodyConstraints.None;
        }
    }
}
