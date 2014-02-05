using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class FuzzyScript : MonoBehaviour
{
    private MembershipFunction playerHealth;
    private MembershipFunction enemiesHealth;
    private MembershipFunction outputFunc;

    public float CalculateOutput(float input1, float input2)
    {
        List<KeyValuePair<string, float>> player = playerHealth.GetMembers(input1);
        List<KeyValuePair<string, float>> enemy = enemiesHealth.GetMembers(input2);
        //List<KeyValuePair<string, float>> output = new List<KeyValuePair<string, float>>();
        List<string> output = new List<string>();

        //test rules
        foreach(KeyValuePair<string, float> pairP in player)
        {
            foreach(KeyValuePair<string, float> pairE in enemy)
            {
                //if PLAYER is POSITIVELARGE AND ENEMY is NEGATIVELARGE THEN OUTPUT is POSITIVELARGE
                if(FuzzyRule.CheckConditions(pairP.Key, "POSITIVELARGE", pairE.Key, "NEGATIVELARGE"))
                {
                    output.Add("POSITIVELARGE");
                }

                //if PLAYER is NEGATIVELARGE AND ENEMY is POSITIVELARGE THEN OUTPUT is NEGATIVELARGE
                if (FuzzyRule.CheckConditions(pairP.Key, "NEGATIVELARGE", pairE.Key, "POSITIVELARGE"))
                {
                    output.Add("NEGATIVELARGE");
                }
            }
        }

        //get values for defuzzification
        List<string> uniqueOutput = new List<string>();
        List<float> fuzzyValues = new List<float>();

        for (int i = 0; i < output.Count; i++)
        {
            if(!uniqueOutput.Contains(output[i]))
            {
                uniqueOutput.Add(output[i]);
                fuzzyValues.Add(outputFunc.GetValueFromName(output[i]));
            }
        }

        return Defuzzificate(fuzzyValues);
    }

    public float Defuzzificate(List<float> values)
    {
        return values.Average();
    }

    void Start()
    {
        playerHealth = new MembershipFunction(5, 0.0f, 100.0f);
        enemiesHealth = new MembershipFunction(5, 0.0f, 100.0f);
        outputFunc = new MembershipFunction(5, -1.0f, 1.0f);
    }

    void Update()
    {
    }
}
