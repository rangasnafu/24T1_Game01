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

    // Start is called before the first frame update
    void Start()
    {
        canPickup = false;
        hasItem = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (canPickup == true && !dialogueUI.activeSelf)
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
        if (Input.GetKeyDown("f") && hasItem == true)
        {
            ObjectIWantToPickup.GetComponent<Rigidbody>().isKinematic = false;
            ObjectIWantToPickup.transform.parent = null;
            ObjectIWantToPickup.GetComponent<Rigidbody>().AddForce(myHands.transform.forward * throwForce);
            hasItem = false;

            dropUI.SetActive(false);
        }

        if (Input.GetKeyDown("t") && hasItem == true)
        {
            ObjectIWantToPickup.GetComponent<Rigidbody>().isKinematic = false;
            ObjectIWantToPickup.transform.parent = null;
            ObjectIWantToPickup.GetComponent<Rigidbody>().AddForce(myHands.transform.forward * throwForce);
            hasItem = false;

            dropUI.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Acorn" && !dialogueUI.activeSelf)
        {
            if (hasItem == false)
            {
                canPickup = true;
                ObjectIWantToPickup = collision.gameObject;
            }

            promptUI.SetActive(true);
        }
        if (collision.gameObject.tag == "Slingshot" && !dialogueUI.activeSelf)
        {
            if (hasItem == true)
            {
                collision.gameObject.GetComponent<Slingshot>().LoadAcorn();
                hasItem = false;
                Destroy(ObjectIWantToPickup);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        canPickup = false;
        promptUI.SetActive(false);
        dropUI.SetActive(false);
    }
}
