using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ExitGame : MonoBehaviour
{
    public GameObject quitText;
    TextMeshProUGUI t;

    // Start is called before the first frame update
    void Start()
    {
        t = quitText.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (t.enabled == false)
                t.enabled = true;
        }

        if (t.enabled == true)
        {
            if (Input.GetKeyDown(KeyCode.Backspace))
                t.enabled = false;


            else if (Input.GetKeyDown(KeyCode.Escape))
                Application.Quit();
        }
    }
}
