using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EM_tracking : MonoBehaviour
{

    public GameObject what_to_track;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(what_to_track.transform);
    }
}
