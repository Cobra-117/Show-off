using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pepeRoar : MonoBehaviour
{
    public Rigidbody rb;
    public float verticalForce = 250f;
    public float pushbackRadius = 8f;
    public float pushbackForce = 5f;
    public ArrayList players = new ArrayList();

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Roar", 5f, 2f);
        rb = GetComponent<Rigidbody>();
    }

    void Roar()
    {
        rb.AddForce(transform.up * verticalForce);
        players.AddRange(GameObject.FindGameObjectsWithTag("Player"));
        foreach (GameObject player in players)
        {
            if(pushbackRadius >= Vector3.Distance(transform.position, player.transform.position)) {
                Debug.Log("Reeeee");
                Vector3 direction = Vector3.Normalize(player.transform.position - transform.position);
                Rigidbody player_rb = player.GetComponent<Rigidbody>();
                player_rb.AddForce(direction * pushbackForce, ForceMode.Impulse);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
