using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Timeline;

public class FlyingMovement : MonoBehaviour
{
    public Rigidbody player_rb;
    public GameObject player_ob;
    public float verticalForce = 100f;
    public float horizontalForce = 5f;
    public float rotation = 3f;
    public Vector2 analogValue;
    public float cooldownValue = 1f;
    public bool jumpCooldown = false;

    //Capture analog stick values
    void OnMove(InputValue value)
    {
        analogValue = value.Get<Vector2>();
    }

    //Jump a certain amount of height when the jump button is pressed
    void OnJump()
    {
        if (jumpCooldown == false)
        {
            player_rb.AddForce(0, verticalForce, 0, ForceMode.Impulse);
            Invoke("ResetJumpCooldown", cooldownValue);
            jumpCooldown = true;
        }
    }

    void ResetJumpCooldown()
    {
        jumpCooldown = false;
    }

    //Flying movement
    void FlyingMov()
    {
        //horizontal and vertical forces to be applied
        float horizontal = analogValue.x * horizontalForce;
        float vertical = analogValue.y * horizontalForce;

        //direction vector of the camera
        Vector3 camForward = Camera.main.transform.forward;
        Vector3 camRight = Camera.main.transform.right;

        //set these to 0 since we don't want vertical values
        camForward.y = 0;
        camRight.y = 0;

        //horizontal and vertical forces to be applied relative to the camera
        Vector3 forwardRelative = vertical * camForward;
        Vector3 rightRelative = horizontal * camRight;
        
        Vector3 moveDirection = forwardRelative + rightRelative;

        //applying velocity and rotation
        player_rb.velocity = new Vector3(moveDirection.x, player_rb.velocity.y, moveDirection.z);

        transform.rotation = Quaternion.LookRotation(moveDirection);
    }

    private void Update()
    {
        FlyingMov();
    }

    //void FixedUpdate()
    //{
        // GetKey (instead of GetKeyDown) combined with ForceMode.Impulse is weird
        // (Note: GetKeyDown might not work perfectly in FixedUpdate...)
        // Time.deltaTime inside FixedUpdate is fixed - but for ForceMode.Impulse I wouldn't use it
        //if(Input.GetKey(KeyCode.Space))
        //{
        //    player_rb.AddForce(transform.forward * forwardFlyingForce * Time.deltaTime, ForceMode.Impulse);
        //    player_rb.AddForce(0, ascendForce * Time.deltaTime, 0, ForceMode.Impulse);

        //    if (Input.GetKey("w"))
        //    {
        //        player_rb.AddForce(transform.forward * forwardForce * Time.deltaTime, ForceMode.Acceleration);
        //    }

        //    if(Input.GetKey(KeyCode.LeftShift)) {
        //        player_rb.AddForce(transform.forward * boostSpeed * Time.deltaTime, ForceMode.Impulse);
        //    }
        //}
    //}
}
