using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputScript : MonoBehaviour
{
    public Vector3 analogValue;
    public bool buttonPressed;
    GameObject currentObject;
    void OnMove(InputValue value)
    {
        analogValue = value.Get<Vector2>();
    }
    void OnJump()
    {
        currentObject = GetComponent<SwitchMovement>().currentObject;

        if (currentObject.tag == "flyingPlayer")
        {
            Debug.Log("jump");
            currentObject.GetComponent<FlyingMovement>().OnButtonPress();
        }

        if (currentObject.tag == "swimmingPlayer")
            currentObject.GetComponent<SwimmingMovement>().OnButtonPress();

        if (currentObject.name.Equals("Walk"))
            currentObject.GetComponent<Walk>().OnButtonPress();

        if (currentObject.name.Equals("Frog"))
            currentObject.GetComponent<Jump>().OnButtonPress();
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
