using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class bonkScript : MonoBehaviour
{
    public float bonkForce = 5f;
    public float bonkInterval = 8f;
    public float stunDuration = 3f;
    public ArrayList players = new ArrayList();
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Bonk", 5f, bonkInterval);
    }

    void Bonk()
    {
        foreach(GameObject player in players)
        {
            Rigidbody rb = player.GetComponent<Rigidbody>();
            rb.AddForce(-player.transform.up * bonkForce, ForceMode.Impulse);
            player.GetComponent<PlayerInput>().DeactivateInput();
            player.GetComponent<PlayerInput>().Invoke("ActivateInput", stunDuration);
            Debug.Log("Bonk");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("Player") && !players.Contains(other.gameObject))
        {
            players.Add(other.gameObject);
            Debug.Log("Player entered");
            //foreach (GameObject player in players)
            //{
            //    Debug.Log(player.name + "entered");
            //}
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag.Equals("Player") && players.Contains(other.gameObject))
        {
            players.Remove(other.gameObject);
            Debug.Log("Player exit");
            //foreach (GameObject player in players)
            //{
            //    Debug.Log(player.name + "exited");
            //}
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
