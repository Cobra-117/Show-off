using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetGame : MonoBehaviour
{
    TextMeshProUGUI timer;
    public float countdown;
    
    // Start is called before the first frame update
    void Start()
    {
        countdown = 3600f;
        timer = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        countdown -= Time.deltaTime;
        int second = (int)(countdown % 60);
        timer.text = "Time till restart:\n" + second + " seconds";
        
        if (countdown == 0)
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
