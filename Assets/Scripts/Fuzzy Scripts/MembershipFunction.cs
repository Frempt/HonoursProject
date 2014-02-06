using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class MembershipFunction
{
    private MembershipValue[] values;
    private string[] names;

    public MembershipFunction(int numOfValues, float minVal, float maxVal)
    {
        values = new MembershipValue[numOfValues];
        names = new string[numOfValues];

        names[0] = "NEGATIVELARGE";
        names[1] = "NEGATIVESMALL";
        names[2] = "NEGATIVETINY";
        names[3] = "POSITIVETINY";
        names[4] = "POSITIVESMALL";
        names[5] = "POSITIVELARGE";

        float spacing = (maxVal / numOfValues) * 1.2f;

        for (int i = 0; i < values.Length; i++)
        {
            float b = minVal + (i * spacing);
            float a = b - (spacing/2);
            float c = b + (spacing/2);
            values[i] = new MembershipValue(a, b, c);
            //Debug.Log(a + " " + b + " " + c);
        }
    }

    public List<KeyValuePair<string, float>> GetMembers(float input)
    {
        List<KeyValuePair<string, float>> returnList = new List<KeyValuePair<string, float>>();

        for (int i = 0; i < values.Length; i++)
        {
            float membership = values[i].GetDegreeOfMembership(input);
            if (membership > 0.0f)
            {
                KeyValuePair<string, float> pair = new KeyValuePair<string, float>(names[i], membership);
                returnList.Add(pair);
            }
        }

        return returnList;
    }

    public float GetValueFromName(string name)
    {
        float returnValue = 0.0f;

        for (int i = 0; i < values.Length; i++)
        {
            if (names[i] == name)
            {
                returnValue = values[i].GetCenterPoint();
            }
        }
        return returnValue;
    }
}
