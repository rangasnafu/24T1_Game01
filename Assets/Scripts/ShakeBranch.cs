using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeBranch : MonoBehaviour
{
    public GameObject acornToDrop1;
    public GameObject acornToDestroy1;
    public GameObject acornToDrop2;
    public GameObject acornToDestroy2;
    public GameObject acornToDrop3;
    public GameObject acornToDestroy3;
    public GameObject acornToDrop4;
    public GameObject acornToDestroy4;
    public GameObject acornToDrop5;
    public GameObject acornToDestroy5;
    public GameObject acornToDrop6;
    public GameObject acornToDestroy6;

    public GameObject interactPrompt;

    private bool canInteract = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canInteract)
        {
            acornToDrop1.SetActive(true);
            acornToDestroy1.SetActive(false);
            acornToDrop2.SetActive(true);
            acornToDestroy2.SetActive(false);
            acornToDrop3.SetActive(true);
            acornToDestroy3.SetActive(false);
            acornToDrop4.SetActive(true);
            acornToDestroy4.SetActive(false);
            acornToDrop5.SetActive(true);
            acornToDestroy5.SetActive(false);
            acornToDrop6.SetActive(true);
            acornToDestroy6.SetActive(false);


            canInteract = false;
            interactPrompt.SetActive(false);
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            canInteract = true;
            interactPrompt.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            interactPrompt.SetActive(false);
        } 
    }
}
