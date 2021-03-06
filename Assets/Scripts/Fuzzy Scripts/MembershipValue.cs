﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;

class MembershipValue
{
    private float a, b, c;

    public MembershipValue(float aNew, float bNew, float cNew)
    {
        a = aNew;
        b = bNew;
        c = cNew;
    }

    public float GetLeftPoint()
    {
        return a;
    }

    public float GetCenterPoint()
    {
        return b;
    }

    public float GetRightPoint()
    {
        return c;
    }

    public float GetDegreeOfMembership(float input)
    {
        //if the input is not within the value's parameters
        if (input <= a || input >= c)
        {
            return 0.0f;
        }

        if(input == b)
        {
            return 1.0f;
        }

        if (input > a && input < b)
        {
            return ((input - a) / (b - a));
        }

        if (input > b && input < c)
        {
            return ((c - input) / (c - b));
        }

        //shouldn't happen
        return 0.0f;
    }

    public float GetValue(float membership)
    {
        if (membership == 1.0f)
        {
            return b;
        }

        float first = a + ((b - a)*membership);
        float second = c - ((c - b) * membership);

        float output = (first + second) / 2;
        if (output > 100.0f) output = 100.0f;

        return output;
    }
}
