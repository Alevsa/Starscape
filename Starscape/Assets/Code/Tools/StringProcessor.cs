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

    public static string ProcessMissionString(string input)
    {
        string output = input;
        return output;
    }

    private static string InterpretBattleControls(string input)
    {
        string output = input;
        output.Replace("@JOY", "Joystick");
        //Input.
        return output;
    }

 //   private static string Insert
}
