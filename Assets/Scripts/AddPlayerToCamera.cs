using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddPlayerToCamera : MonoBehaviour
{
    GameObject cMCamera;
    // Start is called before the first frame update
    void Start()
    {
        cMCamera = GameObject.FindGameObjectWithTag("TargGroup");
        for (int i = 0; i < transform.childCount;i ++) {
            
        }
    }

    void Update()
    {

    }
}
