using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkMovement : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody m_Rigidbody;
    float m_Speed;
    float r_Speed;

    
    void MoveAllDirections()
    {
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

    }
    void Sprint()
    {

    }

    void Climb()
    {

    }

    void Glide()
    {

    }
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        //Set the speed of the GameObject
        m_Speed = 3.0f;
        r_Speed = 90.0f;
    }

    // Update is called once per frame
    void Update()
    {
        MoveAllDirections();
    }
}
