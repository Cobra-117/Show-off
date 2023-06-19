using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;

public class NamePicker : MonoBehaviour
{
    public char[] name = new char[10];
    public GameObject Char1;
    public GameObject Char2;
    public GameObject Char3;
    public GameObject currentChar;
    public List<GameObject> chars = new();
    char[] alphabets = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
    public int alphaPointer;
    public int namePointer;
    public int placing;

    // Start is called before the first frame update
    void Start()
    {
        alphaPointer = 0;
        namePointer = 0;

        GetLettersFromPlacing();
    
        Char1.GetComponent<TextMeshProUGUI>().text = alphabets[0].ToString();
        Char2.GetComponent<TextMeshProUGUI>().text = alphabets[0].ToString();
        Char3.GetComponent<TextMeshProUGUI>().text = alphabets[0].ToString();
        chars.Add(Char1);
        chars.Add(Char2);
        chars.Add(Char3);
        currentChar = chars[namePointer];
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
    }

    void OnLeftSelect()
    {
        Debug.Log("left button");
        if (namePointer > 0)
        {
            namePointer--;
            currentChar = chars[namePointer];
            alphaPointer = currentChar.GetComponent<textDetails>().alphaPointer;
            Debug.Log("Left select" + alphaPointer);
        }
    }

    void OnRightSelect()
    {
        Debug.Log("right button");
        if (namePointer < chars.Count - 1)
        {
            namePointer++;
            currentChar = chars[namePointer];
            alphaPointer = currentChar.GetComponent<textDetails>().alphaPointer;
            Debug.Log("Right select" + alphaPointer);
        }
    }

    void OnUpSelect()
    {
        Debug.Log("up button");
        if (alphaPointer < alphabets.Length - 1)
        {
            alphaPointer++;
            currentChar.GetComponent<textDetails>().alphaPointer = alphaPointer;
            currentChar.GetComponent<TextMeshProUGUI>().text = alphabets[alphaPointer].ToString();
            Debug.Log("Up select");
        }
    }

    void OnDownSelect()
    {
        Debug.Log("down button");
        if (alphaPointer > 0)
        {
            alphaPointer--;
            currentChar.GetComponent<textDetails>().alphaPointer = alphaPointer;
            currentChar.GetComponent<TextMeshProUGUI>().text = alphabets[alphaPointer].ToString();
            Debug.Log("Down select");
        }
    }

    void OnEnter()
    {
        Debug.Log("Enter button");
        //GameObject t;

        //for (int i = 0; i < chars.Count; i++)
        //{
        //    t = chars[i];
        //    name[i] = t.GetComponent<TextMeshProUGUI>().text[0];
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
