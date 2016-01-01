using UnityEngine;
using System.Collections;
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
        string playerName = "";
        playerName = SaveLoadController.GetPlayerName();
        if (playerName == "")
        {
            playerName = "Isaac";
        }
        string output = input;
        output = output.Replace("@charname", playerName);
        return output;
    }
}
