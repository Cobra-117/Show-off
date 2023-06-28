using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryCondition : MonoBehaviour
{
    bool hasGameStarted = false;
    public GameObject panel;
    void Start()
    {

    }

    void DelayLoad()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void Update()
    {
        GameObject[] playersobj = GameObject.FindGameObjectsWithTag("Player");
        List<GameObject> activePlayers = new List<GameObject>();

        for (int i = 0; i < playersobj.Length; i++) {
            if (playersobj[i].activeInHierarchy)
                activePlayers.Add(playersobj[i]);
        }
        //if (activePlayers.Count >= 2)
        hasGameStarted = true;

        //the code below shouldn't check if the player is disabled
        if (activePlayers.Count == 0 && hasGameStarted == true) {
            Debug.Log("set panel active");
            panel.SetActive(true);
            Invoke("DelayLoad", 1);
        }
    }
}
