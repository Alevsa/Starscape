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
		if ((num <= 0) || (num > 3))
			return;

		PlayerPrefs.SetInt ("ActiveSlot", num);
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
		SetPlayerName ("");
		SavePlayerPosition (new Vector3 (-1F, -1F, -1F));
	}
}
