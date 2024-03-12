using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public GameObject myHands;

    public bool canPickup;
    public GameObject ObjectIWantToPickup;
    public bool hasItem;

    public float throwForce = 600;
    Vector3 objectPos;
    public float distance;

    public GameObject promptUI;
    public GameObject dropUI;

    public GameObject dialogueUI;
    public GameObject settingsUI;

    public GameObject crosshairUI;

    // Start is called before the first frame update
    void Start()
    {
        canPickup = false;
        hasItem = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (canPickup == true && !dialogueUI.activeSelf && !settingsUI.activeSelf)
        {
            if (Input.GetKeyDown("e"))
            {
                ObjectIWantToPickup.GetComponent<Rigidbody>().isKinematic = true;
                ObjectIWantToPickup.transform.position = myHands.transform.position;
                ObjectIWantToPickup.transform.parent = myHands.transform;
                hasItem = true;

                //promptUI.SetActive(false);
                dropUI.SetActive(true);
            }

        }
        if (Input.GetKeyDown("q") && hasItem == true && dialogueUI.activeSelf && !settingsUI.activeSelf)
        {
            ObjectIWantToPickup.GetComponent<Rigidbody>().isKinematic = false;
            ObjectIWantToPickup.transform.parent = null;
            ObjectIWantToPickup.GetComponent<Rigidbody>().AddForce(myHands.transform.forward * throwForce);
            hasItem = false;

            dropUI.SetActive(false);
        }

        //if (Input.GetKeyDown("t") && hasItem == true)
        //{
        //    ObjectIWantToPickup.GetComponent<Rigidbody>().isKinematic = false;
        //    ObjectIWantToPickup.transform.parent = null;
        //    ObjectIWantToPickup.GetComponent<Rigidbody>().AddForce(myHands.transform.forward * throwForce);
        //    hasItem = false;
        //
        //    dropUI.SetActive(false);
        //}

        if (Input.GetMouseButtonDown(0) && hasItem == true && !settingsUI.activeSelf)
        {
            ObjectIWantToPickup.GetComponent<Rigidbody>().isKinematic = false;
            ObjectIWantToPickup.transform.parent = null;
            ObjectIWantToPickup.GetComponent<Rigidbody>().AddForce(myHands.transform.forward * throwForce);
            hasItem = false;

            dropUI.SetActive(false);
        }

        if (Input.GetMouseButtonDown(0) && !settingsUI.activeSelf)
        {
            dropUI.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Acorn" && !dialogueUI.activeSelf && !settingsUI.activeSelf)
        {
            if (hasItem == false)
            {
                canPickup = true;
                ObjectIWantToPickup = collision.gameObject;
            }

            promptUI.SetActive(true);
        }
        if (collision.gameObject.tag == "Slingshot" && !dialogueUI.activeSelf && !settingsUI.activeSelf)
        {
            if (hasItem == true)
            {
                collision.gameObject.GetComponent<Slingshot>().LoadAcorn();
                hasItem = false;
                Destroy(ObjectIWantToPickup);
                //crosshairUI.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            canPickup = false;
            //promptUI.SetActive(false);
            dropUI.SetActive(false);
        }
        
        canPickup = false;
        promptUI.SetActive(false);
        //dropUI.SetActive(false);
    }
}
