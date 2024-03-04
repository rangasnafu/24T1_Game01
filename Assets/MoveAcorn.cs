using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAcorn : MonoBehaviour
{
    public float movementSpeed = 10f;
    public Camera acornCamera; // Reference to the separate camera

    void Update()
    {
        // Activate the separate camera if it's inactive
        if (!acornCamera.gameObject.activeSelf)
        {
            acornCamera.gameObject.SetActive(true);
        }

        // Calculate the direction from the acorn's position to the mouse position using the separate camera
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = acornCamera.transform.position.y; // Set the z-coordinate to the distance from the camera
        Vector3 targetPosition = acornCamera.ScreenToWorldPoint(mousePosition);
        Vector3 direction = (targetPosition - transform.position).normalized;

        // Rotate the acorn to face the direction
        transform.LookAt(targetPosition);

        // Move the acorn in the direction
        transform.Translate(direction * movementSpeed * Time.deltaTime, Space.World);
    }

    // Destroy the acorn when it collides with the Bullet Destroyer
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Acorn collided with Enemy");
            Destroy(gameObject);
        }
    }
}
