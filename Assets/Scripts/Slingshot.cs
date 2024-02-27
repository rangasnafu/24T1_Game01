using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Slingshot : MonoBehaviour
{
    public bool holdingAcorn = false;
    public GameObject slingshotCamera;
    public PlayerMovement player;
    public float movementSpeed = 1;
    public float cameraRotationX;
    public float cameraRotationY;
    public GameObject pivot;

    public void LoadAcorn()
    {
        holdingAcorn = true;
        slingshotCamera.SetActive(true);
        player.DisablePlayer();
    }
    public void LaunchAcorn()
    {

    }
    public void TargetSlingshot()
    {

    }
    private void Update()
    {
        if (holdingAcorn == false)
        {
            return;
        }
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = -Input.GetAxis("Vertical");
        cameraRotationX += horizontalInput * Time.deltaTime*movementSpeed;
        cameraRotationY += verticalInput * Time.deltaTime * movementSpeed;
        pivot.transform.localRotation = Quaternion.Euler(0, cameraRotationX, 0);
        slingshotCamera.transform.localRotation = Quaternion.Euler(cameraRotationY, 0, 0);

        if (holdingAcorn && Input.GetKeyDown(KeyCode.Escape))
        {
            holdingAcorn = false;
            player.EnablePlayer();
            slingshotCamera.SetActive(false);
        }
        
    }
    private void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
        cameraRotationX = pivot.transform.localRotation.eulerAngles.x;
        cameraRotationY = slingshotCamera.transform.localRotation.eulerAngles.y;
    }
}
