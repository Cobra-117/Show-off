using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneAfterVideo : MonoBehaviour
{
    public bool loaderCalled = false;
    UnityEngine.Video.VideoPlayer videoPlayer;
    // Start is called before the first frame update
    void Start()
    {
        videoPlayer = GetComponent<UnityEngine.Video.VideoPlayer>();
        videoPlayer.loopPointReached += EndReached;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        if (loaderCalled == true)
            return;
        //Debug.Log("end reached");
        loaderCalled = false;
        SceneManager.LoadScene("PlayScene");
    }
}
