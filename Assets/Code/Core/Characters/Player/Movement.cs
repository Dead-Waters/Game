using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody2D player;
    public Animator m_Animator;
    [Space(10)]

    public Transform mainCamera;
    public Camera camera;

    [Header("Player movement")]
    [Space(10)]

    [Range(0, 1000)] public float walkingSpeed = 200;
    [Range(0, 1000)] public float runningSpeed = 250;
    [Range(0, 1000)] public float jumpForce = 500;
    [Space(10)]

    public bool isHurting;
    public bool isDead;
    public bool facingRight = true;
    [HideInInspector] public float dirX;
    [Space(10)]

    [Header("Camera movement")]
    [Space(10)]

    public float visionSizeMin = 3;
    public float visionSizeMax = 10;
    [Range(3, 10)] public float zoom = 10;
    [Space(10)]

    public float followCameraDistance = 3;

    Vector3 localScale;

    void Start()
    {
        m_Animator = gameObject.GetComponent<Animator>();
        localScale = transform.localScale;
    }

    private void Update()
    {
        float wheelValue = Input.GetAxis("Mouse ScrollWheel");

        if (wheelValue != 0)
            AddZoom(wheelValue);

        if (!isDead)
            if (Input.GetKey(KeyCode.LeftShift) && IsGrounded())
                dirX = Input.GetAxisRaw("Horizontal") * runningSpeed;
            else
                dirX = Input.GetAxisRaw("Horizontal") * walkingSpeed;

        SetAnimationState();
    }

    private void FixedUpdate()
    {
        if (!isHurting)
            player.velocity = new Vector2(dirX, player.velocity.y);

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

    void LateUpdate()
    {
        CheckWhereToFace();
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
        RaycastHit2D hit = Physics2D.Raycast(player.position + new Vector2(0, -1.1f), new Vector2(0, -0.1f), 0.1f);
        return hit.collider;
    }


    void GoToDirection(int right)
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            player.velocity = new Vector2(right * runningSpeed * Time.deltaTime, player.velocity.y);
            m_Animator.SetBool("isRunning", true);
            m_Animator.SetBool("isWalking", true);
        }
        else
        {
            player.velocity = new Vector2(right * walkingSpeed * Time.deltaTime, player.velocity.y);
            m_Animator.SetBool("isWalking", true);
            m_Animator.SetBool("isWalking", true);
        }
    }

    void StopMovement()
    {
        player.velocity = new Vector2(0, player.velocity.y);
        m_Animator.SetBool("isWalking", false);
        m_Animator.SetBool("isRunning", false);
    }

    void Jump()
    {

        if (IsGrounded())
        {
            player.velocity = new Vector2(player.velocity.x, jumpForce * Time.deltaTime);
        }
    }

    void CheckWhereToFace()
    {
        if (dirX > 0)
            facingRight = true;
        else if (dirX < 0)
            facingRight = false;

        if (((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0)))
            localScale.x *= -1;

        transform.localScale = localScale;

    }

    void SetAnimationState()
    {
        if (dirX == 0)
        {
            m_Animator.SetBool("isWalking", false);
            m_Animator.SetBool("isRunning", false);
        }

        if (player.velocity.y == 0)
        {
            m_Animator.SetBool("isJumping", false);
            m_Animator.SetBool("isFalling", false);
        }

        if (Mathf.Abs(dirX) == walkingSpeed && player.velocity.y == 0)
            m_Animator.SetBool("isWalking", true);

        if (Mathf.Abs(dirX) == runningSpeed && player.velocity.y == 0)
            m_Animator.SetBool("isRunning", true);
        else
            m_Animator.SetBool("isRunning", false);

        if (player.velocity.y > 0)
            m_Animator.SetBool("isJumping", true);

        if (player.velocity.y < 0)
        {
            m_Animator.SetBool("isJumping", false);
            m_Animator.SetBool("isFalling", true);
        }
    }

    IEnumerator Hurt()
    {
        isHurting = true;
        player.velocity = Vector2.zero;

        if (facingRight)
            player.AddForce(new Vector2(-200f, 200f));
        else
            player.AddForce(new Vector2(200f, 200f));

        yield return new WaitForSeconds(0.5f);

        isHurting = false;
    }
}
