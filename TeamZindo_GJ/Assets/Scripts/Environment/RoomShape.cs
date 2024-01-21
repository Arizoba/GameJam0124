using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomShape : MonoBehaviour
{
    [SerializeField]
    private Entrance entrance;

    [SerializeField]
    private GameObject exit;

    [SerializeField]
    private OverlapCollider overlapCollider;

    [SerializeField]
    private GameObject door;

    public Entrance Entrance => entrance;
    public GameObject Exit => exit;

    public RoomShape NextRoom = null;

    public OverlapCollider OverlapCollider => overlapCollider;

    void Start() {
        door.GetComponent<BoxCollider>().enabled = false;
    }

    public void BlockOff() {
        door.GetComponent<BoxCollider>().enabled = true;
    }

    public void AppendToRoom(RoomShape room) {
        entrance.RoomManager = room.Entrance.RoomManager;
        entrance.SetPlayer(room.Entrance.Player);
        room.NextRoom = this;

        transform.localScale = room.transform.lossyScale;

        transform.rotation = Quaternion.Inverse(entrance.transform.rotation) * room.Exit.transform.rotation;

        transform.position = room.Exit.transform.position - entrance.transform.position - Vector3.up * 0.2f;

        BoxCollider boxCollider = (BoxCollider) (overlapCollider.GetComponent<BoxCollider>());
        Vector3 worldCenter = boxCollider.transform.TransformPoint(boxCollider.center);
        Vector3 worldHalfExtents = boxCollider.transform.TransformVector(boxCollider.size * 0.5f);

        Collider[] otherColliders = Physics.OverlapBox(worldCenter, worldHalfExtents, Quaternion.identity, LayerMask.GetMask("Environment"));
        foreach (Collider collider in otherColliders) {
            OverlapCollider otherCollider = collider.gameObject.GetComponent<OverlapCollider>();
            if (otherCollider == null) {
                continue;
            }
            RoomShape collidedRoom = otherCollider.Room;
            if (collidedRoom != this && collidedRoom != room) {
                Destroy(collidedRoom.gameObject);
                Destroy(otherCollider.gameObject);
            }
        }
    }

    void Update()
    {
        Debug.DrawRay(exit.transform.position + Vector3.up, -exit.transform.forward * 5, Color.red);
        Debug.DrawRay(entrance.transform.position, entrance.transform.forward * 5, Color.green);

        BoxCollider boxCollider = (BoxCollider) overlapCollider.GetComponent<BoxCollider>();
        Vector3 worldCenter = boxCollider.transform.TransformPoint(boxCollider.center);
        Vector3 worldHalfExtents = boxCollider.transform.TransformVector(boxCollider.size * 0.5f);
        Debug.DrawRay(worldCenter, worldHalfExtents.x * Vector3.right, Color.yellow);
        Debug.DrawRay(worldCenter, worldHalfExtents.x * -Vector3.right, Color.yellow);
        Debug.DrawRay(worldCenter, worldHalfExtents.y * Vector3.up, Color.yellow);
        Debug.DrawRay(worldCenter, worldHalfExtents.y * -Vector3.up, Color.yellow);
        Debug.DrawRay(worldCenter, worldHalfExtents.z * Vector3.forward, Color.yellow);
        Debug.DrawRay(worldCenter, worldHalfExtents.z * -Vector3.forward, Color.yellow);
    }

}
