using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomShape : MonoBehaviour
{
    [SerializeField]
    private GameObject entrance;

    [SerializeField]
    private GameObject exit;

    public GameObject Entrance => entrance;
    public GameObject Exit => exit;

    public RoomShape LastRoom;

    public bool Deletable = false;

    public void AppendToRoom(RoomShape room) {
        transform.rotation = Quaternion.FromToRotation(entrance.transform.right, room.Exit.transform.right);
        transform.position += room.Exit.transform.position - entrance.transform.position;

        BoxCollider boxCollider = (BoxCollider) GetComponent<BoxCollider>();
        Vector3 worldCenter = boxCollider.transform.TransformPoint(boxCollider.center);
        Vector3 worldHalfExtents = boxCollider.transform.TransformVector(boxCollider.size * 0.5f) - new Vector3(1,1,1);

        Collider[] hitColliders = Physics.OverlapBox(worldCenter, worldHalfExtents, Quaternion.identity, LayerMask.GetMask("Environment"));
        foreach (Collider collider in hitColliders) {
            if (collider.gameObject != this && collider.gameObject != room) {
                collider.gameObject.SetActive(false);
            }
        }
    }

    void Update()
    {
        Debug.DrawRay(exit.transform.position + Vector3.up * 1, -exit.transform.right * 5, Color.red);
        Debug.DrawRay(entrance.transform.position, entrance.transform.right * 5, Color.green);

        BoxCollider boxCollider = (BoxCollider) GetComponent<BoxCollider>();
        Vector3 worldCenter = boxCollider.transform.TransformPoint(boxCollider.center);
        Vector3 worldHalfExtents = boxCollider.transform.TransformVector(boxCollider.size * 0.5f) - new Vector3(1,1,1);
        Debug.DrawRay(worldCenter, worldHalfExtents.x * Vector3.right, Color.yellow);
        Debug.DrawRay(worldCenter, worldHalfExtents.x * -Vector3.right, Color.yellow);
        Debug.DrawRay(worldCenter, worldHalfExtents.y * Vector3.up, Color.yellow);
        Debug.DrawRay(worldCenter, worldHalfExtents.y * -Vector3.up, Color.yellow);
        Debug.DrawRay(worldCenter, worldHalfExtents.z * Vector3.forward, Color.yellow);
        Debug.DrawRay(worldCenter, worldHalfExtents.z * -Vector3.forward, Color.yellow);
    }

}
