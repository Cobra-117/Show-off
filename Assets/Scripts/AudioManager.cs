using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip [] clips;
    AudioSource audioSource;
    int currentClip;
    public int currentChunk = -1;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = clips[0];
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateChunk()
    {
        currentChunk += 1;
        if (currentClip + 1 < clips.Length && currentChunk > 0 
        && currentChunk % 2 == 0)
        {
            currentClip += 1;
            audioSource.clip = clips[currentClip];
            audioSource.Play();
        }
    }
}
