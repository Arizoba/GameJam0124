using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EM_Jumping : MonoBehaviour
{
    // Start is called before the first frame update

    float force_y=0;

    float speed_y=0;


    Vector3 startpos;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= 0) // ground or below
        {
            // need to jump
            force_y = 0;
            speed_y = 6;
        }
        else // in air
        {
            
        }

        // sink down

        force_y -= 6f*Time.deltaTime;

        speed_y += force_y * Time.deltaTime;


        // update position relative to force applied

        transform.position = new Vector3(transform.position.x, transform.position.y + speed_y * Time.deltaTime, transform.position.z);
    }
}
