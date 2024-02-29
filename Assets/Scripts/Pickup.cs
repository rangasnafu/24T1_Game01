using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public static Pickup instance;
    public GameObject myHands;

    public PickupItem heldItem;
    public PickupItem itemIWantToPickUp;
    public Interactable interactItem;
    public bool hasItem => heldItem != null;

    private float throwForce = 6;
    Vector3 objectPos;
    public float distance;

    public GameObject promptUI;
    public GameObject dropUI;

    public GameObject dialogueUI;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            if (itemIWantToPickUp != null)
            {
                itemIWantToPickUp.PickUp();
            }
            else if(interactItem != null)
            {
                interactItem.Activate();
			}

            dropUI.SetActive(false);
        }

        if (Input.GetKeyDown("f"))
        {
            if (hasItem)
            {
                heldItem.Drop(transform.forward * throwForce);
                heldItem = null;
				dropUI.SetActive(false);
			}
        }
    }
    public void PickupItem(PickupItem item)
    {
        heldItem = item;
		item.transform.parent = myHands.transform;
		item.transform.localPosition = Vector3.zero;
    }

    public PickupItem DropItem()
    {
        PickupItem item = heldItem;
		heldItem = null;
        return item;
	}

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.GetComponent<PickupItem>()!=null)
        {
            if(!collision.gameObject.GetComponent<PickupItem>().canPickup)
            {
                return;
            }
            itemIWantToPickUp = collision.gameObject.GetComponent<PickupItem>();
            promptUI.SetActive(true);
        }
        if(collision.gameObject.GetComponent<Interactable>() != null)
        {
            interactItem = collision.gameObject.GetComponent<Interactable>();
			interactItem.Enter();
			promptUI.SetActive(true);
		}
    }

    private void OnTriggerExit(Collider other)
    {
		if (other.gameObject.GetComponent<PickupItem>() != null)
		{
			itemIWantToPickUp = null;
			promptUI.SetActive(false);
		}
		if (other.gameObject.GetComponent<Interactable>() != null)
		{
			interactItem.Exit();
			interactItem = null;
			promptUI.SetActive(false);
		}
    }

	public void Activate()
    {
        gameObject.SetActive(true);
    }

    public void Deactivate()
    {
		gameObject.SetActive(false);
	}
}
