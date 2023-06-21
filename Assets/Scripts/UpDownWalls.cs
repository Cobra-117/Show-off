using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDownWalls : MonoBehaviour
{
    public float maxHeight;
    public float minHeight;
    public float speed;
    public bool goingUp;
    public float cooldown = 0.5f;

    float curWaitingTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        curWaitingTime -= Time.deltaTime;
        if (curWaitingTime > 0)
            return;
        if (goingUp == true) {
            if (transform.localPosition.y < maxHeight) {
                transform.Translate(new Vector3(0, speed*Time.deltaTime, 0));
            } else {
                goingUp = false;
                curWaitingTime = cooldown;
            }
        }
        else {
            if (transform.localPosition.y > minHeight) {
                transform.Translate(new Vector3(0, -speed*Time.deltaTime, 0));
            } else {
                goingUp = true;
                curWaitingTime = cooldown;
            }
        }
    }

    IEnumerator CooldownCor()
    {
        //Print the time of when the function is first called.
        //Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(cooldown);

        //After we have waited 5 seconds print the time again.
        //Debug.Log("Finished Coroutine at timestamp : " + Time.time);
        //goingUp = !goingUp;
    }
}
