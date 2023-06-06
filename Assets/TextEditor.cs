using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class TextEditor : MonoBehaviour
{
    public char[] name = new char[10];
    public TextMeshProUGUI Char1;
    public TextMeshProUGUI Char2;
    public TextMeshProUGUI Char3;
    public TextMeshProUGUI displayName;
    public TextMeshProUGUI currentChar;
    public ArrayList chars = new ArrayList();

    char[] alphabets = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
    
    public int alphaPointer = 0;
    public int namePointer = 0;

    // Start is called before the first frame update
    void Start()
    {
        SceneManagerScript.controllerCount++;
        Char1.text = alphabets[0].ToString();
        Char2.text = alphabets[0].ToString();
        Char3.text = alphabets[0].ToString();
        chars.Add(Char1);
        chars.Add(Char2);
        chars.Add(Char3);
        alphaPointer = 0;
        namePointer = 0;
        currentChar = (TextMeshProUGUI)chars[namePointer];
    }

    void OnLeftSelect()
    {
        if(namePointer > 0)
        {
            namePointer--;
            currentChar = (TextMeshProUGUI)chars[namePointer];
            alphaPointer = currentChar.GetComponent<textDetails>().alphaPointer;
            Debug.Log("Left select" + alphaPointer);
        }
    }

    void OnRightSelect()
    {
        if (namePointer < chars.Count - 1)
        {
            namePointer++;
            currentChar = (TextMeshProUGUI)chars[namePointer];
            alphaPointer = currentChar.GetComponent<textDetails>().alphaPointer;
            Debug.Log("Right select" + alphaPointer);
        }
    }

    void OnUpSelect()
    {
        if(alphaPointer < alphabets.Length - 1)
        {
            alphaPointer++;
            currentChar.GetComponent<textDetails>().alphaPointer = alphaPointer;
            currentChar.text = alphabets[alphaPointer].ToString();
            Debug.Log("Up select");
        }
    }

    void OnDownSelect()
    {
        if (alphaPointer > 0)
        {
            alphaPointer--;
            currentChar.GetComponent<textDetails>().alphaPointer = alphaPointer;
            currentChar.text = alphabets[alphaPointer].ToString();
            Debug.Log("Down select");
        }
    }

    void OnEnter()
    {
        TextMeshProUGUI t;

        Debug.Log("Enter select");
        for(int i=0; i< chars.Count; i++)
        {
            t = (TextMeshProUGUI)chars[i];
            name[i] = t.text[0];
        }
        //displayName.text = new string(name);
        displayName.text = "Player " + GetComponent<PlayerDetails>().playerID + " Ready";

        if (!SceneManagerScript.playerInfo.Contains(this.gameObject))
        SceneManagerScript.playerInfo.Add(this.gameObject);


        Debug.Log("Player count: " + SceneManagerScript.controllerCount);
        Debug.Log("Ready players: " + SceneManagerScript.playerInfo.Count);
    }
}

