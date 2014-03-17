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

    void Start()
    {
    }

    void Update()
    {
    }

    public List<string> GetKeywords()
    {
        List<string> keywords = new List<string>();

        float enemyHealth;

        if (gui.enemyHealth.Count < 1)
        {
            gui.enemyHealth.Add(0.0f);
        }

        enemyHealth = (gui.enemyHealth.Average() * GUIScript.MAX_ENEMIES) * (100.0f / (GUIScript.MAX_ENEMY_HEALTH * GUIScript.MAX_ENEMIES));

        float fuzzyValue = fuzzy.CalculateOutput(gui.playerHealth, enemyHealth);
        Debug.Log("Fuzzy output = " + fuzzyValue);

        switch (gui.character)
        {
            case GUIScript.PlayerCharacter.SPACENINJA:
                //lead component
                string leadString = "lead_";

                switch (gui.weapon)
                {
                    case GUIScript.SelectedWeapon.SWORD:
                        leadString = leadString + "synth_";
                        break;

                    case GUIScript.SelectedWeapon.SHOTGUN:
                        leadString = leadString + "guitar_";
                        break;
                }

                if (fuzzyValue >= 88.0f)
                {
                    leadString = leadString + "1_";
                }
                else if (fuzzyValue >= 76.0f)
                {
                    leadString = leadString + "2_";
                }
                else if (fuzzyValue >= 64.0f)
                {
                    leadString = leadString + "3_";
                }
                else if (fuzzyValue >= 52.0f)
                {
                    leadString = leadString + "4_";
                }
                else if (fuzzyValue >= 40.0f)
                {
                    leadString = leadString + "5_";
                }
                else if (fuzzyValue >= 28.0f)
                {
                    leadString = leadString + "6_";
                }
                else if (fuzzyValue >= 16.0f)
                {
                    leadString = leadString + "7_";
                }
                else
                {
                    leadString = leadString + "8_";
                }

                keywords.Add(leadString);

                //accomp #1 component
                string accompString1 = "accomp_synth_";

                if (fuzzyValue >= 75.0f)
                {
                    accompString1 = accompString1 + "1_";
                }
                else if (fuzzyValue >= 50.0f)
                {
                    accompString1 = accompString1 + "2_";
                }
                else if (fuzzyValue >= 25.0f)
                {
                    accompString1 = accompString1 + "3_";
                }
                else
                {
                    accompString1 = accompString1 + "4_";
                }

                keywords.Add(accompString1);

                //rhythm component
                if (gui.playerState == GUIScript.PlayerState.MOVING)
                {
                    string rhythmString = "rhythm_groove_";

                    if (fuzzyValue >= 50.0f)
                    {
                        rhythmString = rhythmString + "1_";
                    }
                    else
                    {
                        rhythmString = rhythmString + "2_";
                    }

                    keywords.Add(rhythmString);
                }
                break;

            case GUIScript.PlayerCharacter.KNIGHT:
                //lead component
                string leadKString = "lead_";

                switch (gui.weapon)
                {
                    case GUIScript.SelectedWeapon.SWORD:
                        leadKString = leadKString + "trumpet_";
                        break;

                    case GUIScript.SelectedWeapon.SHOTGUN:
                        leadKString = leadKString + "violin_";
                        break;
                }

                if (fuzzyValue >= 88.0f)
                {
                    leadKString = leadKString + "1_";
                }
                else if (fuzzyValue >= 76.0f)
                {
                    leadKString = leadKString + "2_";
                }
                else if (fuzzyValue >= 64.0f)
                {
                    leadKString = leadKString + "3_";
                }
                else if (fuzzyValue >= 52.0f)
                {
                    leadKString = leadKString + "4_";
                }
                else if (fuzzyValue >= 40.0f)
                {
                    leadKString = leadKString + "5_";
                }
                else if (fuzzyValue >= 28.0f)
                {
                    leadKString = leadKString + "6_";
                }
                else if (fuzzyValue >= 16.0f)
                {
                    leadKString = leadKString + "7_";
                }
                else
                {
                    leadKString = leadKString + "8_";
                }

                keywords.Add(leadKString);

                //accomp #1 component
                string accompKString1 = "accomp_trombone_";

                if (fuzzyValue >= 75.0f)
                {
                    accompKString1 = accompKString1 + "1_";
                }
                else if (fuzzyValue >= 50.0f)
                {
                    accompKString1 = accompKString1 + "2_";
                }
                else if (fuzzyValue >= 25.0f)
                {
                    accompKString1 = accompKString1 + "3_";
                }
                else
                {
                    accompKString1 = accompKString1 + "4_";
                }

                keywords.Add(accompKString1);

                //rhythm component
                if (gui.playerState == GUIScript.PlayerState.MOVING)
                {
                    string rhythmKString = "rhythm_timp_";

                    if (fuzzyValue >= 50.0f)
                    {
                        rhythmKString = rhythmKString + "1_";
                    }
                    else
                    {
                        rhythmKString = rhythmKString + "2_";
                    }

                    keywords.Add(rhythmKString);
                }
                break;
        }
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
