using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScoreManager : MonoBehaviour
{
    public GameObject[] players;
    public static int[] playerScoreCount;
    public GameObject playerScore;
    public GameObject iconContainer;
    public GameObject[] playerInCanvas;
    // Start is called before the first frame update
    void Start()
    {
        players = GameObject.FindGameObjectsWithTag("playerController");
        playerScoreCount = new int[players.Length];
        playerInCanvas = new GameObject[players.Length];

        for (int i = 0; i < players.Length; i++)
        {
            GameObject scorePrefab = Instantiate(playerScore);
            scorePrefab.transform.parent = this.transform;
            Transform iconContainer = scorePrefab.transform.Find("Border + Icon");
            Transform border = iconContainer.transform.Find("Border");
            Transform icon = iconContainer.transform.Find("Icon");

            GameObject playerManager = GameObject.Find("PlayerManager");

            border.GetComponent<Image>().sprite = playerManager.GetComponent<PlayerSpawnManager>().colors[players[i].GetComponent<PlayerDetails>().playerColor];
            icon.GetComponent<Image>().sprite = playerManager.GetComponent<PlayerSpawnManager>().icons[players[i].GetComponent<PlayerDetails>().playerIcon];


            playerInCanvas[i] = scorePrefab;
            //int color = players[i].GetComponent<PlayerDetails>().playerID-1;
            //GameObject playerColor = Instantiate(colorSprites[color]);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        for (int i = 0; i < players.Length; i++)
        {
            if (players[i].activeInHierarchy)
            {
                playerScoreCount[i] += 1;
                Transform scoreText = playerInCanvas[i].transform.Find("Score");
                scoreText.GetComponent<TextMeshProUGUI>().text = playerScoreCount[i].ToString();
                
            }
        }
    }
}