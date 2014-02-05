using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RuleBaseScript : MonoBehaviour 
{
	public GUIScript gui;

	void Start () 
	{
	}

	void Update () 
	{
	}

	public List<string> GetKeywords()
	{
		List<string> keywords = new List<string>();

		//lead component
		string leadString = "lead_";

		switch(gui.weapon)
		{
		case GUIScript.SelectedWeapon.SWORD:
			leadString = leadString + "synth_";
			break;

		case GUIScript.SelectedWeapon.SHOTGUN:
			leadString = leadString + "guitar_";
			break;
		}

		if(gui.playerHealth == 100.0f)
		{
			leadString = leadString + "1_";
		}
		if(gui.playerHealth < 100.0f)
		{
			leadString = leadString + "2_";
		}

		keywords.Add(leadString);

		//accomp #1 component
		string accompString1 = "accomp_synth_";

		switch(gui.playerState)
		{
		case GUIScript.PlayerState.IDLE:
			accompString1 = accompString1 + "1_";
			break;
			
		case GUIScript.PlayerState.MOVING:
			accompString1 = accompString1 + "2_";
			break;
		}

		keywords.Add(accompString1);

		//rhythm component
		if(gui.playerState == GUIScript.PlayerState.MOVING)
		{
			string rhythmString = "rhythm_groove_1_";
			keywords.Add(rhythmString);
		}

        /*foreach (string s in keywords)
        {
            Debug.Log(s);
        }*/
		return keywords;
	}
}
