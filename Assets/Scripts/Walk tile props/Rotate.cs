using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public enum Axis 
    {
        X,Y,Z
    }

    public Axis movingDirection;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (movingDirection == Axis.X) {
            transform.Rotate(speed * Time.deltaTime / 0.01f, 0, 0, Space.Self);
        }
        else if (movingDirection == Axis.Y) {
            transform.Rotate(0f,  speed * Time.deltaTime / 0.01f, 0, Space.Self);
        }
        if (movingDirection == Axis.Z) {
            transform.Rotate(0f, 0f, speed * Time.deltaTime / 0.01f, Space.Self);
        }
    }
}
