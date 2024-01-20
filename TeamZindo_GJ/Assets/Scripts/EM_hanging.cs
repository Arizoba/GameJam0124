using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EM_hanging : MonoBehaviour
{

    Vector3 startpos;

    // Start is called before the first frame update
    void Start()
    {
        startpos = transform.position;
        //Debug.Log(startpos);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, startpos.y + Mathf.Sin(Time.time),transform.position.z);
    }
}
