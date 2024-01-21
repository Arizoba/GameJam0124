using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entrance : MonoBehaviour
{
    public RoomManager RoomManager;
    public RoomShape Room;

    [SerializeField]
    public GameObject Player = null;

    [SerializeField]
    private float detectionDistance = 3.0f;

    [SerializeField]
    private int generationCount = 3;

    private bool inRange = false;

    void Update() {
        if (Vector3.Distance(Player.transform.position, transform.position) <= detectionDistance) {
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

            while (roomsToGenerate > 0) {
                lastRoom = RoomManager.Generate(lastRoom);
                roomsToGenerate--;
            }

        }
        else {
            inRange = false;
        }
    }
    
}
