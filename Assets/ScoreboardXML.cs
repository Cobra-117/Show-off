using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
using System.IO;
using UnityEngine.Rendering;
using UnityEditor;
using System;

public class PlayerInformation : IComparable   //(when implementing IComparable, Sort will use your CompareTo method for sorting)
{
    public int playerID;
    public int playerScore;
    public string playerName;

    public PlayerInformation(int ID, int score, string name)
    {
        this.playerID = ID;
        this.playerScore = score;
        this.playerName = name;
    }

    public PlayerInformation()
    {

    }

    public int CompareTo(object other)
    {
        if (other is PlayerInformation)
            return ((PlayerInformation)other).playerScore.CompareTo(this.playerScore);

        return 0;
    }
}

[System.Serializable]
public class Leaderboard
{
    public List<PlayerInformation> players = new();
}

public class ScoreboardXML : MonoBehaviour
{
    public static ScoreboardXML Instance;
    public Leaderboard leaderboard;

    private void Awake()
    {
        Instance = this;
        if(!Directory.Exists(Application.persistentDataPath + "/Highscores/"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/Highscores/");
        }
    }

    //THE SCORES ARE SAVED TO C:\Users\<user>\AppData\LocalLow\DefaultCompany\Show off
    public void SaveScore(List<PlayerInformation> newPlayers)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Leaderboard));

        if(!File.Exists(Application.persistentDataPath + "/Highscores/highscores.xml"))
        {
            leaderboard.players = newPlayers;
        }

        else if(File.Exists(Application.persistentDataPath + "/Highscores/highscores.xml"))
        {
            leaderboard.players = LoadScore();
            foreach (PlayerInformation p in newPlayers)
            {
                leaderboard.players.Add(p);
            }
        }

        FileStream stream = new FileStream(Application.persistentDataPath + "/Highscores/highscores.xml", FileMode.Create);
        serializer.Serialize(stream, leaderboard);
        stream.Close();
        return;
    }

    public List<PlayerInformation> LoadScore()
    {
        if(File.Exists(Application.persistentDataPath + "/Highscores/highscores.xml"))
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Leaderboard));
            FileStream stream = new FileStream(Application.persistentDataPath + "/HighScores/highscores.xml", FileMode.Open);
            leaderboard = serializer.Deserialize(stream) as Leaderboard;
            stream.Close();
        }
        return leaderboard.players;
    }

    int ComparePlayers(PlayerInformation left, PlayerInformation right)
    {
        return left.playerScore.CompareTo(right.playerScore); // returns -1, 0 or 1, like any comparer
    }


    //Unused merge sort
    public List<PlayerInformation> SortScore(List<PlayerInformation> players)
    {
        //if(players.Count<=1)
        //{
        //    return players;
        //}
        //players.Sort();
        //return players;

        // Uses the IComparable interface
        //players.Sort( ComparePlayers );
        // more fancy, with lambda:
        //players.Sort((left, right) => {return left.playerScore.CompareTo(right.playerScore); });

        //return players;

        var left = new List<PlayerInformation>();
        var right = new List<PlayerInformation>();

        int middle = players.Count / 2;

        for (int i = 0; i < players.Count; i++)
        {
            left.Add(players[i]);
        }

        for (int i = 0; i < players.Count; i++)
        {
            right.Add(players[i]);
        }

        left = SortScore(left);
        right = SortScore(right);

        return MergeLists(left, right);
    }

    public List<PlayerInformation> MergeLists(List<PlayerInformation> left, List<PlayerInformation> right)
    {
        var result = new List<PlayerInformation>();

        while(left.Count>0 || right.Count > 0)
        {
            if(left.Count>0 && right.Count>0)
            {
                if (left[0].playerScore > right[0].playerScore)
                {
                    result.Add(left[0]);
                    left.Remove(left[0]);
                }

                else
                {
                    result.Add(right[0]);
                    result.Remove(right[0]);
                }
            }

            else if(left.Count>0)
            {
                result.Add(left[0]);
                result.Remove(left[0]);
            }
            else if(right.Count>0)
            {
                result.Add(right[0]);
                result.Remove(right[0]);
            }
        }
        return result;
    }
}
