using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class FuzzyRule
{
    FuzzyRule()
    {
    }

    public static bool CheckConditions(string input1, string inputCondition1, string input2, string inputCondition2)
    {
        bool returnVal = true;

        if (inputCondition1 != input1)
        {
            returnVal = false;
        }
        if (inputCondition2 != "NONE")
        {
            if (inputCondition2 != input2)
            {
                returnVal = false;
            }
        }

        return returnVal;
    }
}
