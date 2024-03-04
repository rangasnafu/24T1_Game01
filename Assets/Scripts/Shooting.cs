using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject acornPrefab;
    public Transform acornSpawnPoint;
    public float shootInterval;
    private float shootTimer;

    public GameObject slingshotCamera;
    //private bool hasShot = false;

    // Start is called before the first frame update
    void Start()
    {
        //audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        UpdateShooting();

    }

    private void UpdateShooting()
    {
        shootTimer -= Time.deltaTime;

        if (shootTimer <= 0 && Input.GetKey(KeyCode.Mouse0) && slingshotCamera.activeSelf)
        {
            //shootTimer = shootInterval;
            ShootBullet();

        }

        //if (!hasShot && Input.GetKey(KeyCode.Mouse0) && slingshotCamera.activeSelf) // Check for KeyDown instead of GetKey
        //{
        //    ShootBullet();
        //    hasShot = true; // Set the flag to true to indicate that shooting has occurred
        //}
    }

    private void ShootBullet()
    {
        //audioSource.PlayOneShot(shootSound);
        Instantiate(acornPrefab, acornSpawnPoint.position, acornSpawnPoint.rotation);
        //instantiate means to spawn, quaternion means rotation
    }
}
