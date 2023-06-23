using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowLeaderBoardScores : MonoBehaviour
{
    List <PlayerInformation> p;
    public GameObject scoreList;

    void Start()
    {
        p = new();
    }

    public void ShowScores()
    {
        p = ScoreboardXML.Instance.LoadScore();
        p.Sort();
        //p.Reverse();
        scoreList.GetComponent<TextMeshProUGUI>().text = "High Scores:\n";
        foreach (PlayerInformation pl in p)
        {
            string s = new string(pl.playerName + " " + pl.playerScore.ToString("#,#") + "\n");
            scoreList.GetComponent<TextMeshProUGUI>().text += s;
        }
        
    }
     

}
