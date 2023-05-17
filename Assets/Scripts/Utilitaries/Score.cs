using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public class PlayerScore {
        public string name;
        public int score;
        public bool isAlive = true;
    }

    List<PlayerScore> players;
    // Start is called before the first frame update
    void Awake()
    {
        players = new List<PlayerScore>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        for (int i = 0; i < players.Count; i++) {
            if (players[i].isAlive)
                players[i].score += 1;
        }
    }
}
