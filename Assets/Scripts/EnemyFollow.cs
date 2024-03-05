using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public Transform targetObj;

    public bool wantToFollow;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (wantToFollow)
        {
            transform.position = Vector3.MoveTowards(this.transform.position, targetObj.position, 5 * Time.deltaTime);
            transform.LookAt(targetObj);
            transform.Rotate(transform.eulerAngles + new Vector3(-90, 90, 0));
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            wantToFollow = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            wantToFollow = false;
        }
    }

    public void GnomeDeath()
    {
        Destroy(this.gameObject);
    }
}
