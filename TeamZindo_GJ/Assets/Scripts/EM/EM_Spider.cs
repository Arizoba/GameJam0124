using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EM_Spider : MonoBehaviour
{

    public GameObject floor;
    Vector3 targetpos;

    // Start is called before the first frame update
    void Start()
    {
        // find a random x and z from available coords, y is fixed
        // then check if reached, dist close to location, chose new location

        NewTarget();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, targetpos)<1)
        {
            // need to find new position
            NewTarget();
        }

        // move towards it

        Vector3 directionvector = targetpos - transform.position;

        transform.position = transform.position + directionvector.normalized * 0.05f;

        transform.forward = directionvector;

    }


    void NewTarget()
    {
        float newx = Random.Range(floor.transform.position.x - floor.transform.localScale.x*5, floor.transform.position.x + floor.transform.localScale.x*5);
        float newz = Random.Range(floor.transform.position.z - floor.transform.localScale.z*5, floor.transform.position.z + floor.transform.localScale.z*5);
        targetpos = new Vector3(newx, transform.position.y, newz);
    }
}
