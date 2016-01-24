using UnityEngine;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public static class StringProcessor
{
    // Horizontal @JOY+
    // Vertical @JOY-
    // Stabilise @STAB
    // Hand Brake @BRAKE
    // Roll @ROLL
    // Rearview @REAR
    // BattleAccelerate @ACC
    // Fire @FIRE

    public static string ProcessString(string input)
    {
        string output = InsertPlayerName(input);
        Debug.Log(output);
        //output = InterpretBattleControls(output);
        return output;
    }

    private static string InterpretBattleControls(string input)
    {
        string output = input;
        return output;
    }

    private static string InsertPlayerName(string input)
    {
        Dictionary<string, string> CharNames = SaveLoadController.GetCharacterNames();
        string output = input;
        foreach (KeyValuePair<string, string> name in CharNames)
        {
            output = output.Replace(name.Key, name.Value);
        }
        return output;
    }
}
