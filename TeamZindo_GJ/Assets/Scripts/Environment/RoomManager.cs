using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    [SerializeField]
    private RoomShape initialRoom;

    [SerializeField]
    private List<RoomShape> roomShapes;

    void Start()
    {
        RoomShape lastRoomShape = initialRoom;
        lastRoomShape = Generate(lastRoomShape);
    }

    public RoomShape Generate(RoomShape lastRoomShape) {
        RoomShape nextRoomShape = GameObject.Instantiate(roomShapes[Random.Range(0, roomShapes.Count)]);
        nextRoomShape.AppendToRoom(lastRoomShape);
        return nextRoomShape;
    }
    
}
