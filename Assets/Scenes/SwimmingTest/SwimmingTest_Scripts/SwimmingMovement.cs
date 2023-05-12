using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwimmingMovement : MonoBehaviour
{
    public Rigidbody player_rb;
    public GameObject player_ob;
    public float ascendForce = 5;
    public float forwardFlyingForce = 5;
    public float forwardForce = 5;
    public float rotation = 3;
    public float boostSpeed = 8;

    void FixedUpdate()
    {
        //jump mechanic (like a frog)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            player_rb.AddForce(transform.forward * forwardFlyingForce, ForceMode.Acceleration);
            player_rb.AddForce(0, ascendForce, 0, ForceMode.Acceleration);
        }

        //only move while in or directly above water
        if(transform.position.y < 3)
        {
            if (Input.GetKeyDown("w"))
            {
                player_rb.AddForce(transform.forward * forwardForce, ForceMode.Impulse);
            }

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                player_rb.AddForce(transform.forward * boostSpeed, ForceMode.Impulse);
            }
        }

        if (Input.GetKey("a"))
        {
            player_ob.transform.Rotate(0, rotation, 0);
        }

        if (Input.GetKey("d"))
        {
            player_ob.transform.Rotate(0, -rotation, 0);
        }
    }
}
