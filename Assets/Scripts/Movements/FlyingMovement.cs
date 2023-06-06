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
    public float speed = 5f;
    public float rotation = 3f;
    public Vector2 analogValue;
    public float cooldownValue = 1f;
    public bool jumpCooldown = false;

    //Capture analog stick values
    //void OnMove(InputValue value)
    //{
    //    analogValue = value.Get<Vector2>();
    //}

    //Jump a certain amount of height when the jump button is pressed

    public void OnButtonPress()
    {
        if (jumpCooldown == false)
        {
            player_rb.AddForce(0, verticalForce, 0, ForceMode.Impulse);
            jumpCooldown = true;
            Invoke("ResetJumpCooldown", cooldownValue);
        }
    }

    //void Jump()
    //{
    //    buttonPressed = GetComponentInParent<PlayerInputScript>().buttonPressed;
    //    if (buttonPressed == true)
    //    {
    //        player_rb.AddForce(0, verticalForce, 0, ForceMode.Impulse);
    //        //Invoke("ResetJumpCooldown", cooldownValue);
    //    }
    //}

    void ResetJumpCooldown()
    {
        jumpCooldown = false;
    }

    //Flying movement
    void FlyingMov()
    {
        analogValue = GetComponentInParent<PlayerInputScript>().analogValue;
        
        //horizontal and vertical forces to be applied
        float horizontal = analogValue.x * speed;
        float vertical = analogValue.y * speed;

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

    private void OnTriggerEnter(Collider other)
    {   
        if (other.tag == "swimming")
            transform.parent.gameObject.GetComponent<SwitchMovement>().SwitchToSwimming();

        if (other.tag == "walking")
            transform.parent.gameObject.GetComponent<SwitchMovement>().SwitchToWalking();

        if (other.tag == "jumping")
            transform.parent.gameObject.GetComponent<SwitchMovement>().SwitchToJumping();
    }

    private void Update()
    {
        FlyingMov();
        //Jump();
    }
}
