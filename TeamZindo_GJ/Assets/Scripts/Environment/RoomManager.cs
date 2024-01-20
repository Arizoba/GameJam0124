using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    [SerializeField]
    private RoomShape initialRoom;

    [SerializeField]
    private List<RoomShape> roomShapes;

    [SerializeField]
    private int generateCount;

    void Start()
    {
        RoomShape lastRoomShape = initialRoom;
        for (int i=0; i<generateCount; i++) {
            lastRoomShape = Generate(lastRoomShape);
        }
    }

    public RoomShape Generate(RoomShape lastRoomShape) {
        RoomShape nextRoomShape = GameObject.Instantiate(roomShapes[Random.Range(0, roomShapes.Count)]);
        nextRoomShape.AppendToRoom(lastRoomShape);
        lastRoomShape.Exit.SetActive(false);
        return nextRoomShape;
    }
    
}
