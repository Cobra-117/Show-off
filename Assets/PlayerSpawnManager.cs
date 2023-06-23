using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSpawnManager : MonoBehaviour
{
    public Transform[] spawnLocations;
    public GameObject[] players;
    public List<Sprite> colors = new();
    public List<Sprite> icons = new();
    public GameObject fishModel;
    public GameObject iconContainer;
    public Vector3 offsetFromPlayer;

    private void Start()
    {
        players = GameObject.FindGameObjectsWithTag("playerController");
        for(int i=0; i< players.Length; i++)
        {
            GameObject prefab = Instantiate(fishModel);
            //int color = players[i].GetComponent<PlayerDetails>().playerID-1;
            //GameObject playerColor = Instantiate(colorSprites[color]);

            prefab.transform.parent = players[i].transform;
            prefab.transform.position = spawnLocations[i].position;


            GameObject iconPrefab = Instantiate(iconContainer);
            Transform border = iconPrefab.transform.Find("Border");
            Transform icon = iconPrefab.transform.Find("Icon");

            border.GetComponent<SpriteRenderer>().sprite = colors[players[i].GetComponent<PlayerDetails>().playerColor];
            icon.GetComponent<SpriteRenderer>().sprite = icons[players[i].GetComponent<PlayerDetails>().playerIcon];

            iconPrefab.transform.parent = prefab.transform;
            iconPrefab.transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);
            iconPrefab.transform.position = prefab.transform.position + offsetFromPlayer;

            players[i].AddComponent<PlayerInputScript>();

            //players[i].transform.Find("Border + Icon");
            //Transform iconContainer = borderAndIcon.transform.Find("IconContainer");
            //iconContainer.transform.parent = prefab.transform;
            //iconContainer.transform.position = prefab.transform.position + offsetFromPlayer;

            //playerColor.transform.parent = prefab.transform;
            //playerColor.transform.position = prefab.transform.position + offsetFromPlayer;

        }

        //foreach (GameObject player in players)
        //{
        //    GameObject prefab = Instantiate(fishModel);
        //    prefab.transform.parent = player.transform;
        //}
    }
}
