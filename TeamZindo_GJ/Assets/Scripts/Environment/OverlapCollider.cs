using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverlapCollider : MonoBehaviour
{
    [SerializeField]
    private RoomShape room;

    public RoomShape Room => room;

    void OnTriggerCollision(Collider collider) {
        Debug.Log(collider);
    }
    
}
