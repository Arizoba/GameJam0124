using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entrance : MonoBehaviour
{
    public RoomManager RoomManager;
    public RoomShape Room;

    void OnCollisionEnter(Collision collision) {
        Debug.Log(collision.collider.gameObject);

        RoomShape lastRoom = Room;
        int roomsToGenerate = 3;

        while (lastRoom.NextRoom != null && roomsToGenerate > 0) {
            lastRoom = lastRoom.NextRoom;
            roomsToGenerate--;
        }

        while (roomsToGenerate > 0) {
            lastRoom = RoomManager.Generate(lastRoom);
            roomsToGenerate--;
        }

        gameObject.SetActive(false);
    }
    
}
