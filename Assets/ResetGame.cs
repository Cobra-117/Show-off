using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetGame : MonoBehaviour
{
    TextMeshProUGUI timer;
    public float countdown;
    public List<PlayerInformation> pInfo;
    
    // Start is called before the first frame update
    void Start()
    {
        countdown = 3600f;
        timer = GetComponent<TextMeshProUGUI>();
        pInfo = new List<PlayerInformation>();
    }

    void RestartGame()
    {
        UploadToXML();
        pInfo.Clear();
        GameObject[] players = GameObject.FindGameObjectsWithTag("playerController");
        foreach (GameObject p in players)
        {
            Destroy(p);
        }
        //SceneManagerScript.controllerCount = 0;
        //SceneManagerScript.playerInfo.Clear();
        SceneManager.LoadScene(0);
    }

    void UploadToXML()
    {
        ScoreboardXML.Instance.SaveScore(pInfo);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        countdown -= Time.deltaTime;
        int second = (int)(countdown % 60);
        if (timer != null )
            timer.text = "Time till restart:\n" + second + " seconds\n Or restart with 'r'";
        
        if (second == 0 || Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }
    }
}
