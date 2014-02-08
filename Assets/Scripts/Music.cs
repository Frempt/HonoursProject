using UnityEngine;
using System.Collections;

public class Music : MonoBehaviour 
{
	public AudioClip nextClip;
    public AudioSource stingSource;
    public AdaptiveCalculator calc;

	public bool isReadyForClip;
	
	void Start () 
	{
        stingSource = GetComponents<AudioSource>()[1];

		isReadyForClip = false;
        calc.GetNewClip();

		if(audio.clip != null)
		{
			audio.Play();
		}
	}
	
	void Update () 
	{
		if(audio.time >= audio.clip.length/2 && isReadyForClip)
		{
            calc.GetNewClip();
			isReadyForClip = false;
		}

		if(audio.time >= audio.clip.length)
		{
			audio.clip = nextClip;
			audio.Play();
            isReadyForClip = true;
		}

        if (stingSource.clip != null)
        {
            if (audio.time == 0.0f ||
                audio.time == audio.clip.length / 4 ||
                audio.time == audio.clip.length / 2 ||
                audio.time == (audio.clip.length / 4 + audio.clip.length / 2))
            {
                if(!stingSource.isPlaying) stingSource.Play();
            }

            if (stingSource.time >= stingSource.clip.length)
            {
                stingSource.clip = null;
            }
        }
	}
}
