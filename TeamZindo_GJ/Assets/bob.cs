using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bob : MonoBehaviour
{

    float keypresscd = 0.5f;
    float lastkeypress;
    Vector3 startpos;
    float returntotime = 0.2f;
    bool hasbob = false;

    float lastbob;
    // Start is called before the first frame update
    void Start()
    {
        lastkeypress = Time.time;
        startpos = transform.position;
        lastbob = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("q") && Time.time-lastkeypress>keypresscd)
        {
            lastkeypress = Time.time;
            transform.position += new Vector3(0, 2, 0);
            lastbob = Time.time;
            hasbob = true;
        }

        if (hasbob && Time.time - lastbob > returntotime)
        {

            transform.position -= new Vector3(0, 2, 0);
            hasbob = false;
        }

    }

}
