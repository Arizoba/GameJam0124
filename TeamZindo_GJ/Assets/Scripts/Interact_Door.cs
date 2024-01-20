using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact_Door : MonoBehaviour
{

    public GameObject Text;
    public GameObject Player;


    public Material other_material;
    public GameObject Interactable_text;

    // need text to appear if player is close and is looking
    // need to raycast from player? (looking direction)
    // need reference to player



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
        if (Physics.Raycast(ray, out hit, 3))
        {
            // Check if the hit object is the target

            if (hit.transform.CompareTag("Door") )
            {
                Interactable_text.SetActive(true);

                if (Input.GetKey("e"))
                {
                    // paint door black as an example
                    GetComponent<MeshRenderer>().material = other_material;

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

