using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeBranch : MonoBehaviour
{
    public GameObject acornToDrop;
    public GameObject acornToDestroy;

    public GameObject interactPrompt;

    private bool canInteract = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canInteract)
        {
            acornToDrop.SetActive(true);
            acornToDestroy.SetActive(false);
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

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            interactPrompt.SetActive(false);
        } 
    }
}
