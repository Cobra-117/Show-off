using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowPlayerScores : MonoBehaviour
{
    public List<GameObject> players;
    public int[] playerID;
    public int[] playerScores;
    
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] objects = FindObjectsOfType<GameObject>(true);
        foreach (GameObject ob in objects)
        {
            if(ob.tag.Equals("playerController"))
            {
                ob.SetActive(true);
                players.Add(ob);
            }
        }


        //players = GameObject.FindGameObjectsWithTag("playerController");
        playerID = new int[players.Count];
        playerScores = new int[players.Count];

        foreach(GameObject player in players)
        {
            playerID[player.GetComponent<PlayerDetails>().playerID-1] = player.GetComponent<PlayerDetails>().playerID;
            playerScores[player.GetComponent<PlayerDetails>().playerID-1] = player.GetComponent<PlayerDetails>().playerScore;
        }

        BubbleSort(playerScores, playerID);
        Transform text = transform.Find("Scoreboard");
        for (int i = 0; i < players.Count; i++)
        {
            Debug.Log("Player " + playerID[i] + "score is: " + playerScores);
            text.GetComponent<TextMeshProUGUI>().text += new string("Player " + playerID[i] + " score is: " + playerScores[i] + "\n");
        }
    }

    void BubbleSort(int[] scores, int[] playerID)
    {
        for(int i=0; i < scores.Length-1; i++)
        {
            for(int j=0; j < scores.Length - i -1; j++)
            {
                if (scores[j] < scores[j+1])
                {
                    int tempS = scores[j];
                    int tempP = playerID[j];

                    scores[j] = scores[j + 1];
                    playerID[j] = playerID[j + 1];

                    scores[j + 1] = tempS;
                    playerID[j + 1] = tempP;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
