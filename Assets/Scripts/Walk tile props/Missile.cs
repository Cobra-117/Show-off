using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public Vector3 target;
    public float force = 10f; //Force 10000f
	public float stunTime = 0.5f;
    public float speed;
	private Vector3 hitDir;

    void Update()
    {
        //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target), 5 * Time.deltaTime);
        //transform.LookAt(target);
        transform.Translate(new Vector3(speed*Time.deltaTime, 0, 0));
        //transform.Translate(new Vector3(speed*Time.deltaTime, 0, -speed*Time.deltaTime));
        //transform.position = Vector3.MoveTowards(transform.position, target, speed*Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
	{
		foreach (ContactPoint contact in collision.contacts)
		{
			Debug.DrawRay(contact.point, contact.normal, Color.white);
			if (collision.gameObject.tag == "Player")
			{
                Debug.Log("touched player");
				hitDir = contact.normal;
				collision.gameObject.GetComponent<Walk>().HitPlayer(-hitDir * force, stunTime);
				Destroy(this.gameObject);
			}
		}
        //Destroy(this.gameObject);
    }
}
