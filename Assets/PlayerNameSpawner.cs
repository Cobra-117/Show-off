using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerNameSpawner : MonoBehaviour
{
    //public Transform[] spawnLocations;
    public List<Sprite> colors = new();
    public List<Sprite> icons = new();
    public List<Sprite> readyIcons = new();

    private void Start()
    {
        //colors.Add("Blue"); //blue
        //colors.Add("Red"); //red
        //colors.Add("Green"); //green
        //colors.Add("Yellow"); //yellow
        //colors.Add("Orange"); //orange
        //colors.Add("Purple"); //purple
        //colors.Add("Pink"); //pink
        //colors.Add("White"); //white

    }

    void OnPlayerJoined(PlayerInput playerInput)
    {
        Debug.Log("Player " + playerInput.playerIndex + 1 + " joined");
        //Debug.Log(playerInput.GetDevice<Gamepad>().deviceId);

        playerInput.gameObject.transform.SetParent(transform.Find("Players UI"));
        playerInput.gameObject.GetComponent<PlayerDetails>().playerID = playerInput.playerIndex + 1;

        Transform borderAndIcon = playerInput.transform.Find("Border + Icon");
        Transform iconContainer = borderAndIcon.transform.Find("IconContainer");
        Transform border = iconContainer.transform.Find("Border 1");
        Transform icon = iconContainer.transform.Find("Icon 1");
        border.GetComponent<Image>().sprite = colors[playerInput.playerIndex];
        icon.GetComponent<Image>().sprite = icons[playerInput.playerIndex];

        playerInput.gameObject.GetComponent<PlayerDetails>().playerColor = playerInput.playerIndex;

        

        playerInput.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 0);
        //playerInput.gameObject.GetComponent<PlayerDetails>().startPosition = spawnLocations[playerInput.playerIndex].position;
        //SceneManagerScript.controllerCount++;
    }
}
