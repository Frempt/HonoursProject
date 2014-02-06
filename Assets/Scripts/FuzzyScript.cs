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
        List<KeyValuePair<string, float>> player = playerHealth.GetMembers(input1);
        List<KeyValuePair<string, float>> enemy = enemiesHealth.GetMembers(input2);
        //List<KeyValuePair<string, float>> output = new List<KeyValuePair<string, float>>();
        List<string> output = new List<string>();

        //test rules
        foreach(KeyValuePair<string, float> pairP in player)
        {
            foreach(KeyValuePair<string, float> pairE in enemy)
            {
                Debug.Log("Checking rules");
                //POSITIVELARGE output
                if(FuzzyRule.CheckConditions(pairP.Key, "POSITIVELARGE", pairE.Key, "NEGATIVELARGE") ||
                   FuzzyRule.CheckConditions(pairP.Key, "POSITIVELARGE", pairE.Key, "NEGATIVESMALL") ||
                   FuzzyRule.CheckConditions(pairP.Key, "POSITIVESMALL", pairE.Key, "NEGATIVELARGE"))
                {
                    output.Add("POSITIVELARGE");
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
                    output.Add("POSITIVESMALL");
                }

                //POSITIVETINY output
                if (FuzzyRule.CheckConditions(pairP.Key, "NEGATIVESMALL", pairE.Key, "NEGATIVELARGE") ||
                    FuzzyRule.CheckConditions(pairP.Key, "NEGATIVETINY", pairE.Key, "NEGATIVESMALL") ||
                    FuzzyRule.CheckConditions(pairP.Key, "POSITIVETINY", pairE.Key, "NEGATIVETINY") ||
                    FuzzyRule.CheckConditions(pairP.Key, "POSITIVESMALL", pairE.Key, "POSITIVETINY") ||
                    FuzzyRule.CheckConditions(pairP.Key, "POSITIVELARGE", pairE.Key, "POSITIVESMALL"))
                {
                    output.Add("POSITIVETINY");
                }

                //ZERO output
                if (FuzzyRule.CheckConditions(pairP.Key, "NEGATIVELARGE", pairE.Key, "NEGATIVELARGE") ||
                    FuzzyRule.CheckConditions(pairP.Key, "NEGATIVESMALL", pairE.Key, "NEGATIVESMALL") ||
                    FuzzyRule.CheckConditions(pairP.Key, "NEGATIVETINY", pairE.Key, "NEGATIVETINY") ||
                    FuzzyRule.CheckConditions(pairP.Key, "POSITIVETINY", pairE.Key, "POSITIVETINY") ||
                    FuzzyRule.CheckConditions(pairP.Key, "POSITIVESMALL", pairE.Key, "POSITIVESMALL") ||
                    FuzzyRule.CheckConditions(pairP.Key, "POSITIVELARGE", pairE.Key, "POSITIVELARGE"))
                {
                    output.Add("POSITIVETINY");
                }

                //NEGATIVETINY output
                if (FuzzyRule.CheckConditions(pairP.Key, "NEGATIVELARGE", pairE.Key, "NEGATIVESMALL") ||
                    FuzzyRule.CheckConditions(pairP.Key, "NEGATIVESMALL", pairE.Key, "NEGATIVETINY") ||
                    FuzzyRule.CheckConditions(pairP.Key, "NEGATIVETINY", pairE.Key, "POSITIVETINY") ||
                    FuzzyRule.CheckConditions(pairP.Key, "POSITIVETINY", pairE.Key, "POSITIVESMALL") ||
                    FuzzyRule.CheckConditions(pairP.Key, "POSITIVESMALL", pairE.Key, "POSITIVELARGE"))
                {
                    output.Add("NEGATIVETINY");
                }

                //NEGATIVESMALL output
                if (FuzzyRule.CheckConditions(pairP.Key, "NEGATIVELARGE", pairE.Key, "NEGATIVETINY") ||
                    FuzzyRule.CheckConditions(pairP.Key, "NEGATIVELARGE", pairE.Key, "POSITIVETINY") ||
                    FuzzyRule.CheckConditions(pairP.Key, "NEGATIVESMALL", pairE.Key, "POSITIVETINY") ||
                    FuzzyRule.CheckConditions(pairP.Key, "NEGATIVESMALL", pairE.Key, "POSITIVESMALL") ||
                    FuzzyRule.CheckConditions(pairP.Key, "NEGATIVETINY", pairE.Key, "POSITIVESMALL") ||
                    FuzzyRule.CheckConditions(pairP.Key, "NEGATIVETINY", pairE.Key, "POSITIVESMALL") ||
                    FuzzyRule.CheckConditions(pairP.Key, "POSITIVETINY", pairE.Key, "POSITIVELARGE"))
                {
                    output.Add("POSITIVESMALL");
                }

                //NEGATIVELARGE output
                if (FuzzyRule.CheckConditions(pairP.Key, "NEGATIVELARGE", pairE.Key, "POSITIVELARGE") ||
                    FuzzyRule.CheckConditions(pairP.Key, "NEGATIVELARGE", pairE.Key, "POSITIVESMALL") ||
                   FuzzyRule.CheckConditions(pairP.Key, "NEGATIVESMALL", pairE.Key, "POSITIVELARGE"))
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
            fuzzyValues.Add(outputFunc.GetValueFromName(output[i]));
            Debug.Log("value added" + output[i]);
        }

        return Defuzzificate(fuzzyValues);
    }

    public float Defuzzificate(List<float> values)
    {
        return values.Average();
    }

    void Start()
    {
        playerHealth = new MembershipFunction(6, 0.0f, 100.0f);
        enemiesHealth = new MembershipFunction(6, 0.0f, 100.0f);
        outputFunc = new MembershipFunction(6, 0.0f, 100.0f);
    }

    void Update()
    {
    }
}
