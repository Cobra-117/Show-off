using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Players : MonoBehaviour
{
    public class PlayerInfos {
        public string name;
        public int score;
        public bool isAlive = true;

        public PlayerInfos(string name) {}
    }

    public static List<PlayerInfos> players;
    static bool HasInit = false;
    // Start is called before the first frame update
    void Awake()
    {
        if (HasInit == false) {
            players = new List<PlayerInfos>();
            players.Add(new PlayerInfos("p1"));
            players.Add(new PlayerInfos("p2"));
            players.Add(new PlayerInfos("p3"));
            players.Add(new PlayerInfos("p4"));
            HasInit = true;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (PauseMenu.isGamePaused)
			return;
        for (int i = 0; i < players.Count; i++) {
            if (players[i].isAlive)
                players[i].score += 1;
        }
    }
}
