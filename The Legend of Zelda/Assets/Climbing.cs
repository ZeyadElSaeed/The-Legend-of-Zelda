using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climbing : MonoBehaviour
{

    [Header("References")]
    public Transform orientation;
    public Rigidbody rb;
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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("climbing: "+climbing);
        Debug.Log("attached: "+attached);
        WallCheck();
        StateMachine();
        
    }

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
            // Debug.Log(climbTimer);
            // if (!climbing && climbTimer > 0) StartClimbing();
            attachToWall();
            Debug.Log("state1");
            // timer
            // if (climbTimer > 0) climbTimer -= Time.deltaTime;
            // if (climbTimer < 0) StopClimbing();
        }
        else{
            detachFromWall();
        }

        //state 2 - climbing

        if(attached && Input.GetKeyDown(KeyCode.W)){
            climbing = true;
            Debug.Log("state2");
        }
        if(attached && Input.GetKeyUp(KeyCode.W)){
            climbing = false;
            Debug.Log("statemtsh3lw");
        }
        if(attached && climbing) ClimbingMovement();
        if(!climbing && attached) rb.velocity = Vector3.zero;
        // State 2 - Exiting
        // else  if (exitingWall)
        // {
        //     if (climbing) StopClimbing();

        //     // if (exitWallTimer > 0) exitWallTimer -= Time.deltaTime;
        //     // if (exitWallTimer < 0) exitingWall = false;
        // }

        // State 3 - None
        // else
        // {
        //     if (attached) detachFromWall();
        //     Debug.Log("state3");
        // }

        // if (wallFront && Input.GetKeyDown(jumpKey) && climbJumpsLeft > 0) ClimbJump();
    }


    private void WallCheck()
    {
        wallFront = Physics.SphereCast(transform.position, sphereCastRadius, orientation.forward, out frontWallHit, detectionLength, whatIsWall);
        wallLookAngle = Vector3.Angle(orientation.forward, -frontWallHit.normal);
    }


    private void attachToWall()
    {
        rb.useGravity = false;
        // attached = true;
        // climbSpeed=0;
        // climbing = true;
        
    }

    private void ClimbingMovement()
    {
        rb.velocity = new Vector3(rb.velocity.x, climbSpeed, rb.velocity.z);
        /// idea - sound effect
    }

    private void detachFromWall()
    {
        rb.useGravity = true;
        // attached = false;
        // climbing = false;

    }

}
