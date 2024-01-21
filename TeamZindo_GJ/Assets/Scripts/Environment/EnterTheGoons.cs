using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterTheGoons : MonoBehaviour
{
    public GameObject[] spawnlocations;
    public GameObject[] candidates;  


    // Start is called before the first frame update
    void Start()
    {
        int itemsToSpawn = Random.Range(0, spawnlocations.Length);

        for (int i = 0;  i < itemsToSpawn;  i++)
        {
            // need to spawn random item at random platform

            // object, position, parent
            GameObject bruh = Instantiate(candidates[Random.Range(0, candidates.Length)], spawnlocations[Random.Range(0, spawnlocations.Length)].transform.position + new Vector3(0, 2, 0), Quaternion.identity, transform) ;

            CheckForAssigned(bruh);

        }
    }


    void CheckForAssigned(GameObject thing)
    {
        Component bruh;

        bruh = thing.GetComponent<EM_tracking>();

        if (bruh != null)
        {
            // mwans need to assign play location
            thing.GetComponent<EM_tracking>().what_to_track = GameObject.Find("Player");


        }

        bruh = thing.GetComponent<hit_regular>();

        if (bruh != null)
        {
            // mwans need to assign playerCam

            thing.GetComponent<hit_regular>().Player = GameObject.Find("PlayerCam");

        }

        bruh = thing.GetComponent<Interact_Tv>();

        if (bruh != null)
        {
            // mwans need to assign playerCam

            thing.GetComponent<Interact_Tv>().Player = GameObject.Find("PlayerCam");

        }






        //then do for each child
        foreach (Transform child in thing.transform)
        {
            CheckForAssigned(child.gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
