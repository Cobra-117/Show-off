using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GooWater : MonoBehaviour
{
    public Vector3 knockback;
    void OnTriggerEnter(Collider other)
	{
        if (other.tag == "Player")
		{
            Vector3 originalPos = this.gameObject.transform.position;
            other.transform.position = new Vector3(originalPos.x + knockback.x,
            originalPos.y + knockback.y, originalPos.z + knockback.z);
        }
    }
}
