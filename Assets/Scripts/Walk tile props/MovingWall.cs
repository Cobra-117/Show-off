using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWall : MonoBehaviour
{
    public enum Axis 
    {
        X,Y,Z
    }

    public Axis movingDirection;

    public float min;
    public float max;
    public float speed;

    public bool isMovingToMin = true;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (movingDirection == Axis.X) {
            if (isMovingToMin == true) {
                if (transform.localPosition.x < min)
                    isMovingToMin = false;
                else {
                    transform.Translate(new Vector3(-speed*Time.deltaTime, 0, 0));
                }
            } else {
                if (transform.localPosition.x > max)
                    isMovingToMin = true;
                else {
                    transform.Translate(new Vector3(speed*Time.deltaTime, 0, 0));
                }
            }
        }
    }
}
