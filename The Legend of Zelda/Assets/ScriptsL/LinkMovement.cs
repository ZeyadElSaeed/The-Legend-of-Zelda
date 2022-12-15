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
    Rigidbody m_Rigidbody;
    float m_Speed;
    float r_Speed;

    
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
        if (Input.GetKey(KeyCode.UpArrow))
        {
            //Move the Rigidbody forwards constantly at speed you define (the blue arrow axis in Scene view)
            transform.Translate(Vector3.forward * m_Speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            //Move the Rigidbody backwards constantly at the speed you define (the blue arrow axis in Scene view)
            transform.Translate(Vector3.forward * m_Speed * Time.deltaTime * -1);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            //Rotate the sprite about the Y axis in the positive direction
            transform.Rotate(new Vector3(0, 1, 0) * Time.deltaTime * r_Speed, Space.World);
            // transform.translate(new Vector3(0, 1, 0) * Time.deltaTime * m_Speed, Space.World);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //Rotate the sprite about the Y axis in the negative direction
            transform.Rotate(new Vector3(0, -1, 0) * Time.deltaTime * r_Speed, Space.World);
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
        m_Rigidbody = GetComponent<Rigidbody>();
        //Set the speed of the GameObject
        m_Speed = 3.0f;
        r_Speed = 90.0f;
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
