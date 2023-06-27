using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputScript : MonoBehaviour
{
    public Vector3 analogValue;
    public bool buttonPressed;
    //GameObject currentObject;
    public GameObject cameraObject;

    void OnMove(InputValue value)
    {
        analogValue = value.Get<Vector2>();
    }

    void OnPause()
    {
        if (PauseMenu.isGamePaused == false)
        {   
            cameraObject.GetComponent<PauseMenu>().Pause();
            PauseMenu.isGamePaused = true;
        }

        else if (PauseMenu.isGamePaused == true)
        {
            cameraObject.GetComponent<PauseMenu>().Resume();
            PauseMenu.isGamePaused = false;
        }
    }

    //void OnSceneLoaded()
    //{
    //    cameraObject = GameObject.FindGameObjectWithTag("LobbyMenu");
    //}

    // Start is called before the first frame update
    void Start()
    {
        cameraObject = GameObject.FindGameObjectWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
