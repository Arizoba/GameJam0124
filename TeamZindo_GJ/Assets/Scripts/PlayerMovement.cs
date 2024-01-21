using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;

    [SerializeField]
    private float playerSpeed = 2.0f;

    [SerializeField]
    private float gravityValue = -9.81f;

    [SerializeField]
    private Transform orientation;

    public Transform Anchor;

    private Rigidbody rb;

    private bool inSpace = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();
    }

    public void SetGravity(float gravity) {
        gravityValue = gravity;
        inSpace = true;
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }
        
        Vector3 move = Input.GetAxis("Horizontal") * orientation.right + Input.GetAxis("Vertical") * orientation.forward;

        if (inSpace) {
            move = transform.forward * 0.01f;
        }
        controller.Move(move * Time.deltaTime * playerSpeed);

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}