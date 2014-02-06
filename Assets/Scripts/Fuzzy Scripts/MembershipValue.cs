using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class MembershipValue
{
    private float a, b, c;

    public MembershipValue(float aNew, float bNew, float cNew)
    {
        a = aNew;
        b = bNew;
        c = cNew;
    }

    public float GetCenterPoint()
    {
        return b;
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
}
