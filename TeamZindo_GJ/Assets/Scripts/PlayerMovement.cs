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

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();
    }

    public void SetGravity(float gravity) {
        gravityValue = gravity;

        controller.enabled = false;

        Vector3 force = Vector3.Normalize(playerVelocity) * 0.01f;
        GetComponent<Rigidbody>().AddForce(force);
    }

    void Update()
    {
        if (controller.enabled) {
            groundedPlayer = controller.isGrounded;
            if (groundedPlayer && playerVelocity.y < 0)
            {
                playerVelocity.y = 0f;
            }

            Vector3 move = Input.GetAxis("Horizontal") * orientation.right + Input.GetAxis("Vertical") * orientation.forward;
            controller.Move(move * Time.deltaTime * playerSpeed);

            playerVelocity.y += gravityValue * Time.deltaTime;
            controller.Move(playerVelocity * Time.deltaTime);
        }

        else {
            Vector3 move = Input.GetAxis("Horizontal") * orientation.right + Input.GetAxis("Vertical") * orientation.forward;
            rb.AddForce(move * Time.deltaTime);
        }
    }
}