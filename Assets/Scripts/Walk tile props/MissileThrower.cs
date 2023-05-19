using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileThrower : MonoBehaviour
{
    public GameObject missile;
    public float missileForce = 50f;
    public float missileSpeed = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
	{
        if (other.tag == "Player")
		{
            GameObject newMissile  = GameObject.Instantiate(missile);
            newMissile.transform.parent = this.gameObject.transform;
            newMissile.transform.position = transform.position;
            newMissile.transform.localEulerAngles = Vector3.zero;
            Vector3 target = new Vector3(other.transform.position.x, -0.5f, other.transform.position.y);
            missile.GetComponent<Missile>().target = other.transform.position;
            missile.GetComponent<Missile>().speed = missileSpeed;
            missile.GetComponent<Missile>().force = missileForce;
            //missile.transform.LookAt(other.transform.position);
            //missile.transform.transform.rotation *= Quaternion.FromToRotation(Vector3.left, Vector3.forward); 
        }
    }
}
