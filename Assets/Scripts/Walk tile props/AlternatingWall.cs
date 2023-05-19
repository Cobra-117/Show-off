using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlternatingWall : MonoBehaviour
{
    public GameObject[] walls;
    public float changeTime = 2000;

    private float countdown;

    void Start()
    {
        countdown = changeTime;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
