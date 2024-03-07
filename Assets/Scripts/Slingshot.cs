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

    public GameObject acornPrefab;
    public Transform acornSpawnPoint;
    public float shootInterval;
    private float shootTimer;

    public float shootForce = 10f;

    public GameObject optionsUI;

    private bool hasShot = false;

    private void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
        cameraRotationX = pivot.transform.localRotation.eulerAngles.x;
        cameraRotationY = slingshotCamera.transform.localRotation.eulerAngles.y;
    }

    private void Update()
    {
        if (holdingAcorn == false)
        {
            return;
        }

        if (slingshotCamera.activeSelf && !optionsUI.activeSelf)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = -Input.GetAxis("Vertical");
            cameraRotationX += horizontalInput * Time.deltaTime * movementSpeed;
            cameraRotationY += verticalInput * Time.deltaTime * movementSpeed;
            pivot.transform.localRotation = Quaternion.Euler(0, cameraRotationX, 0);
            slingshotCamera.transform.localRotation = Quaternion.Euler(cameraRotationY, 0, 0);
        }

        if (holdingAcorn && Input.GetKeyDown(KeyCode.Escape) && !optionsUI.activeSelf)
        {
            holdingAcorn = false;
            player.EnablePlayer();
            slingshotCamera.SetActive(false);

            hasShot = false;
        }

        UpdateShooting();
    }

    public void LoadAcorn()
    {
        holdingAcorn = true;
        slingshotCamera.SetActive(true);
        player.DisablePlayer();
    }

    private void UpdateShooting()
    {
        shootTimer -= Time.deltaTime;

        if (shootTimer <= 0 && Input.GetKey(KeyCode.Mouse0) && !hasShot && !optionsUI.activeSelf)
        {
            shootTimer = shootInterval;
            ShootAcorn();
        }
    }

    private void ShootAcorn()
    {
        //audioSource.PlayOneShot(shootSound);
        //Instantiate(acornPrefab, acornSpawnPoint.position, acornSpawnPoint.rotation);
        //instantiate means to spawn, quaternion means rotation

        GameObject acorn = Instantiate(acornPrefab, acornSpawnPoint.position, acornSpawnPoint.rotation);

        // Get the Rigidbody component of the instantiated acorn
        Rigidbody acornRigidbody = acorn.GetComponent<Rigidbody>();

        // Check if the Rigidbody component exists
        if (acornRigidbody != null)
        {
            // Apply force to the acorn in the direction of the acornSpawnPoint's forward vector
            acornRigidbody.AddForce(acornSpawnPoint.forward * shootForce, ForceMode.Impulse);
        }

        hasShot = true;
    }
}
