using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Xml.Serialization;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class TextEditor : MonoBehaviour
{
    //public char[] name = new char[10];
    //public TextMeshProUGUI Char1;
    //public TextMeshProUGUI Char2;
    //public TextMeshProUGUI Char3;
    //public TextMeshProUGUI displayName;
    //public TextMeshProUGUI currentChar;
    //public ArrayList chars = new ArrayList();
    GameObject playerReady;
    Transform playerIcon;
    Transform readyIcon;
    GameObject menu;

    char[] alphabets = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
    
    public int alphaPointer = 0;
    public int namePointer = 0;
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
        //Char1.text = alphabets[0].ToString();
        //Char2.text = alphabets[0].ToString();
        //Char3.text = alphabets[0].ToString();
        //chars.Add(Char1);
        //chars.Add(Char2);
        //chars.Add(Char3);
        //alphaPointer = 0;
        //namePointer = 0;
        //currentChar = (TextMeshProUGUI)chars[namePointer];
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
        
        //if (namePointer > 0)
        //{
        //    namePointer--;
        //    currentChar = (TextMeshProUGUI)chars[namePointer];
        //    alphaPointer = currentChar.GetComponent<textDetails>().alphaPointer;
        //    Debug.Log("Left select" + alphaPointer);
        //}


    }

    void OnRightSelect()
    {
        if (iconPointer < menu.GetComponent<PlayerNameSpawner>().icons.Count -1 && !ready)
        {
            iconPointer++;
            playerIcon.GetComponent<Image>().sprite = menu.GetComponent<PlayerNameSpawner>().icons[iconPointer];
            Debug.Log("Right select " + iconPointer);
        }
        //if (namePointer < chars.Count - 1)
        //{
        //    namePointer++;
        //    currentChar = (TextMeshProUGUI)chars[namePointer];
        //    alphaPointer = currentChar.GetComponent<textDetails>().alphaPointer;
        //    Debug.Log("Right select" + alphaPointer);
        //}
    }

    //void OnUpSelect()
    //{
    //    if(alphaPointer < alphabets.Length - 1)
    //    {
    //        alphaPointer++;
    //        currentChar.GetComponent<textDetails>().alphaPointer = alphaPointer;
    //        currentChar.text = alphabets[alphaPointer].ToString();
    //        Debug.Log("Up select");
    //    }
    //}

    //void OnDownSelect()
    //{
    //    if (alphaPointer > 0)
    //    {
    //        alphaPointer--;
    //        currentChar.GetComponent<textDetails>().alphaPointer = alphaPointer;
    //        currentChar.text = alphabets[alphaPointer].ToString();
    //        Debug.Log("Down select");
    //    }
    //}

    void OnEnter()
    {
        ready = true;

        GetComponent<PlayerDetails>().playerIcon = iconPointer;
        readyIcon.GetComponent<Image>().sprite = menu.GetComponent<PlayerNameSpawner>().readyIcons[1];
        //TextMeshProUGUI t;
        //Debug.Log("Enter select");
        //for(int i=0; i< chars.Count; i++)
        //{
        //    t = (TextMeshProUGUI)chars[i];
        //    name[i] = t.text[0];
        //}
        ////displayName.text = new string(name);
        //displayName.text = "Player " + GetComponent<PlayerDetails>().playerID + " Ready";

        if (!SceneManagerScript.playerInfo.Contains(this.gameObject))
        SceneManagerScript.playerInfo.Add(this.gameObject);

        //readyPlayers = SceneManagerScript.playerInfo.Count.ToString();
        //currentControllers = SceneManagerScript.controllerCount.ToString();

        UpdatePlayerCounts();
        playerReady.GetComponent<TextMeshProUGUI>().text = "Players ready: " + readyPlayers + "/" + currentControllers;

        Debug.Log("Player count: " + SceneManagerScript.controllerCount);
        Debug.Log("Ready players: " + SceneManagerScript.playerInfo.Count);
    }
}

