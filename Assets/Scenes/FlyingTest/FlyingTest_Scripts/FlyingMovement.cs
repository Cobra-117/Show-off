using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingMovement : MonoBehaviour
{
    public Rigidbody player_rb;
    public GameObject player_ob;
    public float ascendForce = 1;
    public float forwardFlyingForce = 1;
    public float forwardForce = 5;
    public float rotation = 3;
    public float boostSpeed = 8;

    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            player_rb.AddForce(transform.forward * forwardFlyingForce, ForceMode.Impulse);
            player_rb.AddForce(0, ascendForce, 0, ForceMode.Impulse);

            if (Input.GetKey("w"))
            {
                player_rb.AddForce(transform.forward * forwardForce);
            }

            if(Input.GetKey(KeyCode.LeftShift)) {
                player_rb.AddForce(transform.forward * boostSpeed, ForceMode.Impulse);
            }

        }

        if(Input.GetKey("a"))
        {
            player_ob.transform.Rotate(0, rotation, 0);
        }

        if(Input.GetKey("d"))
        {
            player_ob.transform.Rotate(0, -rotation, 0);
        }
    }
}
