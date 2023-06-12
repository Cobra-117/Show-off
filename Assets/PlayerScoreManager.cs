using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScoreManager : MonoBehaviour
{
    public GameObject[] players;
    public GameObject playerScore;
    public GameObject iconContainer;
    // Start is called before the first frame update
    void Start()
    {
        players = GameObject.FindGameObjectsWithTag("playerController");
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

       

            //int color = players[i].GetComponent<PlayerDetails>().playerID-1;
            //GameObject playerColor = Instantiate(colorSprites[color]);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
