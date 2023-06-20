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
    public bool ready;

    string readyPlayers;
    string currentControllers;

    // Start is called before the first frame update
    void Start()
    {
        ready = false;
        menu = GameObject.FindGameObjectWithTag("LobbyMenu");
        menu.GetComponent<SceneManagerScript>().controllerCount++;
 
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
        readyPlayers = menu.GetComponent<SceneManagerScript>().playerInfo.Count.ToString();
        currentControllers = menu.GetComponent<SceneManagerScript>().controllerCount.ToString();
    }

    void OnLeft()
    {
        if(iconPointer > 0 && !ready)
        {
            iconPointer--;
            playerIcon.GetComponent<Image>().sprite = menu.GetComponent<PlayerNameSpawner>().icons[iconPointer];
            Debug.Log("Left select " + iconPointer);
        }
    }

    void OnRight()

    {
        Debug.Log(" OnRightSelect called in IconPicker. enabled: " + enabled);
        if (iconPointer < menu.GetComponent<PlayerNameSpawner>().icons.Count -1 && !ready)
        {
            iconPointer++;
            playerIcon.GetComponent<Image>().sprite = menu.GetComponent<PlayerNameSpawner>().icons[iconPointer];
            Debug.Log("Right select " + iconPointer);
        }
    }

    void OnSelect()
    {
        ready = true;

        GetComponent<PlayerDetails>().playerIcon = iconPointer;
        readyIcon.GetComponent<Image>().sprite = menu.GetComponent<PlayerNameSpawner>().readyIcons[1];

        if (!menu.GetComponent<SceneManagerScript>().playerInfo.Contains(this.gameObject))
        menu.GetComponent<SceneManagerScript>().playerInfo.Add(this.gameObject);

        UpdatePlayerCounts();
        playerReady.GetComponent<TextMeshProUGUI>().text = "Players ready: " + readyPlayers + "/" + currentControllers;
    }
}

