using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputScript : MonoBehaviour
{
    public Vector3 analogValue;
    public bool buttonPressed;
    //GameObject currentObject;
    public GameObject pauseText;

    void OnMove(InputValue value)
    {
        analogValue = value.Get<Vector2>();
    }

    void OnPause()
    {
        if (pauseText.GetComponent<PauseScript>().isPaused)
        {
            pauseText.GetComponent<PauseScript>().isPaused = false;
        }

        else if (!pauseText.GetComponent<PauseScript>().isPaused)
        {
            pauseText.GetComponent<PauseScript>().isPaused = true;
        }
            

    }

    void OnSceneLoaded()
    {
        pauseText = GameObject.FindGameObjectWithTag("LobbyMenu");
    }

    //void OnJump()
    //{
    //    currentObject = GetComponent<SwitchMovement>().currentObject;

    //    if (currentObject.name.Equals("Flying"))
    //    {
    //        //Debug.Log("jump");
    //        currentObject.GetComponent<FlyingMovement>().OnButtonPress();
    //    }

    //    if (currentObject.name.Equals("Swim"))
    //        currentObject.GetComponent<SwimmingMovement>().OnButtonPress();

    //    if (currentObject.name.Equals("Walk"))
    //        currentObject.GetComponent<Walk>().OnButtonPress();

    //    if (currentObject.name.Equals("Frog"))
    //        currentObject.GetComponent<Jump>().OnButtonPress();
    //}

    // Start is called before the first frame update
    void Start()
    {
        pauseText = GameObject.FindGameObjectWithTag("pauseText");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
