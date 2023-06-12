using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowPlayerScores : MonoBehaviour
{
    public int[] playerID;
    
    // Start is called before the first frame update
    void Start()
    {
        playerID = new int[PlayerScoreManager.playerScoreCount.Length];
        for(int i=0; i<playerID.Length; i++)
        {
            playerID[i] = i + 1;
        }

        BubbleSort(PlayerScoreManager.playerScoreCount, playerID);
        Transform text = transform.Find("Scoreboard");
        for (int i = 0; i < PlayerScoreManager.playerScoreCount.Length; i++)
        {
            Debug.Log("Player " + playerID[i] + "score is: " + PlayerScoreManager.playerScoreCount[i]);
            text.GetComponent<TextMeshProUGUI>().text += new string("Player " + playerID[i] + " score is: " + PlayerScoreManager.playerScoreCount[i] + "\n");
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
