using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryCondition : MonoBehaviour
{
    bool hasGameStarted = false;
    void Start()
    {

    }
    void Update()
    {
        GameObject[] playersobj = GameObject.FindGameObjectsWithTag("Player");
        List<GameObject> activePlayers = new List<GameObject>();

        for (int i = 0; i < playersobj.Length; i++) {
            if (playersobj[i].activeInHierarchy)
                activePlayers.Add(playersobj[i]);
        }
        if (activePlayers.Count >= 2)
            hasGameStarted = true;
        //if (activePlayers.Count == 1 && hasGameStarted == true)
        //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
