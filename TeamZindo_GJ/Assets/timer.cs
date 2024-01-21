using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timer : MonoBehaviour
{

    float spawn;
    float life = 5f;
    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        spawn = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - spawn > life)
        {
            Destroy(gameObject);
        }
    }
}
