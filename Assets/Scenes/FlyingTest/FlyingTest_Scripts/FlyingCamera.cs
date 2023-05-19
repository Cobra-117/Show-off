using UnityEngine;

public class FlyingCamera : MonoBehaviour
{
    public Transform ob;
    public Vector3 offset;

    void Update()
    {
        //transform.position = ob.position + offset;
        if (Input.GetKey(KeyCode.W))
            transform.position = transform.position + transform.forward * 1;

        if (Input.GetKey(KeyCode.S))
            transform.position = transform.position - transform.forward * 1;

        if (Input.GetKey(KeyCode.D))
            transform.position = transform.position + transform.right * 1;

        if (Input.GetKey(KeyCode.A))
            transform.position = transform.position - transform.right * 1;




    }
}
