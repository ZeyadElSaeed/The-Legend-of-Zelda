using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkMovement : MonoBehaviour
{
    public GameObject plane;
    // public GameObject cube; //to try as a wall to glide from
    public float y_pos;

    public float m_FallSpeed = 0.7f;
    private Rigidbody rb;
    public float defaultMoveSpeed = 4; //Speed for moving the player
    private float currentMoveSpeed; //this changes depending whether the player is walking or sprinitng
    public float jumpMultiplier = 500; // multplies the up jump force
    public bool isFalling;
    // Start is called before the first frame update

    void MoveAllDirections()
    {
        if (Input.GetKey("up"))
        {
            transform.position += Vector3.forward * Time.deltaTime * currentMoveSpeed;
        }
        if (Input.GetKey("down"))
        {
            transform.position += Vector3.back * Time.deltaTime * currentMoveSpeed;
        }
        if (Input.GetKey("right"))
        {
            transform.position += Vector3.right * Time.deltaTime * currentMoveSpeed;
        }
        if (Input.GetKey("left"))
        {
            transform.position += Vector3.left * Time.deltaTime * currentMoveSpeed;
        }
        if (Input.GetKey("w"))
        {
            transform.position += Vector3.forward * Time.deltaTime * currentMoveSpeed;
        }
        if (Input.GetKey("s"))
        {
            transform.position += Vector3.back * Time.deltaTime * currentMoveSpeed;
        }
        if (Input.GetKey("d"))
        {
            transform.position += Vector3.right * Time.deltaTime * currentMoveSpeed;
        }
        if (Input.GetKey("a"))
        {
            transform.position += Vector3.left * Time.deltaTime * currentMoveSpeed;
        }
    }

    void Jump()
    {
        
            if (isFalling == false)
            {

                if (Input.GetKeyDown("space"))
                {
                rb.AddForce(Vector3.up * jumpMultiplier);
                //transform.position += Vector3.up * Time.deltaTime * jumpMultiplier;
                }
            }
        
    }
    void Sprint()
    {
        if (Input.GetKeyDown("left shift"))
        {
            currentMoveSpeed = currentMoveSpeed * 2;
        }
        if (Input.GetKeyUp("left shift"))
        {
            currentMoveSpeed = defaultMoveSpeed;
        }
    }

    void Climb()
    {

    }

    void Glide()
    {
        if (Input.GetKey("space") && rb.velocity.y < 0f && Mathf.Abs(rb.velocity.y) > m_FallSpeed)
        {

            isFalling = true;
            rb.velocity = new Vector3(rb.velocity.x, Mathf.Sign(rb.velocity.y) * m_FallSpeed, rb.velocity.z);//falling with slope depending on the falling direction
        }
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>(); //calling rigidbody for the gliding
        currentMoveSpeed = defaultMoveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        MoveAllDirections();
        Sprint();
        Glide();
        Jump();
        if (transform.position.y < y_pos && transform.position.y > plane.transform.position.y+2)
        {
            isFalling = true;
        }
        else
            isFalling = false;
        Debug.Log(isFalling);
    }
    //Used to controll jumping when gliding
    void OnCollisionEnter(Collision c)
    {
        Debug.Log(LayerMask.LayerToName(c.gameObject.layer));
        if (LayerMask.LayerToName(c.gameObject.layer).Equals("Climbable"))
        {
            y_pos = c.gameObject.transform.position.y;
            
        }
    }
}
