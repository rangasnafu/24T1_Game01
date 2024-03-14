using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public GameObject gate;
    public Quaternion rotationAmount;
    public float speedVariable;

    public bool gateIsOpening = false;

    private float _rotationSpeed = 5f;

    private Quaternion _targetRot;

    public bool gateIsOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        _targetRot = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        //if (gateIsOpening == true && gate.transform.rotation.y <= 87)
        //{
        //    gate.transform.Rotate(Vector3.up * rotationAmount.y * Time.deltaTime);
        //}
        //else
        //{
        //    gate.transform.Rotate(Vector3.up * -rotationAmount.y * Time.deltaTime);
        //}

        if (gateIsOpening == true)
        {
            _targetRot = rotationAmount;
            //If you want to rotate each time the mouse is clicked
            //_targetRot *= Quaternion.AngleAxis(-90, transform.forward);
        }
        else
        {
            _targetRot = Quaternion.identity;
            //If you want to rotate each time the mouse is clicked
            //_targetRot *= Quaternion.AngleAxis(90, transform.forward);
        }

        gate.transform.rotation = Quaternion.Lerp(gate.transform.rotation, _targetRot, _rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Acorn"))
        {
            //Debug.Log("wooooo");
            //gate.transform.Rotate(transform.eulerAngles + -rotationAmount);

            gateIsOpening = true;
            gateIsOpen = true;

            Invoke(nameof(DeleteTarget), 0.2f);
        }
    }

    private void DeleteTarget()
    {
        Destroy(this.gameObject);
    }
}