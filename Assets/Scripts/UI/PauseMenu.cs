using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isGamePaused = false;
    public GameObject PauseCanva;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("escape key pressed");
            if (!isGamePaused) { Pause(); }
            else { Resume(); }
            isGamePaused = !isGamePaused;
        }

        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            if (isGamePaused)
            {
                Resume();
                isGamePaused = false;
                GoToLobby();
            }
        }
    }

    public void Pause()
    {
        Debug.Log("Paused game");
        Time.timeScale = 0f;
        PauseCanva.SetActive(true);
    }

    public void Resume()
    {
        Debug.Log("Resumed game");
        Time.timeScale = 1f;
        PauseCanva.SetActive(false);
    }

    public void GoToLobby()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("playerController");
        foreach (GameObject p in players)
        {
            Destroy(p);
        }
        //SceneManagerScript.controllerCount = 0;
        //SceneManagerScript.playerInfo.Clear();
        SceneManager.LoadScene(0);
    }
}
