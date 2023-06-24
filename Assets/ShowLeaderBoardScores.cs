using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShowLeaderBoardScores : MonoBehaviour
{
    List <PlayerInformation> p;
    public GameObject scoreList;
    public int showPlayerLimit;

    void Start()
    {
        p = new();

        if(scoreList)
        ShowScores();
    }

    public void ShowScores()
    {
        p = ScoreboardXML.Instance.LoadScore();
        p.Sort();
        //p.Reverse();
        scoreList.GetComponent<TextMeshProUGUI>().text = "High Scores:\n";

        for(int i=0; i<showPlayerLimit; i++)
        {
            string s = new string(p[i].playerName + " " + p[i].playerScore.ToString("#,#") + "\n");
            scoreList.GetComponent<TextMeshProUGUI>().text += s;
        }

        //foreach (PlayerInformation pl in p)
        //{
        //    string s = new string(pl.playerName + " " + pl.playerScore.ToString("#,#") + "\n");
        //    scoreList.GetComponent<TextMeshProUGUI>().text += s;
        //}
        
    }
     

}
