using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using static ScoreboardXML;

public class ShowPlayerScores : MonoBehaviour
{
    public List<GameObject> players;
    public int[] playerID;
    public int[] playerScores;
    public Transform firstPlacePosition;
    public Transform secondPlacePosition;
    public Transform thirdPlacePosition;
    public List<PlayerInformation> pInfo;

    // Start is called before the first frame update
    void Start()
    {
        pInfo = new();
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
            text.GetComponent<TextMeshProUGUI>().text += new string("Player " + playerID[i] + " score is: " + playerScores[i].ToString("#,#") + "\n");
        }

        foreach(GameObject player in players)
        {
            Debug.Log("player ID: " + player.GetComponent<PlayerDetails>().playerID);

            if (player.GetComponent<PlayerDetails>().playerID == playerID[0])
            {
                Debug.Log("First placer is " + player.GetComponent<PlayerDetails>().playerID);
                player.GetComponent<PlayerInputScript>().analogValue = new Vector3(0, 0, 0);
                Transform firstPlace = player.transform.Find("Walkiing(Clone)");
                firstPlace.transform.position = firstPlacePosition.position;
            }

            else if (player.GetComponent<PlayerDetails>().playerID == playerID[1])
            {
                Debug.Log("Second placer is " + player.GetComponent<PlayerDetails>().playerID);
                player.GetComponent<PlayerInputScript>().analogValue = new Vector3(0, 0, 0);
                Transform secondPlace = player.transform.Find("Walkiing(Clone)");
                secondPlace.transform.position = secondPlacePosition.position;
            }

            else if (player.GetComponent<PlayerDetails>().playerID == playerID[2])
            {
                Debug.Log("Third placer is " + player.GetComponent<PlayerDetails>().playerID);
                player.GetComponent<PlayerInputScript>().analogValue = new Vector3(0, 0, 0);
                Transform thirdPlace = player.transform.Find("Walkiing(Clone)");
                thirdPlace.transform.position = thirdPlacePosition.position;
            }
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
