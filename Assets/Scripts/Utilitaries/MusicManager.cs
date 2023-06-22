using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource[] musicSources;

    public int musicBPM;
    public int timeSignature;
    public int barsLength;

    private float loopPointMinutes;
    private float loopPointSeconds;
	private double time;
	private int nextSource;

    


    // Start is called before the first frame update
	void Start () 
	{
		loopPointMinutes = (barsLength * timeSignature) / musicBPM;
	
		loopPointSeconds = loopPointMinutes * 60;
	
		time = AudioSettings.dspTime;
	
		musicSources[0].Play();
		nextSource = 1;
	}
	

    void Update () 
	{
		if (transform.position.x>10)
		{
            StartCoroutine("MusicSwitch", 2.0f);


            //Debug.Log(transform.position.x);
		}
	}

    private IEnumerator MusicSwitch(float waitTime)
    {

        if (!musicSources[nextSource].isPlaying)
		{
			time = time + loopPointSeconds;
	
			musicSources[nextSource].PlayScheduled(time);
	
			nextSource = 1 - nextSource; //Switch to other AudioSource
		}

       
            yield return new WaitForSeconds(waitTime);
            print("WaitAndPrint " + Time.time);
    }

}
