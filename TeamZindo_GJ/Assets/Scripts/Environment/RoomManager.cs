using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    [SerializeField]
    private RoomShape initialRoomShape;

    [SerializeField]
    private List<RoomShape> roomShapes;

    [SerializeField]
    private int generateCount;

    void Start()
    {
        RoomShape lastRoomShape = initialRoomShape;
        for (int i=0; i<generateCount; i++) {
            RoomShape nextRoomShape = GameObject.Instantiate(roomShapes[Random.Range(0, roomShapes.Count)]);
            nextRoomShape.AppendToRoom(lastRoomShape);
            lastRoomShape = nextRoomShape;
        }
    }
    
}
