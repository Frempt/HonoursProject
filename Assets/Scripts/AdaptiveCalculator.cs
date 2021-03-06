﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AdaptiveCalculator : MonoBehaviour 
{
	public Music music;
	public ClipHolder clipHolder;
	public RuleBaseScript rules;

	private int segment = 1;
	private const int MAX_SEGMENT = 4;

	private AudioClip final;
	private float[] finalData;

	private System.Threading.Thread thread;
	private bool isDone = false;

	private List<string> keywords = new List<string>();

	// Use this for initialization
	void Start () 
	{
        thread = new System.Threading.Thread(Run);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(isDone)
		{
			OnThreadFinished();
            isDone = false;
            thread = null;
		}
	}

    public void GetNewClip()
    {
        keywords = rules.GetKeywords();
        thread = new System.Threading.Thread(Run);
        thread.Start();
    }

	public void Run()
	{
		finalData = new float[clipHolder.GetSampleLength(rules.gui.character)];

		for(int i = 0; i < keywords.Count; i++)
		{
            string clipName = keywords[i] + segment;
			float[] clipData = clipHolder.GetClipDataFromString(clipName);

            for (int j = 0; j < finalData.Length; j++)
            {
                finalData[j] += clipData[j];
            }
		}

        isDone = true;
	}

	public void OnThreadFinished()
	{
		final = AudioClip.Create("final", finalData.Length, 1, 44100, false, false);
		final.SetData(finalData, 0);

		music.nextClip = final;
		isDone = false;
        
		if(segment >= MAX_SEGMENT)
		{
			segment = 0;
		}
		segment++;
	}

    public void PlaySting(string key)
    {
        key += "1";
        float[] data = clipHolder.GetClipDataFromString(key);
        AudioClip clip = AudioClip.Create("clip", data.Length, 1, 44100, false, false);
        clip.SetData(data, 0);

        if(!music.stingSource.isPlaying) music.stingSource.clip = clip;
    }
}
