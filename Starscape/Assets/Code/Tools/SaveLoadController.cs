using UnityEngine;
using System.Collections;

public static class SaveLoadController 
{	
	// Playername
	// Player Position
	// Player Health
	// Part health
	
	public static void SetSaveSlot (int num)
	{
		if ((num < 0) || (num > 2))
			return;

		PlayerPrefs.SetInt ("ActiveSlot", num);
	}

	public static void SetTempSlot ()
	{
		PlayerPrefs.SetInt ("SuspendedSlot", PlayerPrefs.GetInt ("ActiveSlot"));
		PlayerPrefs.SetInt ("ActiveSlot", 420);
	}

	public static void SwitchSlotToActive()
	{
		PlayerPrefs.SetInt ("ActiveSlot", PlayerPrefs.GetInt ("SuspendedSlot"));
	}

	public static void SetPlayerName (string name)
	{
		int activeSlot = PlayerPrefs.GetInt ("ActiveSlot");
		PlayerPrefs.SetString (activeSlot + "playerName", name);
	}
	
	public static string GetPlayerName()
	{
		int activeSlot = PlayerPrefs.GetInt ("ActiveSlot");
		return PlayerPrefs.GetString(activeSlot + "playerName");
	}
	
	public static void SavePlayerPosition (Vector3 pos)
	{
		int activeSlot = PlayerPrefs.GetInt ("ActiveSlot");

		PlayerPrefs.SetFloat (activeSlot + "pXpos", pos.x);
		PlayerPrefs.SetFloat (activeSlot + "pYpos", pos.y);
		PlayerPrefs.SetFloat (activeSlot + "pZpos", pos.z);
	}

	public static Vector3 GetSavedPlayerPosition ()
	{
		int activeSlot = PlayerPrefs.GetInt ("ActiveSlot");

		Vector3 res;
		res.x = PlayerPrefs.GetFloat (activeSlot + "pXpos");
		res.y = PlayerPrefs.GetFloat (activeSlot + "pYpos");
		res.z = PlayerPrefs.GetFloat (activeSlot + "pZpos");

		return res;
	}

	public static void SavePlayerHealth (string partName, float health)
	{
		int activeSlot = PlayerPrefs.GetInt ("ActiveSlot");

		PlayerPrefs.SetFloat (activeSlot + "p" + partName + "Health", health);
	}

	public static float GetPlayerHealth (string partName)
	{
		int activeSlot = PlayerPrefs.GetInt ("ActiveSlot");

		float res = PlayerPrefs.GetFloat (activeSlot + "p" + partName + "Health");

		return res;
	}

	public static void EraseSaveSlot (int slot)
	{
		SetSaveSlot (slot);
		SetPlayerName (null);
		SavePlayerPosition (new Vector3 (-1F, -1F, -1F));
	}
	
	public static void SetYAxisInversion (bool inverted)
	{
		if (inverted)
			PlayerPrefs.SetInt("yInverted", -1);
		else
			PlayerPrefs.SetInt("yInverted", 1);
	}
	
	public static int GetYAxisInversion()
	{
		return PlayerPrefs.GetInt("yInverted", 1);
	}
	
	public static void SetMouseControl (bool mouseControl)
	{
		if (mouseControl)
			PlayerPrefs.SetInt("MouseControls", 1);
		else
			PlayerPrefs.SetInt("MouseControls", 0);		
	}
	
	public static bool GetMouseControl ()
	{
		if (PlayerPrefs.GetInt("MouseControls") == 1)
			return true;
		else 
			return false;
	}

    public static int GetStoryStage()
    {
        return PlayerPrefs.GetInt("StoryStage", 0);
    }

    public static void SetStoryStage(int stage)
    {
        PlayerPrefs.SetInt("StoryStage", stage);
    }

    public static void SetDialogueSpeed(string Speed)
    {
        switch (Speed)
        {
            case "fast":
                PlayerPrefs.SetFloat("DialogueSpeed", 0.5f);
                break;
            case "normal":
                PlayerPrefs.SetFloat("DialogueSpeed", 1f);
                break;
            case "slow":
                PlayerPrefs.SetFloat("DialogueSpeed", 2f);
                break;
        }
    }

    public static float GetDialogueSpeed()
    {
        return PlayerPrefs.GetFloat("DialogueSpeed");
    }
}
