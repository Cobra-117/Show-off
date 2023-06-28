using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip [] clips;
    AudioSource audioSource;
    int currentClip;
    public int currentChunk = -1;

    public bool shouldChangeClip = false;

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
        if (shouldChangeClip == true && !audioSource.isPlaying)
        {
            audioSource.clip = clips[currentClip];
            audioSource.Play();
            shouldChangeClip = false;
            audioSource.loop = true;
            Debug.Log("changed clip");
        }
    }

    public void UpdateChunk()
    {
        currentChunk += 1;
        if (currentClip + 1 < clips.Length && currentChunk > 0 
        && currentChunk % 2 == 0)
        {
            currentClip += 1;
            shouldChangeClip = true;
            audioSource.loop = false;
        }
    }
}
