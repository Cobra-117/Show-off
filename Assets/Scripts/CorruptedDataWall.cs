using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorruptedDataWall : MonoBehaviour
{
    public enum Axis 
    {
        X,Y,Z
    }
    public float speed;
    public Axis axis;
    // Update is called once per frame
    void Update()
    {
        if (axis == Axis.X)
            transform.Translate(new Vector3(speed *  Time.deltaTime, 0, 0));
        else if (axis == Axis.Y)
            transform.Translate(new Vector3(0, speed *  Time.deltaTime, 0));
        else if (axis == Axis.Z)
            transform.Translate(new Vector3(0, 0, speed *  Time.deltaTime));
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player") {
            Debug.Log("wave touched player");
            collision.gameObject.transform.parent.gameObject.SetActive(false);
        }
    }
}
