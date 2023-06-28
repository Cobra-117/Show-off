using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Unity.VisualScripting;

public class CheckpointManager : MonoBehaviour
{

    void Start()
    {
        //checkpoint.position = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        ArrayList checkpoints = GetComponentInParent<PlayerDetails>().checkpoints;
        
        if(other.gameObject.CompareTag("checkpoint"))
        {
            //GetComponentInParent<PlayerDetails>().checkpoint = other.gameObject.transform.position;
            if (!checkpoints.Contains(other.gameObject.transform.position))
            {
                checkpoints.Add(other.gameObject.transform.position);
                //Debug.Log("Checkpoint updated");
            }
            else
            {
                //Debug.Log("Checkpoint passed already");
            }
        }
        
        if(other.gameObject.CompareTag("death"))
        {
            //transform.position = GetComponentInParent<PlayerDetails>().checkpoint;
            transform.position = (Vector3)checkpoints[checkpoints.Count-1];
            //Debug.Log("Reset from last checkpoint");
        }
    }

    //// Update is called once per frame
    //void Update()
    //{
        
    //}
}
