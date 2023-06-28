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

        LeaderboardSortUT();
    }

    public void ShowScores()
    {
        p = ScoreboardXML.Instance.LoadScore();
        p.Sort();
        scoreList.GetComponent<TextMeshProUGUI>().text = "High Scores:\n";

        for(int i=0; i<showPlayerLimit; i++)
        {
            string s = new string(p[i].playerName + " " + p[i].playerScore.ToString("#,#") + "\n");
            scoreList.GetComponent<TextMeshProUGUI>().text += s;
        }
    }
     
    void LeaderboardSortUT()
    {
        List<PlayerInformation> p1 = new()
        {
            new PlayerInformation(1, 500, "AAA"),
            new PlayerInformation(2, 20, "BAA"),
            new PlayerInformation(3, 100, "CAA"),
            new PlayerInformation(4, 300, "DAA"),
            new PlayerInformation(5, 1000, "EAA"),
            new PlayerInformation(6, 1500, "FAA"),
            new PlayerInformation(7, 2000, "GAA"),
            new PlayerInformation(8, 800, "HAA")
        };

        List<PlayerInformation> p2 = new()
        {
            new PlayerInformation(1, 3000, "AAA"),
            new PlayerInformation(2, 20000, "BAA"),
            new PlayerInformation(3, 1200, "CAA"),
            new PlayerInformation(4, 3800, "DAA"),
            new PlayerInformation(5, 1600, "EAA"),
            new PlayerInformation(6, 5300, "FAA"),
            new PlayerInformation(7, 8000, "GAA"),
            new PlayerInformation(8, 5500, "HAA")
        };

        List<PlayerInformation> p1Correct = new()
        {
            new PlayerInformation(2, 20, "BAA"),
            new PlayerInformation(3, 100, "CAA"),
            new PlayerInformation(4, 300, "DAA"),
            new PlayerInformation(1, 500, "AAA"),
            new PlayerInformation(8, 800, "HAA"),
            new PlayerInformation(5, 1000, "EAA"),
            new PlayerInformation(6, 1500, "FAA"),
            new PlayerInformation(7, 2000, "GAA")
        };

        p1Correct.Reverse();

        List<PlayerInformation> p2Correct = new()
        {
            new PlayerInformation(3, 1200, "CAA"),
            new PlayerInformation(5, 1600, "EAA"),
            new PlayerInformation(1, 3000, "AAA"),
            new PlayerInformation(4, 3800, "DAA"),
            new PlayerInformation(6, 5300, "FAA"),
            new PlayerInformation(8, 5500, "HAA"),
            new PlayerInformation(7, 8000, "GAA"),
            new PlayerInformation(2, 20000, "BAA")
        };

        p2Correct.Reverse();

        p1.Sort();
        p2.Sort();

        for(int i=0; i<p1.Count; i++)
        {
            if (p1[i].playerScore == p1Correct[i].playerScore)
            {
                Debug.Log("player name " + p1[i].playerName + " has score " + p1[i].playerScore);
            }

            if (i == p1.Count - 1)
                Debug.Log("UT1 sorted correctly");
        }

        for (int i = 0; i < p2.Count; i++)
        {
            if (p2[i].playerScore == p2Correct[i].playerScore)
            {
                Debug.Log("player name " + p2[i].playerName + " has score " + p2[i].playerScore);
            }

            if (i == p2.Count - 1)
                Debug.Log("UT2 sorted correctly");
        }


    }

}
