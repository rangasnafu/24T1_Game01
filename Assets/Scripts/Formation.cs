using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Formation : MonoBehaviour
{
    //public Transform formationTarget;
    //public GameObject firefly;
    public List<GameObject> formationTargets = new List<GameObject>();
    public List<GameObject> fireflies = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < formationTargets.Count; i++)
        {
            fireflies[i].transform.position = Vector3.MoveTowards(fireflies[i].transform.position, formationTargets[i].transform.position, 1 * Time.deltaTime);
        }
        
        //i says for each increase in element of the fireflies it'll move that objects position to the equivalent element of the formation target
    }
}
