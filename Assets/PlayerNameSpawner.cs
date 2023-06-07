using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerNameSpawner : MonoBehaviour
{
    public Transform[] spawnLocations;
    public List<string> colors = new();

    private void Start()
    {
        colors.Add("Blue"); //blue
        colors.Add("Red"); //red
        colors.Add("Green"); //green
        colors.Add("Yellow"); //yellow
        colors.Add("Orange"); //orange
        colors.Add("Purple"); //purple
        colors.Add("Pink"); //pink
        colors.Add("White"); //white

    }

    void OnPlayerJoined(PlayerInput playerInput)
    {
        Debug.Log("Player " + playerInput.playerIndex + 1 + " joined");
        //Debug.Log(playerInput.GetDevice<Gamepad>().deviceId);
        playerInput.gameObject.transform.SetParent(transform.Find("Players UI"));
        playerInput.gameObject.GetComponent<PlayerDetails>().playerID = playerInput.playerIndex + 1;
        //playerInput.gameObject.GetComponent<PlayerDetails>().playerColor = colors[playerInput.playerIndex];
        //Debug.Log("gamepad id: " + playerInput.GetDevice<Gamepad>().deviceId + " color: " + playerInput.gameObject.GetComponent<PlayerDetails>().playerColor);
        playerInput.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 0);
        //playerInput.gameObject.GetComponent<PlayerDetails>().startPosition = spawnLocations[playerInput.playerIndex].position;
        //SceneManagerScript.controllerCount++;
    }
}
