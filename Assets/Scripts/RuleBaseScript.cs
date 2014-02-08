using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class RuleBaseScript : MonoBehaviour 
{
	public GUIScript gui;
    public FuzzyScript fuzzy;
    public AdaptiveCalculator calc;

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

        float fuzzyValue;

        if (gui.enemyHealth.Count < 1)
        {
            fuzzyValue = fuzzy.CalculateOutput(gui.playerHealth, 0.0f);
        }
        else fuzzyValue = fuzzy.CalculateOutput(gui.playerHealth, gui.enemyHealth.Average() * (100.0f/GUIScript.MAX_ENEMY_HEALTH));
        Debug.Log("Fuzzy output = " + fuzzyValue);

        if (gui.enemyHealth.Count > 0)
        {
            if (fuzzyValue == 100.0f)
            {
                leadString = leadString + "1_";
            }
            else if (fuzzyValue < 100.0f && fuzzyValue >= 90.0f)
            {
                leadString = leadString + "2_";
            }
            else if (fuzzyValue < 90.0f && fuzzyValue >= 80.0f)
            {
                leadString = leadString + "3_";
            }
            else if (fuzzyValue < 80.0f && fuzzyValue >= 70.0f)
            {
                leadString = leadString + "4_";
            }
            else if (fuzzyValue < 70.0f && fuzzyValue >= 60.0f)
            {
                leadString = leadString + "5_";
            }
            else if (fuzzyValue < 60.0f && fuzzyValue >= 50.0f)
            {
                leadString = leadString + "6_";
            }
            else if (fuzzyValue < 50.0f && fuzzyValue >= 40.0f)
            {
                leadString = leadString + "7_";
            }
            else if (fuzzyValue < 40.0f)
            {
                leadString = leadString + "8_";
            }

            keywords.Add(leadString);
        }

		//accomp #1 component
		string accompString1 = "accomp_synth_";

		if(fuzzyValue >= 50.0f)
		{
			accompString1 = accompString1 + "1_";
        }
        else
		{
			accompString1 = accompString1 + "2_";
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

    public void PlaySting(string key)
    {
        float fuzzyValue;

        if (gui.enemyHealth.Count < 1)
        {
            fuzzyValue = fuzzy.CalculateOutput(gui.playerHealth, 0.0f);
        }
        else fuzzyValue = fuzzy.CalculateOutput(gui.playerHealth, gui.enemyHealth.Average() * (100.0f / GUIScript.MAX_ENEMY_HEALTH));

        if (fuzzyValue >= 50.0f)
        {
            key += "1_";
        }
        else
        {
            key += "2_";
        }

        calc.PlaySting(key);
    }
}
