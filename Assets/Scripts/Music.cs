using UnityEngine;
using System.Collections;

public class Music : MonoBehaviour 
{
	public AudioClip nextClip;
    public AdaptiveCalculator calc;

	public bool isReadyForClip;
	
	void Start () 
	{
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
	}
}
