using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorruptedDataWall : MonoBehaviour
{
    public float speed;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(speed *  Time.deltaTime, 0, 0));
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player") {
            Debug.Log("wave touched player");
            collision.gameObject.transform.parent.gameObject.SetActive(false);
        }
    }
}
