using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class FuzzyScript : MonoBehaviour
{
    private MembershipFunction playerHealth;
    private MembershipFunction enemiesHealth;
    private MembershipFunction outputFunc;

    public float CalculateOutput(float input1, float input2)
    {
        playerHealth = new MembershipFunction(6, -0.1f, 100.0f);
        enemiesHealth = new MembershipFunction(6, -0.1f, 100.0f);
        outputFunc = new MembershipFunction(6, 0.0f, 100.0f);

        List<KeyValuePair<string, float>> player = playerHealth.GetMembers(input1);
        List<KeyValuePair<string, float>> enemy = enemiesHealth.GetMembers(input2);
        List<KeyValuePair<string, float>> output = new List<KeyValuePair<string, float>>();

        //test rules
        foreach(KeyValuePair<string, float> pairP in player)
        {
            foreach(KeyValuePair<string, float> pairE in enemy)
            {
                //POSITIVELARGE output
                if(FuzzyRule.CheckConditions(pairP.Key, "POSITIVELARGE", pairE.Key, "NEGATIVELARGE") ||
                   FuzzyRule.CheckConditions(pairP.Key, "POSITIVELARGE", pairE.Key, "NEGATIVESMALL") ||
                   FuzzyRule.CheckConditions(pairP.Key, "POSITIVESMALL", pairE.Key, "NEGATIVELARGE"))
                {
                    float outputVal;
                    if (pairP.Value < pairE.Value) outputVal = pairP.Value;
                    else outputVal = pairE.Value;

                    output.Add(new KeyValuePair<string, float>("POSITIVELARGE", outputVal));
                }

                //POSITIVESMALL output
                if (FuzzyRule.CheckConditions(pairP.Key, "NEGATIVETINY", pairE.Key, "NEGATIVELARGE") ||
                    FuzzyRule.CheckConditions(pairP.Key, "POSITIVETINY", pairE.Key, "NEGATIVELARGE") ||
                    FuzzyRule.CheckConditions(pairP.Key, "POSITIVETINY", pairE.Key, "NEGATIVESMALL") ||
                    FuzzyRule.CheckConditions(pairP.Key, "POSITIVESMALL", pairE.Key, "NEGATIVESMALL") ||
                    FuzzyRule.CheckConditions(pairP.Key, "POSITIVESMALL", pairE.Key, "NEGATIVETINY") ||
                    FuzzyRule.CheckConditions(pairP.Key, "POSITIVELARGE", pairE.Key, "NEGATIVETINY") ||
                    FuzzyRule.CheckConditions(pairP.Key, "POSITIVELARGE", pairE.Key, "POSITIVETINY"))
                {
                    float outputVal;
                    if (pairP.Value < pairE.Value) outputVal = pairP.Value;
                    else outputVal = pairE.Value;

                    output.Add(new KeyValuePair<string, float>("POSITIVESMALL", outputVal));
                }

                //POSITIVETINY output
                if (FuzzyRule.CheckConditions(pairP.Key, "POSITIVETINY", pairE.Key, "POSITIVETINY") ||
                    FuzzyRule.CheckConditions(pairP.Key, "POSITIVESMALL", pairE.Key, "POSITIVESMALL") ||
                    FuzzyRule.CheckConditions(pairP.Key, "POSITIVELARGE", pairE.Key, "POSITIVELARGE") ||
                    FuzzyRule.CheckConditions(pairP.Key, "NEGATIVESMALL", pairE.Key, "NEGATIVELARGE") ||
                    FuzzyRule.CheckConditions(pairP.Key, "NEGATIVETINY", pairE.Key, "NEGATIVESMALL") ||
                    FuzzyRule.CheckConditions(pairP.Key, "POSITIVETINY", pairE.Key, "NEGATIVETINY") ||
                    FuzzyRule.CheckConditions(pairP.Key, "POSITIVESMALL", pairE.Key, "POSITIVETINY") ||
                    FuzzyRule.CheckConditions(pairP.Key, "POSITIVELARGE", pairE.Key, "POSITIVESMALL"))
                {
                    float outputVal;
                    if (pairP.Value < pairE.Value) outputVal = pairP.Value;
                    else outputVal = pairE.Value;

                    output.Add(new KeyValuePair<string, float>("POSITIVETINY", outputVal));
                }

                //NEGATIVETINY output
                if (FuzzyRule.CheckConditions(pairP.Key, "NEGATIVELARGE", pairE.Key, "NEGATIVELARGE") ||
                    FuzzyRule.CheckConditions(pairP.Key, "NEGATIVESMALL", pairE.Key, "NEGATIVESMALL") ||
                    FuzzyRule.CheckConditions(pairP.Key, "NEGATIVETINY", pairE.Key, "NEGATIVETINY") || 
                    FuzzyRule.CheckConditions(pairP.Key, "NEGATIVELARGE", pairE.Key, "NEGATIVESMALL") ||
                    FuzzyRule.CheckConditions(pairP.Key, "NEGATIVESMALL", pairE.Key, "NEGATIVETINY") ||
                    FuzzyRule.CheckConditions(pairP.Key, "NEGATIVETINY", pairE.Key, "POSITIVETINY") ||
                    FuzzyRule.CheckConditions(pairP.Key, "POSITIVETINY", pairE.Key, "POSITIVESMALL") ||
                    FuzzyRule.CheckConditions(pairP.Key, "POSITIVESMALL", pairE.Key, "POSITIVELARGE"))
                {
                    float outputVal;
                    if (pairP.Value < pairE.Value) outputVal = pairP.Value;
                    else outputVal = pairE.Value;

                    output.Add(new KeyValuePair<string, float>("NEGATIVETINY", outputVal));
                }

                //NEGATIVESMALL output
                if (FuzzyRule.CheckConditions(pairP.Key, "NEGATIVELARGE", pairE.Key, "NEGATIVETINY") ||
                    FuzzyRule.CheckConditions(pairP.Key, "NEGATIVELARGE", pairE.Key, "POSITIVETINY") ||
                    FuzzyRule.CheckConditions(pairP.Key, "NEGATIVESMALL", pairE.Key, "POSITIVETINY") ||
                    FuzzyRule.CheckConditions(pairP.Key, "NEGATIVESMALL", pairE.Key, "POSITIVESMALL") ||
                    FuzzyRule.CheckConditions(pairP.Key, "NEGATIVETINY", pairE.Key, "POSITIVESMALL") ||
                    FuzzyRule.CheckConditions(pairP.Key, "NEGATIVETINY", pairE.Key, "POSITIVELARGE") ||
                    FuzzyRule.CheckConditions(pairP.Key, "POSITIVETINY", pairE.Key, "POSITIVELARGE"))
                {
                    float outputVal;
                    if (pairP.Value < pairE.Value) outputVal = pairP.Value;
                    else outputVal = pairE.Value;

                    output.Add(new KeyValuePair<string, float>("NEGATIVESMALL", outputVal));
                }

                //NEGATIVELARGE output
                if (FuzzyRule.CheckConditions(pairP.Key, "NEGATIVELARGE", pairE.Key, "POSITIVELARGE") ||
                    FuzzyRule.CheckConditions(pairP.Key, "NEGATIVELARGE", pairE.Key, "POSITIVESMALL") ||
                   FuzzyRule.CheckConditions(pairP.Key, "NEGATIVESMALL", pairE.Key, "POSITIVELARGE"))
                {
                    float outputVal;
                    if (pairP.Value < pairE.Value) outputVal = pairP.Value;
                    else outputVal = pairE.Value;

                    output.Add(new KeyValuePair<string, float>("NEGATIVELARGE", outputVal));
                }
            }
        }

        return Defuzzificate(output);
    }

    public float Defuzzificate(List<KeyValuePair<string, float>> values)
    {
        List<float> outputVals = new List<float>();

        foreach (KeyValuePair<string, float> pair in values)
        {
            MembershipValue val = outputFunc.GetValueFromName(pair.Key);
            float up = val.GetCenterPoint();
            outputVals.Add(up);
        }

        if (outputVals.Count < 1) return 0.0f;
        return outputVals.Average();
    }

    void Start()
    {
    }

    void Update()
    {
    }
}
