using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchMovement : MonoBehaviour
{
    public GameObject flyingObject;
    public GameObject swimmingObject;
    public GameObject currentObject;
    public GameObject jumpObject;
    public GameObject walkObject;
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
        Debug.Log("Change to flying");
        SetOthersInactiveExcept(flyingObject);
    }

    public void SwitchToSwimming()
    {
        swimmingObject.SetActive(true);
        Debug.Log("Change to swimming");
        SetOthersInactiveExcept(swimmingObject);
    }

    public void SwitchToJumping()
    {
        jumpObject.SetActive(true);
        Debug.Log("Change to Jumping");
        SetOthersInactiveExcept(jumpObject);
    }

    public void SwitchToWalking()
    {
        walkObject.SetActive(true);
        Debug.Log("Change to Walking");
        SetOthersInactiveExcept(walkObject);
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

    private void OnTriggerEnter(Collider other)
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
