using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : MonoBehaviour
{
    public GameObject completedObjective;
    public GameObject nextObjective;
    public GameObject nextObjectiveCollider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            completedObjective.SetActive(false);
            nextObjective.SetActive(true);
            nextObjectiveCollider.SetActive(true);
            Destroy(this.gameObject);
        }
    }
}
