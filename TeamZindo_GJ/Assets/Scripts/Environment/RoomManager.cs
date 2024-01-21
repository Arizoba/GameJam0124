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
    private List<RoomShape> jointRoomShapes;

    [SerializeField]
    private RoomShape bossRoom;

    [SerializeField]
    private int roomsBeforeBoss = 20;

    [SerializeField]
    private int hardRoomLimit = 20;

    private bool jointFlag = true;

    void Start()
    {
        initialRoom.BlockOff();
        RoomShape lastRoomShape = initialRoom;
        Debug.Log(initialRoom.Entrance.Player);
        lastRoomShape = Generate(lastRoomShape);
    }

    public RoomShape Generate(RoomShape lastRoomShape) {
        RoomShape nextRoomShape;

        if (hardRoomLimit == 0) {
            nextRoomShape = GameObject.Instantiate(bossRoom);
        }

        if (roomsBeforeBoss == 0) {
            roomShapes.Insert(0, bossRoom);
        }
        if (jointFlag) {
            nextRoomShape = GameObject.Instantiate(jointRoomShapes[Random.Range(0, jointRoomShapes.Count)]);
            jointFlag = false;
        }
        else {
            nextRoomShape = GameObject.Instantiate(roomShapes[Random.Range(0, roomShapes.Count)]);
            jointFlag = !jointRoomShapes.Contains(nextRoomShape);
        }
        nextRoomShape.AppendToRoom(lastRoomShape);
        roomsBeforeBoss--;
        return nextRoomShape;
    }

    public void DeleteFirst()
    {
        if (initialRoom.NextRoom != null && initialRoom.NextRoom.NextRoom != null && initialRoom.NextRoom.NextRoom.NextRoom != null) {
            RoomShape tmpRoom = initialRoom.NextRoom;
            Destroy(initialRoom.OverlapCollider.gameObject);
            Destroy(initialRoom.gameObject);
            initialRoom = tmpRoom;
            initialRoom.BlockOff();
        }
    }
    
}
