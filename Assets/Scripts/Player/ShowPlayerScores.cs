using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using static ScoreboardXML;

public class ShowPlayerScores : MonoBehaviour
{
    public List<GameObject> players;
    public int[] playerID;
    public int[] playerScores;
    public List<Sprite> colors = new();
    public List<Sprite> icons = new();
    public GameObject countdown;

    public Transform firstPlacePosition;
    public Transform secondPlacePosition;
    public Transform thirdPlacePosition;

    public GameObject score1st;
    public GameObject score2nd;
    public GameObject score3rd;

    public GameObject border1st;
    public GameObject border2nd;
    public GameObject border3rd;

    public GameObject icon1st;
    public GameObject icon2nd;
    public GameObject icon3rd;

    bool firstPlayerPresent;
    bool secondPlayerPresent;
    bool thirdPlayerPresent;

    // Start is called before the first frame update
    void Start()
    {
        BubbleSortUT();
        
        countdown = GameObject.Find("Till reload");
        //GetComponent<ShowLeaderBoardScores>().ShowScores();
        
        //GameObject[] objects = FindObjectsOfType<GameObject>(true);
        GameObject[] objects = GameObject.FindGameObjectsWithTag("playerController");
        foreach (GameObject obj in objects)
        {
            players.Add(obj);
        }

        firstPlayerPresent = false;
        secondPlayerPresent = false;
        thirdPlayerPresent = false;

        playerID = new int[players.Count];
        playerScores = new int[players.Count];
        countdown.GetComponent<ResetGame>().playerCount = players.Count;

        foreach(GameObject player in players)
        {
            playerID[player.GetComponent<PlayerDetails>().playerID-1] = player.GetComponent<PlayerDetails>().playerID;
            playerScores[player.GetComponent<PlayerDetails>().playerID-1] = player.GetComponent<PlayerDetails>().playerScore;
        }

        BubbleSort(playerScores, playerID);
        GetComponent<FireworksGradient>().ChangeColor(playerID[0]);

        foreach (GameObject player in players)
        {
            //Debug.Log("player ID: " + player.GetComponent<PlayerDetails>().playerID);
            player.AddComponent<NamePicker>();
            player.GetComponent<NamePicker>().placing = 0;

            if (player.GetComponent<PlayerDetails>().playerID == playerID[0])
            {
                //countdown.GetComponent<ResetGame>().playerCount++;
                
                firstPlayerPresent = true;
                score1st.GetComponent<TextMeshProUGUI>().text = playerScores[0].ToString("#,#");

                Transform firstPlace = player.transform.Find("Walkiing(Clone)");
                firstPlace.gameObject.SetActive(true);
                Destroy(firstPlace.Find("PlayerIcon(Clone)").gameObject);
                firstPlace.transform.position = firstPlacePosition.position;

                player.GetComponent<NamePicker>().placing = 1;

                border1st.GetComponent<Image>().sprite = colors[player.GetComponent<PlayerDetails>().playerColor];
                icon1st.GetComponent<Image>().sprite = icons[player.GetComponent<PlayerDetails>().playerIcon];
            }

            else if (player.GetComponent<PlayerDetails>().playerID == playerID[1])
            {
                //countdown.GetComponent<ResetGame>().playerCount++;

                secondPlayerPresent = true;
                score2nd.GetComponent<TextMeshProUGUI>().text = playerScores[1].ToString("#,#");

                Transform secondPlace = player.transform.Find("Walkiing(Clone)");
                secondPlace.gameObject.SetActive(true);
                Destroy(secondPlace.Find("PlayerIcon(Clone)").gameObject);
                secondPlace.transform.position = secondPlacePosition.position;

                player.GetComponent<NamePicker>().placing = 2;

                border2nd.GetComponent<Image>().sprite = colors[player.GetComponent<PlayerDetails>().playerColor];
                icon2nd.GetComponent<Image>().sprite = icons[player.GetComponent<PlayerDetails>().playerIcon];

            }

            else if (player.GetComponent<PlayerDetails>().playerID == playerID[2])
            {
                //countdown.GetComponent<ResetGame>().playerCount++;

                thirdPlayerPresent = true;
                score3rd.GetComponent<TextMeshProUGUI>().text = playerScores[2].ToString("#,#");

                Transform thirdPlace = player.transform.Find("Walkiing(Clone)");
                thirdPlace.gameObject.SetActive(true);
                Destroy(thirdPlace.Find("PlayerIcon(Clone)").gameObject);
                thirdPlace.transform.position = thirdPlacePosition.position;

                player.GetComponent<NamePicker>().placing = 3;

                border3rd.GetComponent<Image>().sprite = colors[player.GetComponent<PlayerDetails>().playerColor];
                icon3rd.GetComponent<Image>().sprite = icons[player.GetComponent<PlayerDetails>().playerIcon];

                }
        }
        RemoveUIBasedOnPlayer();
    }

    void RemoveUIBasedOnPlayer()
    {
        GameObject disabledUI;

        if(!firstPlayerPresent)
        {
            disabledUI = GameObject.Find("1st place");
            disabledUI.SetActive(false);
        }

        if (!secondPlayerPresent)
        {
            disabledUI = GameObject.Find("2nd place");
            disabledUI.SetActive(false);
        }

        if (!thirdPlayerPresent)
        {
            disabledUI = GameObject.Find("3rd place");
            disabledUI.SetActive(false);
        }
    }

    //Sort from high to low
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

    //Unit test for bubble sort
    void BubbleSortUT()
    {
        int[] score1 = new int[] { 500, 20, 1000, 4200, 2000, 100, 6000, 2500, 5300 };
        int[] playerID1 = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        int[] score1Sorted = new int[] { 6000, 5300, 4200, 2500, 2000, 1000, 500, 100, 20 };

        BubbleSort(score1, playerID1);

        Debug.Log("Sorted list 1:");
        for (int i=0; i<score1.Length; i++)
        {
            if (score1[i] == score1Sorted[i])
            Debug.Log("PlayerID " + playerID1[i] + " has score " + score1[i]);

            if (i == score1.Length-1)
                Debug.Log("UT1 sorted correctly");
        }

        int[] score2 = new int[] { 4000, 6000, 2000, 10000, 5000, 3400, 4800, 3000, 3000 };
        int[] playerID2 = new int[] { 2, 4, 5, 1, 3, 8, 9, 6, 7 };

        int[] score2Sorted = new int[] { 10000, 6000, 5000, 4800, 4000, 3400, 3000, 3000, 2000 };

        BubbleSort(score2, playerID2);

        Debug.Log("Sorted list 2:");
        for (int i = 0; i < score2.Length; i++)
        {
            if (score2[i] == score2Sorted[i])
            Debug.Log("PlayerID " + playerID2[i] + " has score " + score2[i]);

            if (i == score2.Length-1)
                Debug.Log("UT2 sorted correctly");
        }

    }
}
