using UnityEngine;

public class FlyingCamera : MonoBehaviour
{
    public Transform ob;
    public Vector3 offset;

    void Update()
    {
        transform.position = ob.position + offset;
    }
}
