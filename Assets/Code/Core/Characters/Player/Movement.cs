using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Transform mainCamera;
    public Rigidbody2D player;
    public float speed = 100;
    public float jumpForce = 500;

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.E))
            GoToDirection(1);
        else if (Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.A))
            GoToDirection(-1);
        else
            StopMovement();

        if (Input.GetKey(KeyCode.Space))
            Jump();

        mainCamera.position = new Vector3(player.position.x, player.position.y, -5);
    }

    bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(player.position + new Vector2(0, -1.1f), new Vector2(0, -0.1f),0.1f);
        return hit.collider;
    }

    void GoToDirection(int right)
    {
        player.velocity = new Vector2(right * speed * Time.deltaTime, player.velocity.y);
    }

    void StopMovement()
    {
        player.velocity = new Vector2(0, player.velocity.y);
    }

    void Jump()
    {

        if (IsGrounded())
        {
            player.velocity = new Vector2(player.velocity.x, jumpForce * Time.deltaTime);
        }
    }
}
