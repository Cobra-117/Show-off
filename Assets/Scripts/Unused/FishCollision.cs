using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FishCollision : MonoBehaviour
{
    Rigidbody rb;
    public float pushbackForce;
    public float stunDuration;

    private void OnCollisionEnter(Collision collision)
    {
        GameObject player = collision.gameObject;
        if(player.tag.Equals("Player"))
        {
            Debug.Log("Fish hits player");
            //player.GetComponent<Rigidbody>().AddForce((player.transform.position - transform.position) * pushbackForce, ForceMode.Impulse);
            player.GetComponent<Rigidbody>().AddForce(-player.transform.forward * pushbackForce, ForceMode.Impulse);
            PlayerInput input = player.GetComponentInParent<PlayerInput>();
            input.DeactivateInput();
            input.Invoke("ActivateInput", stunDuration);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
