using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;

public class NamePicker : MonoBehaviour
{
    public char[] name = new char[10];
    public TextMeshProUGUI Char1;
    public TextMeshProUGUI Char2;
    public TextMeshProUGUI Char3;
    public TextMeshProUGUI displayName;
    public TextMeshProUGUI currentChar;
    public ArrayList chars = new ArrayList();
    char[] alphabets = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
    public int alphaPointer;
    public int namePointer;
    public int iconPointer;

    // Start is called before the first frame update
    void Start()
    {
        alphaPointer = 0;
        namePointer = 0;
        iconPointer = 0;
    
        Char1.text = alphabets[0].ToString();
        Char2.text = alphabets[0].ToString();
        Char3.text = alphabets[0].ToString();
        chars.Add(Char1);
        chars.Add(Char2);
        chars.Add(Char3);
        currentChar = (TextMeshProUGUI)chars[namePointer];
    }

    void OnLeftSelect()
    {
        Debug.Log("left button");
        if (namePointer > 0)
        {
            namePointer--;
            currentChar = (TextMeshProUGUI)chars[namePointer];
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
            currentChar = (TextMeshProUGUI)chars[namePointer];
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
            currentChar.text = alphabets[alphaPointer].ToString();
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
            currentChar.text = alphabets[alphaPointer].ToString();
            Debug.Log("Down select");
        }
    }

    void OnEnter()
    {
        Debug.Log("Enter button");
        TextMeshProUGUI t;

        for (int i = 0; i < chars.Count; i++)
        {
            t = (TextMeshProUGUI)chars[i];
            name[i] = t.text[0];
        }
        
        displayName.text = new string(name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
