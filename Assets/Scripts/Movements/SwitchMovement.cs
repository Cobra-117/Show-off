using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchMovement : MonoBehaviour
{
    public GameObject flyingObject;
    public GameObject swimmingObject;
    public GameObject jumpObject;
    public GameObject walkObject;
    public GameObject currentObject;
    public ArrayList objects = new ArrayList();

    private void Start()
    {
        objects.Add(flyingObject);
        objects.Add(swimmingObject);
        objects.Add(jumpObject);
        objects.Add(walkObject);
    }

    public void SwitchToFlying()
    {
        flyingObject.SetActive(true);
        flyingObject.transform.position = currentObject.transform.position;
        currentObject = flyingObject;
        //bc = currentObject.GetComponent<Collider>();
        //Debug.Log("Change to flying");
        SetOthersInactiveExcept(flyingObject);
        GameObject.FindGameObjectWithTag("MainCamera").
        GetComponent<CameraFollowObj>().target = flyingObject;
    }

    public void SwitchToSwimming()
    {
        swimmingObject.SetActive(true);
        swimmingObject.transform.position = currentObject.transform.position;
        currentObject = swimmingObject;
        //bc = currentObject.GetComponent<Collider>();
        //Debug.Log("Change to swimming");
        SetOthersInactiveExcept(swimmingObject);
        GameObject.FindGameObjectWithTag("MainCamera").
        GetComponent<CameraFollowObj>().target = swimmingObject;
    }

    public void SwitchToJumping()
    {
        jumpObject.SetActive(true);
        jumpObject.transform.position = currentObject.transform.position;
        currentObject = jumpObject;
        //Debug.Log("Change to Jumping");
        SetOthersInactiveExcept(jumpObject);
        GameObject.FindGameObjectWithTag("MainCamera").
        GetComponent<CameraFollowObj>().target = jumpObject;
    }

    public void SwitchToWalking()
    {
        walkObject.SetActive(true);
        walkObject.transform.position = currentObject.transform.position;
        currentObject = walkObject;
        //Debug.Log("Change to Walking");
        SetOthersInactiveExcept(walkObject);
        GameObject.FindGameObjectWithTag("MainCamera").
        GetComponent<CameraFollowObj>().target = walkObject;
    }

    void SetOthersInactiveExcept(GameObject active)
    {
        foreach (GameObject obj in objects)
        {
            if(obj != active)
            {
                obj.SetActive(false);
            }
        }
    }
}
