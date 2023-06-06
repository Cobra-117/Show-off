using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSpawnManager : MonoBehaviour
{
    public Transform[] spawnLocations;
    public GameObject[] players;
    public GameObject fishModel;

    private void Start()
    {
        players = GameObject.FindGameObjectsWithTag("playerController");
        for(int i=0; i< players.Length; i++)
        {
            GameObject prefab = Instantiate(fishModel);
            prefab.transform.parent = players[i].gameObject.transform;
            prefab.transform.position = spawnLocations[i].position;
        }

        //foreach (GameObject player in players)
        //{
        //    GameObject prefab = Instantiate(fishModel);
        //    prefab.transform.parent = player.transform;
        //}
    }
}
