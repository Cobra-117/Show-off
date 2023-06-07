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

    public float OffsetToFirstPlayer = 15;
    public Axis axis;
    public Cinemachine.CinemachineTargetGroup targetGroup;
    // Update is called once per frame
    
    void Start() 
    {
        
    }

    void Update()
    {
        GameObject firstPlayer = GetFirstPlayer();
        Debug.Log("Player pos:" + firstPlayer.transform.position.x.ToString());
        Debug.Log("Wave pos: " + transform.position.x.ToString());
        if (axis == Axis.X) {
            if (transform.position.x < firstPlayer.transform.position.x - OffsetToFirstPlayer) {
                transform.position = new Vector3(firstPlayer.transform.position.x - OffsetToFirstPlayer,
                transform.position.y, transform.position.z);
            } else 
                transform.Translate(new Vector3(speed *  Time.deltaTime, 0, 0));
        }
        else if (axis == Axis.Y) {
            if (transform.position.x > firstPlayer.transform.position.x - OffsetToFirstPlayer) {
                transform.position = new Vector3(firstPlayer.transform.position.x - OffsetToFirstPlayer,
                transform.position.y, transform.position.z);
            } else
                transform.Translate(new Vector3(0, speed *  Time.deltaTime, 0));
        }
        else if (axis == Axis.Z) {
            if (transform.position.x > firstPlayer.transform.position.x - OffsetToFirstPlayer) {
                transform.position = new Vector3(firstPlayer.transform.position.x - OffsetToFirstPlayer,
                transform.position.y, transform.position.z);
            } else
                transform.Translate(new Vector3(0, 0, speed *  Time.deltaTime));
        }
    }

    GameObject GetFirstPlayer()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        Debug.Log("Nbr of player:" + players.Length);
        GameObject firtsPlayer = players[0];

        for (int i = 0; i < players.Length; i++) {
            if (players[i].transform.position.x >
            firtsPlayer.transform.position.x) {
                firtsPlayer = players[i];    
            }
        }
        return firtsPlayer;
    }

    bool IsWaveTooFar()
    {
        return false;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player") {
            Debug.Log("wave touched player");
            collision.gameObject.transform.parent.gameObject.SetActive(false);
            targetGroup.RemoveMember(collision.gameObject.transform);
        }
    }
}
