using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDownPlayer : MonoBehaviour
{
    public ArrayList players = new ArrayList();
    public float slowDownScale;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player") && !players.Contains(other.gameObject))
        {
            players.Add(other.gameObject);
            //Debug.Log("Player entered");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Player") && players.Contains(other.gameObject))
        {
            players.Remove(other.gameObject);
            //Debug.Log("Player exit");
        }
    }

    void SlowDownPlayers()
    {
        Rigidbody rb;
        foreach (GameObject player in players)
        {
            rb = player.GetComponent<Rigidbody>();
            rb.velocity = rb.velocity * slowDownScale;
        }
    }

    // Update is called once per frame
    void Update()
    {
        SlowDownPlayers();
    }
}
