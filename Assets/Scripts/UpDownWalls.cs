using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDownWalls : MonoBehaviour
{
    public float maxHeight;
    public float minHeight;
    public float speed;
    public bool goingUp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (goingUp == true) {
            if (transform.localPosition.y < maxHeight) {
                transform.Translate(new Vector3(0, speed*Time.deltaTime, 0));
            } else {
                goingUp = false;
            }
        }
        else {
            if (transform.localPosition.y > minHeight) {
                transform.Translate(new Vector3(0, -speed*Time.deltaTime, 0));
            } else {
                goingUp = true;
            }
        }
    }
}
