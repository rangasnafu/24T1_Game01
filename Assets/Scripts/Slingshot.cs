using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Slingshot : Interactable
{
    public bool interacting = false;
    public float firePower = 15;
    public GameObject slingshotCamera;
    public PlayerMovement player;
    public float movementSpeed = 1;
    public float cameraRotationX;
    public float cameraRotationY;
    public PickupItem loadedItem;
    public GameObject pivot;
    public Transform loadPoint;


    public void LaunchAcorn()
    {
        loadedItem.Drop(slingshotCamera.transform.forward * firePower);

		Deactivate();

	}
    public void TargetSlingshot()
    {


    }
    private void Update()
    {
        if (interacting == false)
        {
            return;
        }
        float horizontalInput = Input.GetAxisRaw("Mouse X");
        float verticalInput = -Input.GetAxisRaw("Mouse Y");
        cameraRotationX += horizontalInput * Time.deltaTime * movementSpeed;
        cameraRotationY += verticalInput * Time.deltaTime * movementSpeed;
        pivot.transform.localRotation = Quaternion.Euler(0, cameraRotationX, 0);
        slingshotCamera.transform.localRotation = Quaternion.Euler(cameraRotationY, 0, 0);

        if (Input.GetKeyDown(KeyCode.E))
        {
            LaunchAcorn();

		}
    }
    private void Start()
    {
        cameraRotationX = pivot.transform.localRotation.eulerAngles.x;
        cameraRotationY = slingshotCamera.transform.localRotation.eulerAngles.y;
    }

    public override void Enter()
    {
        Pickup player = FindObjectOfType<Pickup>();

        if (player.hasItem)
        {
            loadedItem = player.DropItem();
            loadedItem.transform.SetParent(loadPoint);
            loadedItem.transform.localPosition = Vector3.zero;
        }
    }

    public override bool CanInteract()
    {
        return loadedItem != null;

	}

	public override void Activate()
	{
        interacting = true;
        slingshotCamera.SetActive(true);
        Pickup.instance.Deactivate();
	}

	public override void Deactivate()
	{
		interacting = false;
		slingshotCamera.SetActive(false);
		Pickup.instance.Activate();
	}
}
