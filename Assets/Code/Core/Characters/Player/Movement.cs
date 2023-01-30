using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Transform mainCamera;
    public Camera camera;
    public Rigidbody2D player;
    public Animator m_Animator;
    public float speed = 100;
    public float jumpForce = 500;
    public float visionSizeMin = 3;
    public float visionSizeMax = 5;
    public float followCameraDistance = 3;
    public float zoom = 3;

    void Start()
    {
        m_Animator = gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        float wheelValue = Input.GetAxis("Mouse ScrollWheel");

        if (wheelValue != 0)
            AddZoom(wheelValue);
    }

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

        CameraFollow2DPlayer();
    }

    void CameraFollow2DPlayer()
    {
        float distanceToCamera = player.position.x - mainCamera.position.x;
        Vector3 cameraPosition = mainCamera.position;
        cameraPosition.y = player.position.y;

        if (distanceToCamera > followCameraDistance)
            cameraPosition.x = player.position.x - followCameraDistance;
        else if (distanceToCamera < -followCameraDistance)
            cameraPosition.x = player.position.x + followCameraDistance;

        mainCamera.position = cameraPosition;
        
    }

    void AddZoom(float zoomToAdd)
    {
        zoom += zoomToAdd; 
        zoom = Lerp(visionSizeMin, visionSizeMax, zoom);
        camera.orthographicSize = zoom;
    }

    T Lerp<T>(T min, T max, T value) where T : System.IComparable<T>
    {
        if (value.CompareTo(min) < 0)
            value = min;
        else if (value.CompareTo(max) > 0)
            value = max;
        return value;
    } 

    public bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(player.position + new Vector2(0, -1.1f), new Vector2(0, -0.1f),0.1f);
        return hit.collider;
    }


    void GoToDirection(int right)
    {
        player.velocity = new Vector2(right * speed * Time.deltaTime, player.velocity.y);
        m_Animator.SetBool("Running", true);
    }

    void StopMovement()
    {
        player.velocity = new Vector2(0, player.velocity.y);
        m_Animator.SetBool("Running", false);
    }

    void Jump()
    {

        if (IsGrounded())
        {
            player.velocity = new Vector2(player.velocity.x, jumpForce * Time.deltaTime);
        }
    }


}
