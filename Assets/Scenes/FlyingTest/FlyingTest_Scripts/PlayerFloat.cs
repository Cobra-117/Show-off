using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFloat : MonoBehaviour
{
    public Rigidbody rb;

    //approximate object height before it is submerged ?
    public float heightBeforeSubmerged = 0.5f;
    
    //approximate amount of water displaced when the object is in water / submerged ?
    public float displacement = 3f;

    //multiplies how much force is added upwards ?
    float displacementMultiplier;

    private void FixedUpdate()
    {
        if(transform.position.y < 0f)
        {
            
            displacementMultiplier = Mathf.Clamp01(-transform.position.y / heightBeforeSubmerged) * displacement;
            
            rb.AddForce(new Vector3(0f, Mathf.Abs(Physics.gravity.y) * displacementMultiplier, 0f), ForceMode.Acceleration);

            //Debug.Log("Position (negative): " + -transform.position.y);
            //Debug.Log("displacementMultiplier: " + displacementMultiplier);
            //Debug.Log("Force added upwards: " + Mathf.Abs(Physics.gravity.y) * displacementMultiplier);
        }
    }
}
