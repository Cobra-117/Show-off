using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScoreManager : MonoBehaviour
{
    public GameObject[] players;
    public GameObject playerScore;
    // Start is called before the first frame update
    void Start()
    {
        players = GameObject.FindGameObjectsWithTag("playerController");
        for (int i = 0; i < players.Length; i++)
        {
            GameObject scorePrefab = Instantiate(playerScore);
            scorePrefab.transform.parent = this.transform;
            Transform iconContainer = players[i].transform.Find("PlayerIcon");
            Transform scoreIcon = Instantiate(iconContainer);
            scoreIcon.transform.parent = this.transform;

            
            
            //int color = players[i].GetComponent<PlayerDetails>().playerID-1;
            //GameObject playerColor = Instantiate(colorSprites[color]);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
