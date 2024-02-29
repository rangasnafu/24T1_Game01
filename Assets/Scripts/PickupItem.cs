using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
	protected Rigidbody rb;
	public bool canPickup = true;

	private void Start()
	{
		rb = GetComponent<Rigidbody>();
	}
	public virtual void PickUp()
    {
		rb.isKinematic = true;
		Pickup.instance.PickupItem(this);
		canPickup = false;
	}


	public virtual void Drop()
	{
		Drop(Vector3.zero);
	}

	public virtual void Drop(Vector3 force)
    {
		canPickup = true;
		rb.isKinematic = false;
		transform.parent = null;
		GetComponent<Rigidbody>().AddForce(force, ForceMode.Impulse);
	}
}
