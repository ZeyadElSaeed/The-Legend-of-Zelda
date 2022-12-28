using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;
    private Vector3 moveDirection;
    private Vector3 moveDirectionX;
    [SerializeField] private Vector3 velocity;
    [Header("Jumping")]
<<<<<<< HEAD
    
=======

>>>>>>> Team-link-dev
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private LayerMask walkOnTopMask;
    [SerializeField] private float gravity;
    [SerializeField] private float jumpHeight;

    [Header("Climbing")]
    public float climbSpeed;
    public float maxClimbTime;

<<<<<<< HEAD
    
=======

>>>>>>> Team-link-dev
    [Header("Detection")]
    [SerializeField] private bool isGrounded;
    [SerializeField] private bool climbing;
    [SerializeField] private bool attached;
    public float detectionLength;
    public float sphereCastRadius;
    public float maxWallLookAngle;
    private float wallLookAngle;
    private RaycastHit frontWallHit;
    private bool wallFront;



<<<<<<< HEAD


=======
>>>>>>> Team-link-dev
    [Header("References")]
    [SerializeField] private Transform orientation;
    [SerializeField] private LayerMask climbMask;
    private CharacterController controller;
    private Rigidbody rb;
    private Animator anim;


<<<<<<< HEAD
    

=======
    private float initialPosition;
    private float unitsCount;
    private bool isGliding;
    private bool isDead;
    private bool isAttacking;

    private AudioManager audioManager;
>>>>>>> Team-link-dev

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
<<<<<<< HEAD
    }
=======
        initialPosition = transform.position.y;
        isGliding = false;
        isDead = false;
        audioManager = FindObjectOfType<AudioManager>();
        isAttacking = false;
}
>>>>>>> Team-link-dev

    // Update is called once per frame
    void Update()
    {
<<<<<<< HEAD
        Move();
        WallCheck();
        StateMachine();
=======
        if ( !isAttacking)
        {
            if (!GetComponent<GameManagerBridge>().paused() && !isDead)
            {
                Move();
                WallCheck();
                StateMachine();
            }
            else if (isDead)
            {
                controller.Move(Vector3.zero);
            }
        }
        else
        {
            controller.Move(Vector3.zero);
        }
>>>>>>> Team-link-dev
    }

    private void Move()
    {
        isGrounded = Physics.CheckSphere(transform.position, groundCheckDistance, walkOnTopMask);
<<<<<<< HEAD
        if(isGrounded && velocity.y < 0)
=======
        if (isGrounded && velocity.y < 0)
>>>>>>> Team-link-dev
        {
            velocity.y = -2f;
        }

        float moveZ = Input.GetAxis("Vertical");
        float moveX = Input.GetAxis("Horizontal");

        moveDirection = new Vector3(0, 0, moveZ);
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirectionX = new Vector3(moveX, 0, 0);
        moveDirectionX = transform.TransformDirection(moveDirectionX);

<<<<<<< HEAD
        if (isGrounded)
        {            
            if (moveDirection != Vector3.zero && !Input.GetKey("left shift"))
            {
=======
        if (!isGrounded)
        {
            //Debug.Log(velocity.y);
            if (isGliding)
            {
                unitsCount = 0;
                initialPosition = transform.position.y;
            }
            else
            {
                unitsCount = unitsCount + (initialPosition - transform.position.y);
                //Debug.Log(unitsCount);
                initialPosition = transform.position.y;
            }
        }
        
        if (!isDead &&  unitsCount >= 10 && isGrounded)
        {
            this.GetComponent<HealthSystem>().TakeDamage(100);
            if(this.GetComponent<HealthSystem>().healthPoints <=0)
                isDead = true;
            unitsCount = 0;
        }

        if (isGrounded)
        {
            if (moveDirection != Vector3.zero && !Input.GetKey("left shift"))
            {
                audioManager.Play("Walking");
>>>>>>> Team-link-dev
                Walk();
            }
            else if (moveDirection != Vector3.zero && Input.GetKey("left shift"))
            {
<<<<<<< HEAD
=======
                audioManager.Play("Sprint");
>>>>>>> Team-link-dev
                Sprint();
            }
            else if (moveDirection == Vector3.zero)
            {
                Idle();
            }
            if (moveDirectionX != Vector3.zero && !Input.GetKey("left shift"))
            {
<<<<<<< HEAD
=======
                audioManager.Play("Walking");
>>>>>>> Team-link-dev
                Walk();
            }
            else if (moveDirectionX != Vector3.zero && Input.GetKey("left shift"))
            {
<<<<<<< HEAD
=======
                audioManager.Play("Sprint");
>>>>>>> Team-link-dev
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
<<<<<<< HEAD
                Jump();
            }
        }
        if ( !isGrounded && Input.GetKey("space") && velocity.y < 0f)
        {
=======
                audioManager.Play("Jump");
                Jump();
                unitsCount = 0;
            }
        }
        else
        {
            moveDirection *= moveSpeed;
            moveDirectionX *= moveSpeed;
        }
        if (!isGrounded && Input.GetKey("space") && velocity.y < 0f)
        {
            audioManager.Play("Glide");
            velocity.y = -2;
>>>>>>> Team-link-dev
            Glide();
        }
        else
        {
            NoGlide();
        }
<<<<<<< HEAD
        
=======

>>>>>>> Team-link-dev
        if (!wallFront || !attached || wallLookAngle >= maxWallLookAngle)
        {
            velocity.y += gravity * Time.deltaTime;
            controller.Move((moveDirection + velocity) * Time.deltaTime);
        }
        else
        {
<<<<<<< HEAD
            if (climbing)
                moveDirection = new Vector3(moveX * 2, climbSpeed, 0);
            else
                moveDirection = new Vector3(moveX * 2, 0, 0);
            controller.Move((moveDirection) * Time.deltaTime);
            Idle();
=======

            float climbX = Input.GetAxis("Horizontal");
            if (climbing)
            {

                moveDirection = new Vector3(climbX * 2, climbSpeed, 0);
                moveDirection = transform.TransformDirection(moveDirection);
            }
            else
                moveDirection = new Vector3(climbX * 2, 0, 0);
            moveDirection = transform.TransformDirection(moveDirection);

            controller.Move((moveDirection) * Time.deltaTime);
            Idle();
            unitsCount = 0;
>>>>>>> Team-link-dev
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
<<<<<<< HEAD
=======


>>>>>>> Team-link-dev
    private void Glide()
    {
        gravity = -1;
        anim.SetBool("Gliding", true);
<<<<<<< HEAD
=======
        isGliding = true;
        unitsCount = 0;
>>>>>>> Team-link-dev
    }
    private void NoGlide()
    {
        anim.SetBool("Gliding", false);
        gravity = -9.81f;
<<<<<<< HEAD
=======
        isGliding = false;
>>>>>>> Team-link-dev
    }
    private void StateMachine()
    {
        // State 1 - attaching to wall
        if (Input.GetKeyDown(KeyCode.LeftShift) && wallFront && wallLookAngle < maxWallLookAngle)
        {
            attached = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            attached = false;
        }
        if (wallFront && attached && wallLookAngle < maxWallLookAngle)
        {
            attachToWall();
        }
        else
        {
            detachFromWall();
        }

        //state 2 - climbing

        if (attached && Input.GetKeyDown(KeyCode.W))
        {
            climbing = true;
            //climbSpeed = Mathf.Abs(climbSpeed);
            climbSpeed = 3;
        }
        if (attached && Input.GetKeyUp(KeyCode.W))
        {
<<<<<<< HEAD
            
=======

>>>>>>> Team-link-dev
            climbing = false;
            climbSpeed = 0;
        }
        if (attached && Input.GetKeyDown(KeyCode.S))
        {
            climbing = true;
            //climbSpeed = -climbSpeed;
            climbSpeed = -3;
        }
        if (attached && Input.GetKeyUp(KeyCode.S))
        {
            climbing = false;
            climbSpeed = 0;
        }
        if (attached && climbing) ClimbingMovement();
        if (!climbing && attached)
        {
            rb.velocity = Vector3.zero;
            climbSpeed = 0;
            anim.speed = climbSpeed;
        }

        // State 3 - None
    }


    private void WallCheck()
    {
        wallFront = Physics.SphereCast(transform.position, sphereCastRadius, orientation.forward, out frontWallHit, detectionLength, climbMask);
        wallLookAngle = Vector3.Angle(orientation.forward, -frontWallHit.normal);
<<<<<<< HEAD
=======
        //Debug.Log("Wall look angle"+ wallLookAngle);
>>>>>>> Team-link-dev
    }


    private void attachToWall()
    {
        velocity.y = 0;
        anim.SetBool("Attached", true);

    }

    private void ClimbingMovement()
    {
        rb.velocity = new Vector3(rb.velocity.x, climbSpeed, rb.velocity.z);
        anim.SetFloat("ClimbUpDirection", climbSpeed);
<<<<<<< HEAD
        int climbDirection = (climbSpeed == 0 ? 0 :1);
=======
        int climbDirection = (climbSpeed == 0 ? 0 : 1);
>>>>>>> Team-link-dev

        anim.speed = climbDirection;
        /// idea - sound effect
    }

    private void detachFromWall()
    {
        rb.useGravity = true;
        anim.SetBool("Attached", false);
        attached = false;
        climbing = false;
        anim.speed = 1;

    }
<<<<<<< HEAD
=======

    private void StartAttacking()
    {
        isAttacking = true;
    }

    private void EndAttacking()
    {
        isAttacking = false;
    }
>>>>>>> Team-link-dev
}
