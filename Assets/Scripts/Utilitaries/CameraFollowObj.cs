using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowObj : MonoBehaviour
{
    public GameObject target;

    public float xOffset; 
    public float zOffset;
    public float yPos = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            foreach( GameObject obj in (GameObject.FindGameObjectsWithTag("Player")))
            {
                if (obj.activeInHierarchy == true)
                    target = obj;
            }
        }
        transform.position = new Vector3(
            target.transform.position.x + xOffset, yPos,
            target.transform.position.z + zOffset);
        transform.LookAt(target.transform);
    }
}
