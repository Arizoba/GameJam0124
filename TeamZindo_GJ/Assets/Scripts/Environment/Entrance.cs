using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entrance : MonoBehaviour
{
    public RoomManager RoomManager;
    public RoomShape Room;

    [SerializeField]
    private GameObject player = null;

    [SerializeField]
    private GameObject door = null;

    private int generationCount = 1;

    private float detectionDistance = 10f;
    private float openDistance = 70f;
    private bool inRange = false;

    public GameObject Player => player;

    public void SetPlayer(GameObject thePlayer) {
        player = thePlayer;
    }

    void Update() {

        float distance = Vector3.Distance(player.transform.position, transform.position);

        if (distance <= openDistance) {
            door.GetComponent<Animator>().SetBool("DoorOpen", true);
        }

        else {
            door.GetComponent<Animator>().SetBool("DoorOpen", false);
        }

        if (distance <= detectionDistance) {
            if (inRange) {
                return;
            }

            inRange = true;

            RoomShape lastRoom = Room;
            int roomsToGenerate = generationCount;

            while (lastRoom.NextRoom != null && roomsToGenerate > 0) {
                lastRoom = lastRoom.NextRoom;
                roomsToGenerate--;
            }

            while (lastRoom != null && roomsToGenerate > 0) {
                lastRoom = RoomManager.Generate(lastRoom);
                roomsToGenerate--;
            }

            RoomManager.DeleteFirst();
        }
        else {
            inRange = false;
        }
    }
    
}
