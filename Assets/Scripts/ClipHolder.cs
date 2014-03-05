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

    public AudioClip accomp_synth_3_1;
    public AudioClip accomp_synth_3_2;

    public AudioClip accomp_synth_4_1;
    public AudioClip accomp_synth_4_2;

	public AudioClip rhythm_drum_1_1;

    public AudioClip rhythm_drum_2_1;

    public AudioClip sting_guitar_1_1;

    public AudioClip sting_guitar_2_1;

    public AudioClip lead_trumpet_1_1;
    public AudioClip lead_trumpet_1_2;
    public AudioClip lead_trumpet_1_3;
    public AudioClip lead_trumpet_1_4;

    public AudioClip lead_trumpet_2_1;
    public AudioClip lead_trumpet_2_2;
    public AudioClip lead_trumpet_2_3;
    public AudioClip lead_trumpet_2_4;

    public AudioClip lead_trumpet_3_1;
    public AudioClip lead_trumpet_3_2;
    public AudioClip lead_trumpet_3_3;
    public AudioClip lead_trumpet_3_4;

    public AudioClip lead_trumpet_4_1;
    public AudioClip lead_trumpet_4_2;
    public AudioClip lead_trumpet_4_3;
    public AudioClip lead_trumpet_4_4;

    public AudioClip lead_trumpet_5_1;
    public AudioClip lead_trumpet_5_2;
    public AudioClip lead_trumpet_5_3;
    public AudioClip lead_trumpet_5_4;

    public AudioClip lead_trumpet_6_1;
    public AudioClip lead_trumpet_6_2;
    public AudioClip lead_trumpet_6_3;
    public AudioClip lead_trumpet_6_4;

    public AudioClip lead_trumpet_7_1;
    public AudioClip lead_trumpet_7_2;
    public AudioClip lead_trumpet_7_3;
    public AudioClip lead_trumpet_7_4;

    public AudioClip lead_trumpet_8_1;
    public AudioClip lead_trumpet_8_2;
    public AudioClip lead_trumpet_8_3;
    public AudioClip lead_trumpet_8_4;

    public AudioClip accomp_trombone_1_1;
    public AudioClip accomp_trombone_1_2;
    public AudioClip accomp_trombone_1_3;
    public AudioClip accomp_trombone_1_4;

    public AudioClip accomp_trombone_2_1;
    public AudioClip accomp_trombone_2_2;
    public AudioClip accomp_trombone_2_3;
    public AudioClip accomp_trombone_2_4;

    public AudioClip accomp_trombone_3_1;
    public AudioClip accomp_trombone_3_2;
    public AudioClip accomp_trombone_3_3;
    public AudioClip accomp_trombone_3_4;

    public AudioClip accomp_trombone_4_1;
    public AudioClip accomp_trombone_4_2;
    public AudioClip accomp_trombone_4_3;
    public AudioClip accomp_trombone_4_4;

    public AudioClip rhythm_timp_1_1;
    public AudioClip rhythm_timp_1_2;

    public AudioClip rhythm_timp_2_1;
    public AudioClip rhythm_timp_2_2;

    public AudioClip sting_horn_1_1;

    public AudioClip sting_horn_2_1;

    private int samplesK;
    private int samplesSN;

	public Dictionary<string, float[]> datas = new Dictionary<string, float[]>();

	// Use this for initialization
	void Start () 
	{
        //ninja clips
        samplesSN = lead_synth_1_1.samples;

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

        datas.Add("accomp_synth_3_1", GetDataFromClip(accomp_synth_3_1));
        datas.Add("accomp_synth_3_2", GetDataFromClip(accomp_synth_3_2));
        datas.Add("accomp_synth_3_3", GetDataFromClip(accomp_synth_3_1));
        datas.Add("accomp_synth_3_4", GetDataFromClip(accomp_synth_3_2));

        datas.Add("accomp_synth_4_1", GetDataFromClip(accomp_synth_4_1));
        datas.Add("accomp_synth_4_2", GetDataFromClip(accomp_synth_4_2));
        datas.Add("accomp_synth_4_3", GetDataFromClip(accomp_synth_4_1));
        datas.Add("accomp_synth_4_4", GetDataFromClip(accomp_synth_4_2));

        datas.Add("rhythm_groove_1_1", GetDataFromClip(rhythm_drum_1_1));
        datas.Add("rhythm_groove_1_2", GetDataFromClip(rhythm_drum_1_1));
        datas.Add("rhythm_groove_1_3", GetDataFromClip(rhythm_drum_1_1));
        datas.Add("rhythm_groove_1_4", GetDataFromClip(rhythm_drum_1_1));

        datas.Add("rhythm_groove_2_1", GetDataFromClip(rhythm_drum_2_1));
        datas.Add("rhythm_groove_2_2", GetDataFromClip(rhythm_drum_2_1));
        datas.Add("rhythm_groove_2_3", GetDataFromClip(rhythm_drum_2_1));
        datas.Add("rhythm_groove_2_4", GetDataFromClip(rhythm_drum_2_1));

        datas.Add("sting_guitar_1_1", GetDataFromClip(sting_guitar_1_1));

        datas.Add("sting_guitar_2_1", GetDataFromClip(sting_guitar_2_1));

        //knight clips
        samplesK = lead_trumpet_1_1.samples;

        datas.Add("lead_trumpet_1_1", GetDataFromClip(lead_trumpet_1_1));
        datas.Add("lead_trumpet_1_2", GetDataFromClip(lead_trumpet_1_2));
        datas.Add("lead_trumpet_1_3", GetDataFromClip(lead_trumpet_1_3));
        datas.Add("lead_trumpet_1_4", GetDataFromClip(lead_trumpet_1_4));

        datas.Add("lead_trumpet_2_1", GetDataFromClip(lead_trumpet_2_1));
        datas.Add("lead_trumpet_2_2", GetDataFromClip(lead_trumpet_2_2));
        datas.Add("lead_trumpet_2_3", GetDataFromClip(lead_trumpet_2_3));
        datas.Add("lead_trumpet_2_4", GetDataFromClip(lead_trumpet_2_4));

        datas.Add("lead_trumpet_3_1", GetDataFromClip(lead_trumpet_3_1));
        datas.Add("lead_trumpet_3_2", GetDataFromClip(lead_trumpet_3_2));
        datas.Add("lead_trumpet_3_3", GetDataFromClip(lead_trumpet_3_3));
        datas.Add("lead_trumpet_3_4", GetDataFromClip(lead_trumpet_3_4));

        datas.Add("lead_trumpet_4_1", GetDataFromClip(lead_trumpet_4_1));
        datas.Add("lead_trumpet_4_2", GetDataFromClip(lead_trumpet_4_2));
        datas.Add("lead_trumpet_4_3", GetDataFromClip(lead_trumpet_4_3));
        datas.Add("lead_trumpet_4_4", GetDataFromClip(lead_trumpet_4_4));

        datas.Add("lead_trumpet_5_1", GetDataFromClip(lead_trumpet_5_1));
        datas.Add("lead_trumpet_5_2", GetDataFromClip(lead_trumpet_5_2));
        datas.Add("lead_trumpet_5_3", GetDataFromClip(lead_trumpet_5_3));
        datas.Add("lead_trumpet_5_4", GetDataFromClip(lead_trumpet_5_4));

        datas.Add("lead_trumpet_6_1", GetDataFromClip(lead_trumpet_6_1));
        datas.Add("lead_trumpet_6_2", GetDataFromClip(lead_trumpet_6_2));
        datas.Add("lead_trumpet_6_3", GetDataFromClip(lead_trumpet_6_3));
        datas.Add("lead_trumpet_6_4", GetDataFromClip(lead_trumpet_6_4));

        datas.Add("lead_trumpet_7_1", GetDataFromClip(lead_trumpet_7_1));
        datas.Add("lead_trumpet_7_2", GetDataFromClip(lead_trumpet_7_2));
        datas.Add("lead_trumpet_7_3", GetDataFromClip(lead_trumpet_7_3));
        datas.Add("lead_trumpet_7_4", GetDataFromClip(lead_trumpet_7_4));

        datas.Add("lead_trumpet_8_1", GetDataFromClip(lead_trumpet_8_1));
        datas.Add("lead_trumpet_8_2", GetDataFromClip(lead_trumpet_8_2));
        datas.Add("lead_trumpet_8_3", GetDataFromClip(lead_trumpet_8_3));
        datas.Add("lead_trumpet_8_4", GetDataFromClip(lead_trumpet_8_4));

        datas.Add("accomp_trombone_1_1", GetDataFromClip(accomp_trombone_1_1));
        datas.Add("accomp_trombone_1_2", GetDataFromClip(accomp_trombone_1_2));
        datas.Add("accomp_trombone_1_3", GetDataFromClip(accomp_trombone_1_3));
        datas.Add("accomp_trombone_1_4", GetDataFromClip(accomp_trombone_1_4));

        datas.Add("accomp_trombone_2_1", GetDataFromClip(accomp_trombone_2_1));
        datas.Add("accomp_trombone_2_2", GetDataFromClip(accomp_trombone_2_2));
        datas.Add("accomp_trombone_2_3", GetDataFromClip(accomp_trombone_2_3));
        datas.Add("accomp_trombone_2_4", GetDataFromClip(accomp_trombone_2_4));

        datas.Add("accomp_trombone_3_1", GetDataFromClip(accomp_trombone_3_1));
        datas.Add("accomp_trombone_3_2", GetDataFromClip(accomp_trombone_3_2));
        datas.Add("accomp_trombone_3_3", GetDataFromClip(accomp_trombone_3_3));
        datas.Add("accomp_trombone_3_4", GetDataFromClip(accomp_trombone_3_4));

        datas.Add("accomp_trombone_4_1", GetDataFromClip(accomp_trombone_4_1));
        datas.Add("accomp_trombone_4_2", GetDataFromClip(accomp_trombone_4_2));
        datas.Add("accomp_trombone_4_3", GetDataFromClip(accomp_trombone_4_1));
        datas.Add("accomp_trombone_4_4", GetDataFromClip(accomp_trombone_4_2));

        datas.Add("rhythm_timp_1_1", GetDataFromClip(rhythm_timp_1_1));
        datas.Add("rhythm_timp_1_2", GetDataFromClip(rhythm_timp_1_2));
        datas.Add("rhythm_timp_1_3", GetDataFromClip(rhythm_timp_1_1));
        datas.Add("rhythm_timp_1_4", GetDataFromClip(rhythm_timp_1_2));

        datas.Add("rhythm_timp_2_1", GetDataFromClip(rhythm_timp_2_1));
        datas.Add("rhythm_timp_2_2", GetDataFromClip(rhythm_timp_2_2));
        datas.Add("rhythm_timp_2_3", GetDataFromClip(rhythm_timp_2_1));
        datas.Add("rhythm_timp_2_4", GetDataFromClip(rhythm_timp_2_2));

        datas.Add("sting_horn_1_1", GetDataFromClip(sting_horn_1_1));

        datas.Add("sting_horn_2_1", GetDataFromClip(sting_horn_2_1));
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

    public int GetSampleLength(GUIScript.PlayerCharacter character)
    {
        switch (character)
        {
            case (GUIScript.PlayerCharacter.SPACENINJA):
                return samplesSN;

            case (GUIScript.PlayerCharacter.KNIGHT):
                return samplesK;   
        }
        Debug.Log("oh god why");
        //shouldn't happen
        return 0;
    }
}
