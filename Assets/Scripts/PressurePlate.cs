using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public GameObject gate;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Acorn"))
        {
            Debug.Log("wooooo");
            gate.transform.Rotate(transform.eulerAngles + new Vector3(0, -90, 0));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Acorn"))
        {
            gate.transform.Rotate(transform.eulerAngles + new Vector3(0, 90, 0));
        }
    }
}
