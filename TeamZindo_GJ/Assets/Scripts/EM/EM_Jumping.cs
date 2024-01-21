using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EM_Jumping : MonoBehaviour
{
    // Start is called before the first frame update

    float force_y=0;

    float speed_y=0;


    private float starty;

    Vector3 startpos;
    void Start()
    {
        starty = transform.position.y;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= starty-2) // ground or below
        {
            // need to jump
            force_y = 0;
            speed_y = 3;
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
