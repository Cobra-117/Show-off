using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CorruptedDataWall : MonoBehaviour
{
    public enum Axis 
    {
        X,Y,Z
    }
    public float speed;
    public float[] speedCurve;

    int currentChunk = 0;
    public float OffsetToFirstPlayer = 15;
    public Axis axis;

    public AudioSource audioSource;
    public Cinemachine.CinemachineTargetGroup targetGroup;
    
    bool isFirstChunk = true;
    // Update is called once per frame
    
    void Start() 
    {
        audioSource = GetComponent<AudioSource>();
        speed = speedCurve[0];
        Debug.Log("start");
    }

    void Update()
    {
        GameObject firstPlayer = GetFirstPlayer();
        if (firstPlayer == null)
            return;
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
            if (transform.position.x < firstPlayer.transform.position.x - OffsetToFirstPlayer) {
                transform.position = new Vector3(firstPlayer.transform.position.x - OffsetToFirstPlayer,
                transform.position.y, transform.position.z);
            } else
                transform.Translate(new Vector3(0, 0, speed *  Time.deltaTime));
        }
    }

    GameObject GetFirstPlayer()
    { 
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        if (players.Length == 0)
            return null;
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

    public void UpdateChunk()
    {
        if (isFirstChunk) {
            isFirstChunk = false;
            return;
        }
        currentChunk += 1;
        if (currentChunk < speedCurve.Length) {
            speed = speedCurve[currentChunk];
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player") {
            Debug.Log("wave touched player");
            Component[] components = gameObject.GetComponents(typeof(Component));
            foreach(Component component in components) {
                Debug.Log(component.ToString());
            }
            collision.transform.GetComponentInParent<PlayerInputScript>().analogValue = Vector3.zero;
            collision.rigidbody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
            targetGroup.RemoveMember(collision.gameObject.transform);
            //collision.gameObject.transform.parent.gameObject.GetComponent<AddPlayerToCamera>().hasInit = false;
            Destroy(collision.gameObject.transform.parent.gameObject.GetComponent<PlayerInputScript>());
            Destroy(collision.gameObject.GetComponent<Walk>());
            collision.gameObject.transform.parent.gameObject.GetComponent<PlayerInput>().SwitchCurrentActionMap("SelectName");
            
            //change this so it's not the player that is disabled
            collision.gameObject.transform.parent.gameObject.SetActive(false);
            //targetGroup.m_Targets
            audioSource.Play();
            Debug.Log("Player removed");
        }
    }
}
