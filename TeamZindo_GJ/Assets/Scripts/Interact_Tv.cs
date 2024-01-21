using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact_Tv : MonoBehaviour
{


    public GameObject Player;


    public Material other_material;
    public GameObject Interactable_text;

    public GameObject DialogueBoxObject;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = Player.transform.forward;
        Ray ray = new Ray(Player.transform.position, direction.normalized);
        RaycastHit hit;

        // Perform the raycast
        if (Physics.Raycast(ray, out hit, 10))
        {
            // Check if the hit object is the target

            if (hit.transform.CompareTag("Tv") && hit.transform.gameObject == transform.gameObject)
            {
                Interactable_text.SetActive(true);

                if (Input.GetKey("e"))
                {
                    // paint door black as an example
                    GetComponent<MeshRenderer>().material = other_material;
                    DialogueBoxObject.SetActive(true);


                    // would trigger story? dialogue?


                }
            }
            else
            {
                Interactable_text.SetActive(false);

            }
        }
        else
        {
            Interactable_text.SetActive(false);

        }
    }
}

