using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkMovement : MonoBehaviour
{
    //public GameObject plane;
    // public GameObject cube; //to try as a wall to glide from


    public float m_FallSpeed = 0.7f;
    private Rigidbody rb;
    public float walkSpeed = 5; //Speed for moving the player
    private float currentMoveSpeed; //this changes depending whether the player is walking or sprinitng
   


    [SerializeField] private Vector3 moveDirection;
    [SerializeField] private Vector3 velocity;
    
    [SerializeField] private bool isGrounded;
    [SerializeField] float groundCheckDistance;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float gravity;
    private CharacterController controller;
    [SerializeField] private float jumpHeigt;



    [Header("References")]
    public Transform orientation;
    public LayerMask whatIsWall;


    [Header("Climbing")]
    public float climbSpeed;
    public float maxClimbTime;
    // public float climbTimer;
    private bool climbing;
    private bool attached;
    [Header("Detection")]
    public float detectionLength;
    public float sphereCastRadius;
    public float maxWallLookAngle;
    private float wallLookAngle;

    private RaycastHit frontWallHit;
    private bool wallFront;


    void MoveAllDirections()
    {
        // groundCheckDistance is the radius of a sphere draw at transform.position of the player that checks if the sphere is
        // intersecting with the groundMask
        isGrounded = Physics.CheckSphere(transform.position, groundCheckDistance, groundMask);
        float moveZ = Input.GetAxis("Vertical");
        float moveX = Input.GetAxis("Horizontal");
        moveDirection = new Vector3(moveX, 0, moveZ);
        // this makes movement in the direction of the player instead of glbal direction
        moveDirection = transform.TransformDirection(moveDirection); 

        if (isGrounded && velocity.y <= 0)
        {
            //sometimes when velocity is less than but very close to 0, it gets rounded as 0 so we do this to prevent that
            velocity.y = -2f; 
        }

        if (isGrounded)
        {

           if(moveDirection!= Vector3.zero && !Input.GetKey(KeyCode.LeftShift))
            {
                //Walk();
                currentMoveSpeed = walkSpeed;
            }
           else if(moveDirection!= Vector3.zero && Input.GetKey(KeyCode.LeftShift))
            {
                //Run();
                currentMoveSpeed = walkSpeed * 2;
            }
           else if(moveDirection == Vector3.zero)
            {
                //Idle();
            }
            
                


            moveDirection *= currentMoveSpeed;
            
            if (Input.GetKeyDown("space"))
            {
                Jump();
            }
        }
        else
        {
            //not grounded
            
        }
        //controller.Move();
        if(!wallFront || !attached || wallLookAngle >= maxWallLookAngle){
            velocity.y += gravity * Time.deltaTime;
            controller.Move((moveDirection +velocity) * Time.deltaTime);
        }
        else{
            if(climbing)
                moveDirection = new Vector3(moveX*2, climbSpeed, 0);
            else
                moveDirection = new Vector3(moveX*2, 0, 0);
            controller.Move((moveDirection) * Time.deltaTime);
        }
        //that's how we add gravity since the player is kinematic (check rb of the player)

    }
    void Jump()
    {
        
        velocity.y = Mathf.Sqrt(jumpHeigt * -2 * gravity);
        //velocity.y += gravity * Time.deltaTime;
        //controller.Move(velocity * Time.deltaTime);

    }
    void Sprint()
    {
        
    }

    void Climb()
    {

    }

    void Glide()
    {
        if (Input.GetKey("space") && rb.velocity.y < 0f && !isGrounded)
        {

            //isFalling = true;
            velocity.y =  Mathf.Sign(rb.velocity.y) * m_FallSpeed;//falling with slope depending on the falling direction
        }
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>(); //calling rigidbody for the gliding
        controller = GetComponent<CharacterController>();
        currentMoveSpeed = walkSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        MoveAllDirections();
        
        Debug.Log("climbing: "+climbing);
        Debug.Log("attached: "+attached);
        WallCheck();
        StateMachine();
        //Sprint();
        //Glide();

        /*if (transform.position.y < y_pos && transform.position.y > plane.transform.position.y + 2)
        {
            isFalling = true;
        }
        else
            isFalling = false;*/
        //Debug.Log(isFalling);
    }
    //Used to controll jumping when gliding
    
    private void StateMachine()
    {
        // State 1 - attaching to wall
        if(Input.GetKeyDown(KeyCode.LeftShift)){
            attached = true;
        }
        if(Input.GetKeyUp(KeyCode.LeftShift)){
            attached = false;
        }
        if (wallFront && attached && wallLookAngle < maxWallLookAngle)
        {
            attachToWall();
        }
        else{
            detachFromWall();
        }

        //state 2 - climbing

        if(attached && Input.GetKeyDown(KeyCode.W)){
            climbing = true;
            climbSpeed = Mathf.Abs(climbSpeed);
        }
        if(attached && Input.GetKeyUp(KeyCode.W)){
            climbing = false;
        }
        if(attached && Input.GetKeyDown(KeyCode.S)){
            climbing = true;
            climbSpeed = -climbSpeed;
        }
        if(attached && Input.GetKeyUp(KeyCode.S)){
            climbing = false;
        }
        if(attached && climbing) ClimbingMovement();
        if(!climbing && attached) rb.velocity = Vector3.zero;
        

        // State 3 - None
        
        // if (wallFront && Input.GetKeyDown(jumpKey) && climbJumpsLeft > 0) ClimbJump();
    }


    private void WallCheck()
    {
        wallFront = Physics.SphereCast(transform.position, sphereCastRadius, orientation.forward, out frontWallHit, detectionLength, whatIsWall);
        wallLookAngle = Vector3.Angle(orientation.forward, -frontWallHit.normal);
    }


    private void attachToWall()
    {
        velocity.y=0;
    }

    private void ClimbingMovement()
    {
        rb.velocity = new Vector3(rb.velocity.x, climbSpeed, rb.velocity.z);
        /// idea - sound effect
    }

    private void detachFromWall()
    {
        rb.useGravity = true;
    }
}

