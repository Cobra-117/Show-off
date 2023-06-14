using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public static float timer;
    public static int second;
    
    // Start is called before the first frame update
    void Start()
    {
        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        second = (int)(timer % 60);
        GetComponent<TextMeshProUGUI>().text = "Time: \n" + second;
    }
}
