using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;

public class NamePicker : MonoBehaviour
{
    public char[] finalName = new char[10];
    public GameObject Char1;
    public GameObject Char2;
    public GameObject Char3;
    public GameObject currentChar;
    public List<GameObject> chars = new();
    char[] alphabets = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
    public int alphaPointer;
    public int namePointer;
    public int placing;
    public Color currentCharColor;
    public Color nameEnteredColor;
    public bool nameEntered;
    GameObject countdown;
    GameObject restartText;

    // Start is called before the first frame update
    void Start()
    {
        nameEntered = false;
        alphaPointer = 0;
        namePointer = 0;
        currentCharColor = Color.yellow;
        nameEnteredColor = Color.green;

        if(placing !=0)
        GetLettersFromPlacing();
    
        countdown = GameObject.Find("Till reload");
        restartText = GameObject.Find("PlayerRestart");
    }

    void GetLettersFromPlacing()
    {
        if (placing == 1)
        {
            Char1 = GameObject.Find("L1_1st");
            Char2 = GameObject.Find("L2_1st");
            Char3 = GameObject.Find("L3_1st");
        }

        else if (placing == 2)
        {
            Char1 = GameObject.Find("L1_2nd");
            Char2 = GameObject.Find("L2_2nd");
            Char3 = GameObject.Find("L3_2nd");
        }

        if (placing == 3)
        {
            Char1 = GameObject.Find("L1_3rd");
            Char2 = GameObject.Find("L2_3rd");
            Char3 = GameObject.Find("L3_3rd");
        }

        Char1.GetComponent<TextMeshProUGUI>().text = alphabets[0].ToString();
        Char2.GetComponent<TextMeshProUGUI>().text = alphabets[0].ToString();
        Char3.GetComponent<TextMeshProUGUI>().text = alphabets[0].ToString();
        chars.Add(Char1);
        chars.Add(Char2);
        chars.Add(Char3);

        Char1.GetComponent<TextMeshProUGUI>().color = currentCharColor;
        currentChar = chars[namePointer];
    }

    void OnLeftSelect()
    {
        //Debug.Log("left button");
        if (namePointer > 0 && !nameEntered && placing != 0)
        {
            currentChar.GetComponent<TextMeshProUGUI>().color = Color.white;
            namePointer--;
            currentChar = chars[namePointer];
            currentChar.GetComponent<TextMeshProUGUI>().color = currentCharColor;
            alphaPointer = currentChar.GetComponent<textDetails>().alphaPointer;
            //Debug.Log("Left select" + alphaPointer);
        }
    }

    void OnRightSelect()
    {
        //Debug.Log("right button");
        if (namePointer < chars.Count - 1 && !nameEntered && placing != 0)
        {
            currentChar.GetComponent<TextMeshProUGUI>().color = Color.white;
            namePointer++;
            currentChar = chars[namePointer];
            currentChar.GetComponent<TextMeshProUGUI>().color = currentCharColor;
            alphaPointer = currentChar.GetComponent<textDetails>().alphaPointer;
            //Debug.Log("Right select" + alphaPointer);
        }
    }

    void OnUpSelect()
    {
       //Debug.Log("up button");
        if (alphaPointer < alphabets.Length - 1 && !nameEntered && placing != 0)
        {
            alphaPointer++;
            currentChar.GetComponent<textDetails>().alphaPointer = alphaPointer;
            currentChar.GetComponent<TextMeshProUGUI>().text = alphabets[alphaPointer].ToString();
            //Debug.Log("Up select");
        }
    }

    void OnDownSelect()
    {
        //Debug.Log("down button");
        if (alphaPointer > 0 && !nameEntered && placing != 0)
        {
            alphaPointer--;
            currentChar.GetComponent<textDetails>().alphaPointer = alphaPointer;
            currentChar.GetComponent<TextMeshProUGUI>().text = alphabets[alphaPointer].ToString();
            //Debug.Log("Down select");
        }
    }

    private void OnSelect()
    {
        if(!nameEntered)
        {
            IncreaseReadyPlayers();
        }
        
        nameEntered = true;
    }

    void OnEnter()
    {     
        if(!nameEntered && placing != 0)
        {
            GetComponent<PlayerDetails>().playerName += chars[0].GetComponent<TextMeshProUGUI>().text.ToString();
            GetComponent<PlayerDetails>().playerName += chars[1].GetComponent<TextMeshProUGUI>().text.ToString();
            GetComponent<PlayerDetails>().playerName += chars[2].GetComponent<TextMeshProUGUI>().text.ToString();

            currentCharColor = nameEnteredColor;
            for (int i = 0; i < chars.Count; i++)
            {
                chars[i].GetComponent<TextMeshProUGUI>().color = nameEnteredColor;
            }
            countdown.GetComponent<ResetGame>().pInfo.Add(new PlayerInformation(GetComponent<PlayerDetails>().playerID, GetComponent<PlayerDetails>().playerScore, GetComponent<PlayerDetails>().playerName));
            IncreaseReadyPlayers();
            
        }
        nameEntered = true;
    }

    private void IncreaseReadyPlayers()
    {
        countdown.GetComponent<ResetGame>().readyPlayers++;
        restartText.GetComponent<TextMeshProUGUI>().text += new string("\nPlayer " + GetComponent<PlayerDetails>().playerID + " ready");
    }
}
