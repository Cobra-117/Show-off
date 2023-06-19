using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Xml.Serialization;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class IconPicker : MonoBehaviour
{
    GameObject playerReady;
    Transform playerIcon;
    Transform readyIcon;
    GameObject menu;

    public int iconPointer = 0;
    bool ready;

    string readyPlayers;
    string currentControllers;

    // Start is called before the first frame update
    void Start()
    {
        ready = false;
        menu = GameObject.FindGameObjectWithTag("LobbyMenu");
        SceneManagerScript.controllerCount++;
        playerReady = GameObject.Find("Players ready:");
        UpdatePlayerCounts();
        playerReady.GetComponent<TextMeshProUGUI>().text = "Players ready: " + readyPlayers + "/" + currentControllers;

        iconPointer = GetComponent<PlayerDetails>().playerID - 1;
        Transform borderAndIcon = transform.Find("Border + Icon");
        Transform iconContainer = borderAndIcon.transform.Find("IconContainer");
        playerIcon = iconContainer.transform.Find("Icon 1");
        readyIcon = transform.Find("Button");
    }

    void UpdatePlayerCounts()
    {
        readyPlayers = SceneManagerScript.playerInfo.Count.ToString();
        currentControllers = SceneManagerScript.controllerCount.ToString();
    }

    void OnLeftSelect()
    {
        if(iconPointer > 0 && !ready)
        {
            iconPointer--;
            playerIcon.GetComponent<Image>().sprite = menu.GetComponent<PlayerNameSpawner>().icons[iconPointer];
            Debug.Log("Left select " + iconPointer);
        }
    }

    void OnRightSelect()
    {
        if (iconPointer < menu.GetComponent<PlayerNameSpawner>().icons.Count -1 && !ready)
        {
            iconPointer++;
            playerIcon.GetComponent<Image>().sprite = menu.GetComponent<PlayerNameSpawner>().icons[iconPointer];
            Debug.Log("Right select " + iconPointer);
        }
    }

    void OnEnter()
    {
        ready = true;

        GetComponent<PlayerDetails>().playerIcon = iconPointer;
        readyIcon.GetComponent<Image>().sprite = menu.GetComponent<PlayerNameSpawner>().readyIcons[1];

        if (!SceneManagerScript.playerInfo.Contains(this.gameObject))
        SceneManagerScript.playerInfo.Add(this.gameObject);

        UpdatePlayerCounts();
        playerReady.GetComponent<TextMeshProUGUI>().text = "Players ready: " + readyPlayers + "/" + currentControllers;

        Debug.Log("Player count: " + SceneManagerScript.controllerCount);
        Debug.Log("Ready players: " + SceneManagerScript.playerInfo.Count);
    }
}
