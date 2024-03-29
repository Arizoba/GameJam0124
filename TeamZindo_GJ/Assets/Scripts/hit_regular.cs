using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class hit_regular : MonoBehaviour
{
    [SerializeField]
    private int health = 1;

    [SerializeField]
    private bool isBoss = false;

    float hit_delay = 0.5f;
    float last_hit_time;
    float color_restore;


    // need to detect hit from player (similar to door)
    // if input is left mouse then start taking tic damage

    public GameObject Player;

    public Material other_material;

    Material mycolor;



    // Start is called before the first frame update
    void Start()
    {
        last_hit_time = Time.time;
        color_restore = Time.time;
        mycolor = GetComponent<MeshRenderer>().material;

        // EXPERIMENTAL
        if (Player == null)
        {
            Player = GameObject.Find("PlayerCam");

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - color_restore > 0.1)
        {
            GetComponent<MeshRenderer>().material = mycolor;

        }




        if (health <= 0)
        {
            transform.parent.gameObject.SetActive(false);
            //transform.gameObject.SetActive(false);

            if (isBoss) {
                SceneManager.LoadScene("End");
            }
        }

        Vector3 direction = Player.transform.forward;
        Ray ray = new Ray(Player.transform.position, direction.normalized);
        RaycastHit hit;

        //Debug.DrawRay(Player.transform.position, direction.normalized, Color.red);


        // Perform the raycast
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            // Check if the hit object is the target
            //Debug.Log("Hit");


            if (hit.transform.CompareTag("Enemy") && hit.transform.gameObject == transform.gameObject)
            {

                if (Input.GetKeyDown("q") || Input.GetMouseButtonDown(0))
                {
                    // tik damage, need to have delay like half second?

                    if (Time.time - last_hit_time > hit_delay)
                    {
                        health -= 1;
                        last_hit_time = Time.time;
                        color_restore = Time.time;
                        GetComponent<MeshRenderer>().material = other_material;

                    }
                }
            }
        }
    }
}
