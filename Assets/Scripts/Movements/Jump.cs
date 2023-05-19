using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Jump : MonoBehaviour
{
    Rigidbody rb;
    public float horForce;
    public float vertForce;
    public float MaxCooldown;
    public float cooldown = 0;
    public bool good;
    public bool perfect;

    //used for gamepad controls
    public Vector2 analogValue;
    public Vector3 rotateDirection;
    public bool jumpButtonPressed;

    //method that returns the analog stick X,Y values from -1 to 1 
    void OnMove(InputValue value)
    {
        analogValue = value.Get<Vector2>();
    }

    //method that runs the code inside when the jump button is pressed
    void OnJump()
    {
        jumpButtonPressed = true;
    }

    void GetDirection()
    {
        float horizontal = analogValue.x;
        float vertical = analogValue.y;

        //direction vector of the camera
        Vector3 camForward = Camera.main.transform.forward;
        Vector3 camRight = Camera.main.transform.right;

        //set these to 0 since we don't want vertical values
        camForward.y = 0;
        camRight.y = 0;

        //horizontal and vertical forces to be applied relative to the camera
        Vector3 forwardRelative = vertical * camForward;
        Vector3 rightRelative = horizontal * camRight;

        rotateDirection = forwardRelative + rightRelative;
    }

    void RotateObject()
    {
        transform.rotation = Quaternion.LookRotation(rotateDirection);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "flying")
            transform.parent.gameObject.GetComponent<SwitchMovement>().SwitchToFlying();

        if (other.tag == "swimming")
            transform.parent.gameObject.GetComponent<SwitchMovement>().SwitchToSwimming();

        if (other.tag == "walking")
            transform.parent.gameObject.GetComponent<SwitchMovement>().SwitchToWalking();
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
            Debug.LogError("No rigidbody on object with jump script attached");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GetDirection();
        RotateObject();
        PressMode();
        jumpButtonPressed = false;
    }

    void PressMode()
    {
        cooldown -= Time.deltaTime;
        if (cooldown > 0)
            return;
        //Vector3 forceVector =  
        if (jumpButtonPressed && IsGrounded()) {
            rb.velocity = GetJumpVelocity();
            GetComponent<Animator>().Play("Take 001");
            cooldown = MaxCooldown;
        }
    }

    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, 0.8f + 0.1f);
    }

    Vector3 GetJumpVelocity()
    {
        if (perfect == true) 
        {
            Debug.Log("Perfect");
            return new Vector3(horForce, vertForce, 0);
        } else if (good == true) {
            Debug.Log("Good");
            return new Vector3(horForce/1.5f, vertForce/1.5f, 0);
        } else {
            return new Vector3(0, 0, 0);
        }
    }

    public void SetPerfect(bool value)
    {
        perfect = value;
    }

    public void SetGood(bool value)
    {
        good = value;
    }
    //void OnTr
    
}
