using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            GameObject[] players = GameObject.FindGameObjectsWithTag("playerController");
            foreach (GameObject p in players)
            {
                Destroy(p);
            }
            SceneManagerScript.controllerCount = 0;
            SceneManagerScript.playerInfo.Clear();
            SceneManager.LoadScene(0);
        }
    }
}
