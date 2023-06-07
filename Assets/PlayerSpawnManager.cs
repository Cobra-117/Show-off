using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSpawnManager : MonoBehaviour
{
    public Transform[] spawnLocations;
    public GameObject[] players;
    public GameObject[] colorSprites;
    public GameObject fishModel;
    public Vector3 offsetFromPlayer;

    private void Start()
    {
        players = GameObject.FindGameObjectsWithTag("playerController");
        for(int i=0; i< players.Length; i++)
        {
            GameObject prefab = Instantiate(fishModel);
            int color = players[i].GetComponent<PlayerDetails>().playerID-1;
            GameObject playerColor = Instantiate(colorSprites[color]);

            prefab.transform.parent = players[i].transform;
            prefab.transform.position = spawnLocations[i].position;

            playerColor.transform.parent = prefab.transform;
            playerColor.transform.position = prefab.transform.position + offsetFromPlayer;

        }

        //foreach (GameObject player in players)
        //{
        //    GameObject prefab = Instantiate(fishModel);
        //    prefab.transform.parent = player.transform;
        //}
    }
}
