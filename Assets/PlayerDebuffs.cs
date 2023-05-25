using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDebuffs : MonoBehaviour
{
    public Rigidbody rb;
    public float slowDownScale;
    public string collideWith;
    public bool slowDown;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    //For trigger
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag.Equals(collideWith))
        {
            Debug.Log("slow down");
            slowDown = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag.Equals(collideWith))
        {
            Debug.Log("slow down over");
            slowDown = false;
        }
    }

    //for collision
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals(collideWith))
        {
            Debug.Log("slow down");
            slowDown = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag.Equals(collideWith))
        {
            Debug.Log("slow down over");
            slowDown = false;
        }
    }

    void slowDownPlayer()
    {
        rb.velocity = rb.velocity * slowDownScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (slowDown)
            slowDownPlayer();

    }
}
