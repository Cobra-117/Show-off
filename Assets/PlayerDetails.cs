using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetails : MonoBehaviour
{
    public int playerID;
    public Vector3 startPosition;
    public Vector3 checkpoint;
    //public string playerColor;
    public ArrayList checkpoints = new ArrayList();

    // Start is called before the first frame update
    void Start()
    {
        transform.position = startPosition;
        //checkpoint = startPosition;
        checkpoints.Add(startPosition);
    }
}
