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
        for (int i=0; i<6; i++) {
            RoomShape nextRoomShape = GameObject.Instantiate(roomShapes[Random.Range(0, roomShapes.Count)]);
            nextRoomShape.AppendToRoom(lastRoomShape);
            lastRoomShape = nextRoomShape;
        }
    }
    
}
