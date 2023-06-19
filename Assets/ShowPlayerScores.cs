using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
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
                ob.GetComponent<PlayerInput>().SwitchCurrentActionMap("SelectName");
                //ob.GetComponent<PlayerInputScript>().enabled = false;
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
        GetComponent<FireworksGradient>().ChangeColor(playerID[0]);

        GameObject score1st = GameObject.Find("Score text_1st");
        GameObject score2nd = GameObject.Find("Score text_2nd");
        GameObject score3rd = GameObject.Find("Score text_3rd");

        foreach (GameObject player in players)
        {
            Debug.Log("player ID: " + player.GetComponent<PlayerDetails>().playerID);

            if (player.GetComponent<PlayerDetails>().playerID == playerID[0])
            {
                score1st.GetComponent<TextMeshProUGUI>().text = playerScores[0].ToString();
                //Debug.Log("First placer is " + player.GetComponent<PlayerDetails>().playerID);
                //player.GetComponent<PlayerInputScript>().analogValue = new Vector3(0, 0, 0);
                
                Transform firstPlace = player.transform.Find("Walkiing(Clone)");
                firstPlace.transform.position = firstPlacePosition.position;

                //player.GetComponent<NamePicker>().enabled = true;
                player.AddComponent<NamePicker>();
                player.GetComponent<NamePicker>().placing = 1;
            }

            else if (player.GetComponent<PlayerDetails>().playerID == playerID[1])
            {
                score2nd.GetComponent<TextMeshProUGUI>().text = playerScores[1].ToString();
                Debug.Log("Second placer is " + player.GetComponent<PlayerDetails>().playerID);
                //player.GetComponent<PlayerInputScript>().analogValue = new Vector3(0, 0, 0);
                Transform secondPlace = player.transform.Find("Walkiing(Clone)");
                secondPlace.transform.position = secondPlacePosition.position;
                //player.GetComponent<NamePicker>().enabled = true;
                player.AddComponent<NamePicker>();
                player.GetComponent<NamePicker>().placing = 2;
            }

            else if (player.GetComponent<PlayerDetails>().playerID == playerID[2])
            {
                score3rd.GetComponent<TextMeshProUGUI>().text = playerScores[2].ToString();
                Debug.Log("Third placer is " + player.GetComponent<PlayerDetails>().playerID);
                //player.GetComponent<PlayerInputScript>().analogValue = new Vector3(0, 0, 0);
                Transform thirdPlace = player.transform.Find("Walkiing(Clone)");
                thirdPlace.transform.position = thirdPlacePosition.position;
                //player.GetComponent<NamePicker>().enabled = true;
                player.AddComponent<NamePicker>();
                player.GetComponent<NamePicker>().placing = 3;
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
