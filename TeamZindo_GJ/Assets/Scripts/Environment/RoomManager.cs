using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    [SerializeField]
    private RoomShape initialRoomShape;

    [SerializeField]
    private List<RoomShape> roomShapes;

    void Start()
    {
        RoomShape lastRoomShape = initialRoomShape;
        foreach (RoomShape room in roomShapes) {
            RoomShape nextRoomShape = GameObject.Instantiate(room);
            nextRoomShape.AppendToRoom(lastRoomShape);
            lastRoomShape = nextRoomShape;
        }
    }
    
}
