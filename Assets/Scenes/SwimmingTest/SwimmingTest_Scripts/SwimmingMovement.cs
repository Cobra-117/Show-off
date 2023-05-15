using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.InputSystem;

public class SwimmingMovement : MonoBehaviour
{
    public Rigidbody player_rb;
    public GameObject player_ob;

    public float verticalForce = 300;
    public float horizontalFlyingForce = 50;
    public float horizontalForce = 500;
    public float rotation = 3;
    public Vector2 analogValue;

    //Capture analog stick values
    void OnMove(InputValue value)
    {
        analogValue = value.Get<Vector2>();
    }

    //Diving Mechanic (WIP)
    void OnDive()
    {
        player_rb.AddForce(0, -verticalForce, 0, ForceMode.Impulse);
    }

    ////Move the player forward but only on water
    //void OnForward()
    //{
    //    Debug.Log("forward");
    //    if (transform.position.y < 2)
    //    {
    //        Debug.Log("move");
    //        player_rb.AddForce(transform.forward * verticalForce * Time.deltaTime, ForceMode.Impulse);
    //    }
    //}

    //Can only jump when near water
    //void OnJump()
    //{
    //    Debug.Log("jump");
        
    //    if(transform.position.y < 2 && transform.position.y > -1)
    //    {
    //        player_rb.AddForce(transform.forward * horizontalFlyingForce * Time.deltaTime, ForceMode.Impulse);
    //        player_rb.AddForce(0, verticalForce * Time.deltaTime, 0, ForceMode.Impulse);
    //    }
    //}

    void SwimmingMov()
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
        SwimmingMov();
    }
}
