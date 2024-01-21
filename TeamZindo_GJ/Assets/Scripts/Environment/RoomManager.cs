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
    private int roomBeforeCheck = 10;

    [SerializeField]
    private int hardRoomLimit = 300;

    [SerializeField]
    private Memories memories;

    private bool jointFlag = true;

    private int memoriesLeft = 3;
    private int memoryIndex = 1;

    public int roomsLeft;

    void Start()
    {
        initialRoom.BlockOff();
        RoomShape lastRoomShape = initialRoom;
        lastRoomShape = Generate(lastRoomShape);
        roomsLeft = roomBeforeCheck;
    }

    public RoomShape Generate(RoomShape lastRoomShape) {
        RoomShape nextRoomShape;

        if (roomsLeft == 0) {
            if (memoriesLeft <= 0) {
                roomShapes.Insert(0, bossRoom);
            }
            else {
                memories.StartMemory(memoryIndex);
                memoriesLeft--;
                memoryIndex++;
                roomsLeft = roomBeforeCheck;
            }
        }

        if (hardRoomLimit == 0) {
            nextRoomShape = GameObject.Instantiate(bossRoom);
        }
        else if (jointFlag) {
            nextRoomShape = GameObject.Instantiate(jointRoomShapes[Random.Range(0, jointRoomShapes.Count)]);
            jointFlag = false;
        }
        else {
            nextRoomShape = GameObject.Instantiate(roomShapes[Random.Range(0, roomShapes.Count)]);
            jointFlag = !jointRoomShapes.Contains(nextRoomShape);
        }

        nextRoomShape.AppendToRoom(lastRoomShape);
        roomsLeft--;
        hardRoomLimit--;
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
