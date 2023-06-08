using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    public static int controllerCount;
    //public static ArrayList playerInfo = new ArrayList();
    public static List<GameObject> playerInfo = new();
    bool useTestScene;


    // Start is called before the first frame update
    void Start()
    {
        useTestScene = false;
        controllerCount = 0;
    }

    void RetainObjects()
    {
        foreach (GameObject obj in playerInfo)
        {
            obj.transform.parent = null;
            obj.GetComponent<TextEditor>().enabled = false;
            obj.GetComponent<PlayerInput>().SwitchCurrentActionMap("playerFlying");
            obj.GetComponent<PlayerInputScript>().enabled = true;
            DontDestroyOnLoad(obj);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            useTestScene = true;
            Debug.Log("Use flyingtest scene");
        }
        
        if(controllerCount == playerInfo.Count && playerInfo.Count > 0)
        {
            RetainObjects();

            if(useTestScene)
            {
                SceneManager.LoadScene("FlyingTest");
            }

            else
            {
                SceneManager.LoadScene("PlayScene");
            }
            
        }
        
        //if(controllerCount == playerInfo.Count && controllerCount > 0 && playerInfo.Count > 0)
        //if (playerInfo.Count > 0)
        //{
        //    Debug.Log("Game can start");
        //}
    }
}