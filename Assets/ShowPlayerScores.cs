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
    public Transform firstPlacePosition;
    public Transform secondPlacePosition;
    public Transform thirdPlacePosition;
    public List<PlayerInformation> pInfo;

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
        pInfo = new();
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

        foreach(GameObject player in players)
        {
            playerID[player.GetComponent<PlayerDetails>().playerID-1] = player.GetComponent<PlayerDetails>().playerID;
            playerScores[player.GetComponent<PlayerDetails>().playerID-1] = player.GetComponent<PlayerDetails>().playerScore;
        }

        BubbleSort(playerScores, playerID);
        GetComponent<FireworksGradient>().ChangeColor(playerID[0]);

        foreach (GameObject player in players)
        {
            Debug.Log("player ID: " + player.GetComponent<PlayerDetails>().playerID);

            if (player.GetComponent<PlayerDetails>().playerID == playerID[0])
            {
                firstPlayerPresent = true;
                score1st.GetComponent<TextMeshProUGUI>().text = playerScores[0].ToString();

                Transform firstPlace = player.transform.Find("Walkiing(Clone)");
                firstPlace.gameObject.SetActive(true);
                Destroy(firstPlace.Find("PlayerIcon(Clone)").gameObject);
                firstPlace.transform.position = firstPlacePosition.position;

                player.AddComponent<NamePicker>();
                player.GetComponent<NamePicker>().placing = 1;

                border1st.GetComponent<Image>().sprite = colors[player.GetComponent<PlayerDetails>().playerColor];
                icon1st.GetComponent<Image>().sprite = icons[player.GetComponent<PlayerDetails>().playerIcon];
            }

            else if (player.GetComponent<PlayerDetails>().playerID == playerID[1])
            {
                secondPlayerPresent = true;
                score2nd.GetComponent<TextMeshProUGUI>().text = playerScores[1].ToString();

                Transform secondPlace = player.transform.Find("Walkiing(Clone)");
                secondPlace.gameObject.SetActive(true);
                Destroy(secondPlace.Find("PlayerIcon(Clone)").gameObject);
                secondPlace.transform.position = secondPlacePosition.position;

                player.AddComponent<NamePicker>();
                player.GetComponent<NamePicker>().placing = 2;

                border2nd.GetComponent<Image>().sprite = colors[player.GetComponent<PlayerDetails>().playerColor];
                icon2nd.GetComponent<Image>().sprite = icons[player.GetComponent<PlayerDetails>().playerIcon];
            }

            else if (player.GetComponent<PlayerDetails>().playerID == playerID[2])
            {
                thirdPlayerPresent = true;
                score3rd.GetComponent<TextMeshProUGUI>().text = playerScores[2].ToString();

                Transform thirdPlace = player.transform.Find("Walkiing(Clone)");
                thirdPlace.gameObject.SetActive(true);
                Destroy(thirdPlace.Find("PlayerIcon(Clone)").gameObject);
                thirdPlace.transform.position = thirdPlacePosition.position;

                player.AddComponent<NamePicker>();
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
}
