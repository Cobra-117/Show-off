using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyStatic : MonoBehaviour
{ 
	public float force = 4f; //Force 10000f
	public float stunTime = 0.3f;
	private Vector3 hitDir;

	void Start()
	{
	}

	void OnCollisionEnter(Collision collision)
	{
		foreach (ContactPoint contact in collision.contacts)
		{
			Debug.DrawRay(contact.point, contact.normal, Color.white);
			if (collision.gameObject.tag == "Player")
			{
				hitDir = contact.normal;
				collision.gameObject.GetComponent<Walk>().HitPlayer(-hitDir * force, stunTime);
				return;
			}
		}
	}
}
