using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rsnew : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;
    [SerializeField] private bool isGrounded;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float gravity;
    [SerializeField] private float jumpHeight;
    public float m_FallSpeed = 0.7f;

    private Vector3 moveDirection;
    private Vector3 moveDirectionX;
    private Vector3 velocity;

    private CharacterController controller;
    private Rigidbody rb;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        isGrounded = Physics.CheckSphere(transform.position, groundCheckDistance, groundMask);
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float moveZ = Input.GetAxis("Vertical");
        float moveX = Input.GetAxis("Horizontal");

        moveDirection = new Vector3(0, 0, moveZ);
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirectionX = new Vector3(moveX, 0, 0);
        moveDirectionX = transform.TransformDirection(moveDirectionX);

        if (isGrounded)
        {
            if (moveDirection != Vector3.zero && !Input.GetKey("left shift"))
            {
                Walk();
            }
            else if (moveDirection != Vector3.zero && Input.GetKey("left shift"))
            {
                Sprint();
            }
            else if (moveDirection == Vector3.zero)
            {
                Idle();
            }
            if (moveDirectionX != Vector3.zero && !Input.GetKey("left shift"))
            {
                Walk();
            }
            else if (moveDirectionX != Vector3.zero && Input.GetKey("left shift"))
            {
                Sprint();
            }
            else if (moveDirectionX == Vector3.zero)
            {
                Idle();
            }

            moveDirection *= moveSpeed;
            moveDirectionX *= moveSpeed;

            if (Input.GetKeyDown("space"))
            {
                Jump();
            }
        }
        if (Input.GetKey("space") && rb.velocity.y < 0f && Mathf.Abs(rb.velocity.y) > m_FallSpeed)
        {
            Glide();
        }




        controller.Move(moveDirection * Time.deltaTime);
        controller.Move(moveDirectionX * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private void Idle()
    {
        anim.SetFloat("Speed", 0, 0.5f, Time.deltaTime);
    }

    private void Walk()
    {
        moveSpeed = walkSpeed;
        anim.SetFloat("Speed", 0.5f, 0.05f, Time.deltaTime);
    }

    private void Sprint()
    {
        moveSpeed = runSpeed;
        anim.SetFloat("Speed", 1f, 0.05f, Time.deltaTime);
    }

    private void Jump()
    {
        velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        anim.SetTrigger("Jump");
    }
    private void Glide()
    {
        rb.velocity = new Vector3(rb.velocity.x, Mathf.Sign(rb.velocity.y) * m_FallSpeed, rb.velocity.z);//falling with slope depending on the falling direction
        anim.SetTrigger("Glide");
    }
}
