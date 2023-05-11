using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    Rigidbody rb;
    public float horForce;
    public float vertForce;
    public float MaxCooldown;
    public float cooldown = 0;
    public bool good;
    public bool perfect;

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
        PressMode();
    }

    void PressMode()
    {
        cooldown -= Time.deltaTime;
        if (cooldown > 0)
            return;
        //Vector3 forceVector =  
        if (Input.GetKey(KeyCode.Mouse0) && IsGrounded()) {
            rb.velocity = GetJumpVelocity();
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
