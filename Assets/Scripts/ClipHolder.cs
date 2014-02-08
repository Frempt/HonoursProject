using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ClipHolder : MonoBehaviour 
{
	//theme_instrument_variation_segment
	public AudioClip lead_synth_1_1;
	public AudioClip lead_synth_1_2;
	public AudioClip lead_synth_1_3;
	public AudioClip lead_synth_1_4;

	public AudioClip lead_synth_2_1;
	public AudioClip lead_synth_2_2;
	public AudioClip lead_synth_2_3;
	public AudioClip lead_synth_2_4;

    public AudioClip lead_synth_3_1;
    public AudioClip lead_synth_3_2;
    public AudioClip lead_synth_3_3;
    public AudioClip lead_synth_3_4;

    public AudioClip lead_synth_4_1;
    public AudioClip lead_synth_4_2;
    public AudioClip lead_synth_4_3;
    public AudioClip lead_synth_4_4;

    public AudioClip lead_synth_5_1;
    public AudioClip lead_synth_5_2;
    public AudioClip lead_synth_5_3;
    public AudioClip lead_synth_5_4;

    public AudioClip lead_synth_6_1;
    public AudioClip lead_synth_6_2;
    public AudioClip lead_synth_6_3;
    public AudioClip lead_synth_6_4;

    public AudioClip lead_synth_7_1;
    public AudioClip lead_synth_7_2;
    public AudioClip lead_synth_7_3;
    public AudioClip lead_synth_7_4;

    public AudioClip lead_synth_8_1;
    public AudioClip lead_synth_8_2;
    public AudioClip lead_synth_8_3;
    public AudioClip lead_synth_8_4;

	public AudioClip accomp_synth_1_1;
	public AudioClip accomp_synth_1_2;

	public AudioClip accomp_synth_2_1;
	public AudioClip accomp_synth_2_2;

	public AudioClip rhythm_drum_1_1;

    public AudioClip sting_guitar_1_1;

    public AudioClip sting_guitar_2_1;

	public int sampleLength;

	public Dictionary<string, float[]> datas = new Dictionary<string, float[]>();

	// Use this for initialization
	void Start () 
	{
		sampleLength = lead_synth_1_1.samples;

		datas.Add("lead_synth_1_1", GetDataFromClip(lead_synth_1_1));
		datas.Add("lead_synth_1_2", GetDataFromClip(lead_synth_1_2));
		datas.Add("lead_synth_1_3", GetDataFromClip(lead_synth_1_3));
		datas.Add("lead_synth_1_4", GetDataFromClip(lead_synth_1_4));

		datas.Add("lead_synth_2_1", GetDataFromClip(lead_synth_2_1));
		datas.Add("lead_synth_2_2", GetDataFromClip(lead_synth_2_2));
		datas.Add("lead_synth_2_3", GetDataFromClip(lead_synth_2_3));
		datas.Add("lead_synth_2_4", GetDataFromClip(lead_synth_2_4));

        datas.Add("lead_synth_3_1", GetDataFromClip(lead_synth_3_1));
        datas.Add("lead_synth_3_2", GetDataFromClip(lead_synth_3_2));
        datas.Add("lead_synth_3_3", GetDataFromClip(lead_synth_3_3));
        datas.Add("lead_synth_3_4", GetDataFromClip(lead_synth_3_4));

        datas.Add("lead_synth_4_1", GetDataFromClip(lead_synth_4_1));
        datas.Add("lead_synth_4_2", GetDataFromClip(lead_synth_4_2));
        datas.Add("lead_synth_4_3", GetDataFromClip(lead_synth_4_3));
        datas.Add("lead_synth_4_4", GetDataFromClip(lead_synth_4_4));

        datas.Add("lead_synth_5_1", GetDataFromClip(lead_synth_5_1));
        datas.Add("lead_synth_5_2", GetDataFromClip(lead_synth_5_2));
        datas.Add("lead_synth_5_3", GetDataFromClip(lead_synth_5_3));
        datas.Add("lead_synth_5_4", GetDataFromClip(lead_synth_5_4));

        datas.Add("lead_synth_6_1", GetDataFromClip(lead_synth_6_1));
        datas.Add("lead_synth_6_2", GetDataFromClip(lead_synth_6_2));
        datas.Add("lead_synth_6_3", GetDataFromClip(lead_synth_6_3));
        datas.Add("lead_synth_6_4", GetDataFromClip(lead_synth_6_4));

        datas.Add("lead_synth_7_1", GetDataFromClip(lead_synth_7_1));
        datas.Add("lead_synth_7_2", GetDataFromClip(lead_synth_7_2));
        datas.Add("lead_synth_7_3", GetDataFromClip(lead_synth_7_3));
        datas.Add("lead_synth_7_4", GetDataFromClip(lead_synth_7_4));

        datas.Add("lead_synth_8_1", GetDataFromClip(lead_synth_8_1));
        datas.Add("lead_synth_8_2", GetDataFromClip(lead_synth_8_2));
        datas.Add("lead_synth_8_3", GetDataFromClip(lead_synth_8_3));
        datas.Add("lead_synth_8_4", GetDataFromClip(lead_synth_8_4));

		datas.Add("accomp_synth_1_1", GetDataFromClip(accomp_synth_1_1));
		datas.Add("accomp_synth_1_2", GetDataFromClip(accomp_synth_1_2));
		datas.Add("accomp_synth_1_3", GetDataFromClip(accomp_synth_1_1));
		datas.Add("accomp_synth_1_4", GetDataFromClip(accomp_synth_1_2));

		datas.Add("accomp_synth_2_1", GetDataFromClip(accomp_synth_2_1));
		datas.Add("accomp_synth_2_2", GetDataFromClip(accomp_synth_2_2));
		datas.Add("accomp_synth_2_3", GetDataFromClip(accomp_synth_2_1));
		datas.Add("accomp_synth_2_4", GetDataFromClip(accomp_synth_2_2));

        datas.Add("rhythm_groove_1_1", GetDataFromClip(rhythm_drum_1_1));
        datas.Add("rhythm_groove_1_2", GetDataFromClip(rhythm_drum_1_1));
        datas.Add("rhythm_groove_1_3", GetDataFromClip(rhythm_drum_1_1));
        datas.Add("rhythm_groove_1_4", GetDataFromClip(rhythm_drum_1_1));

        datas.Add("sting_guitar_1_1", GetDataFromClip(sting_guitar_1_1));

        datas.Add("sting_guitar_2_1", GetDataFromClip(sting_guitar_2_1));
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public float[] GetClipDataFromString(string clipName)
	{
		float[] returnData;
		if(datas.TryGetValue(clipName, out returnData))
		{
			return returnData;
		}
		else
		{
			return null;
		}
	}

	private float[] GetDataFromClip(AudioClip clip)
	{
		float[] data = new float[clip.samples];
		clip.GetData(data, 0);
		return data;
	}
}
