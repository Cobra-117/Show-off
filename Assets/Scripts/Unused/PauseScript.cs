using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
   public bool isPaused;
    
    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
        GetComponent<TextMeshProUGUI>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused)
                isPaused = false;

            else if(!isPaused)
                isPaused = true;
        }

        
        if(isPaused)
        {
            GetComponent<TextMeshProUGUI>().enabled = true;
            Time.timeScale = 0f;
        }

        else if(!isPaused)
        {
            GetComponent<TextMeshProUGUI>().enabled = false;
            Time.timeScale = 1f;
        }
    }
}
